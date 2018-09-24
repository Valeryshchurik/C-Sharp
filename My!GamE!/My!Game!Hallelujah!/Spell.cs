using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Of_The_Year
{
    public abstract class Spell : IMagic //абстрактный класс заклинания
    {
        public abstract void SaySpell();                            //
        public abstract void SaySpell(Hero hero);                   // наследуемые от интерфейса методы
        public abstract void SaySpell(Hero hero, int power);       //
        public int MinMP { get; protected set; } //минимальная мана на заклинание
        public bool IsPronounced { get; protected set; } //произносится ли заклинание
        public bool InMove { get; protected set; } //телодвижения на заклинание
        public bool Ispoweroptioned { get; protected set; }
        protected MagicHero Owner; //произносящий заклинание
        public Spell(MagicHero owner, int min) //конструктор
        {
            Owner = owner;
            MinMP = min;
            IsPronounced = !Owner.IsSilenced;
            InMove = Owner.IsMovable;
        }
        public override string ToString()
        {
            return "Заклинание требует " + MinMP + " маны";
        }
    }
    //-------------------------------------------------------------
    public class AddHP : Spell //заклинание "добавить здоровье"
    {
        public AddHP(MagicHero Owner) : base(Owner, 1) { Ispoweroptioned = true; } //конструктор
        public override void SaySpell(Hero hero, int power) //перегруженные функции произнесения заклинания
        {
            if (Owner.HeroMP >= MinMP && IsPronounced && InMove)
            {
                int neededHP = hero.MaxHP - hero.HeroHP;
                if (Owner.HeroMP < power * 2)
                {
                    hero.HeroHP += Owner.HeroMP / 2;
                    Owner.HeroMP = 0;
                }
                else if (power + hero.HeroHP > hero.MaxHP)
                {
                    hero.HeroHP = hero.MaxHP;
                    Owner.HeroMP -= neededHP * 2;
                }
                else
                {
                    hero.HeroHP += power;
                    Owner.HeroMP -= power * 2;
                }
            }
        }
        public override void SaySpell(Hero hero)
        {
            SaySpell(hero, hero.MaxHP / 2);
        }
        public override void SaySpell()
        {
            SaySpell(Owner, Owner.MaxHP / 2);
        }
        public override string ToString()
        {
            return "Добавить здоровье. 2 HP = 1 MP/n" + base.ToString();
        }
    }
    //-------------------------------------------------------------
    public class Healing : Spell //заклинание "вылечить"
    {
        public Healing(MagicHero Owner) : base(Owner, 20) { Ispoweroptioned = false; } //конструктор
        public override void SaySpell(Hero hero, int power) //перегруженные функции произнесения заклинания
        {
            if (Owner.HeroMP >= MinMP && IsPronounced && hero.HeroState == State.Ill)
            {
                Owner.HeroMP -= MinMP;
                //hero.dampoison = 0;
                if (hero.HeroHP * 100 / hero.MaxHP < 10)
                {
                    hero.HeroState = State.Weak;
                }
                else
                    hero.HeroState = State.Normal;
            }
        }
        public override void SaySpell(Hero hero)
        {
            SaySpell(hero, 20);
        }
        public override void SaySpell()
        {
            SaySpell(Owner, 20);
        }
        public override string ToString()
        {
            return "Вылечить./n" + base.ToString();
        }
    }
    //-------------------------------------------------------------
    public class Antidote : Spell //заклинание "противоядие"
    {
        public Antidote(MagicHero Owner) : base(Owner, 30) { Ispoweroptioned = false; } //конструктор
        public override void SaySpell(Hero hero, int power) //перегруженные функции произнесения заклинания
        {
            if (Owner.HeroMP >= MinMP && IsPronounced)
            {
                hero.IsPoisoned = false;
                hero.dampoison = 0;
                Owner.HeroMP -= MinMP;
                if (hero.HeroHP * 100 / hero.MaxHP < 10)
                {
                    hero.HeroState = State.Weak;
                }
                else
                    hero.HeroState = State.Normal;
            }
        }
        public override void SaySpell(Hero hero)
        {
            SaySpell(hero, 30);
        }
        public override void SaySpell()
        {
            SaySpell(Owner, 30);
        }
        public override string ToString()
        {
            return "Противоядие/n" + base.ToString();
        }
    }
    //-------------------------------------------------------------
    public class Reanimate : Spell //заклинание "оживить"
    {
        public Reanimate(MagicHero Owner) : base(Owner, 150) { Ispoweroptioned = false; } //конструктор
        public override void SaySpell(Hero hero, int power) //перегруженные методы
        {
            if (Owner.HeroMP >= MinMP && IsPronounced && InMove)
            {
                if (hero.HeroState == State.Dead)
                {
                    Owner.HeroMP -= MinMP;
                    hero.HeroHP = 1;
                }
            }
        }
        public override void SaySpell(Hero hero)
        {
            SaySpell(hero, 150);
        }
        public override void SaySpell()
        {
            SaySpell(Owner, 150);
        }
        public override string ToString()
        {
            return "Оживить./n" + base.ToString();
        }
    }
    //-------------------------------------------------------------
    public class Armor : Spell //заклинание "броня"
    {
        public Armor(MagicHero Owner) : base(Owner, 50) { Ispoweroptioned = true; } //конструктор
        public override void SaySpell(Hero hero, int power) // power - количество невосприятий к уменьшению здоровья (количество раз)
        {
            if (Owner.HeroMP >= MinMP * power && IsPronounced && InMove)
            {
                Owner.HeroMP -= power * 50;
                hero.SetImmortal((int)power);
            }
        }
        public override void SaySpell(Hero hero)
        {
            SaySpell(hero, 5);
        }
        public override void SaySpell()
        {
            SaySpell(Owner, 5);
        }
        public override string ToString()
        {
            return "Броня./n" + base.ToString();
        }
    }
    //-------------------------------------------------------------
    public class Unfreeze : Spell //заклинание "отомри"
    {
        public Unfreeze(MagicHero Owner) : base(Owner, 85) { Ispoweroptioned = false; } //конструктор
        public override void SaySpell(Hero hero, int power) //перегруженные методы
        {
            if (Owner.HeroMP >= MinMP && IsPronounced && hero.IsParalyzed)
            {
                Owner.HeroMP -= MinMP;
                hero.HeroHP = 1;
                hero.IsParalyzed = false;
            }
        }
        public override void SaySpell(Hero hero)
        {
            SaySpell(hero, 85);
        }
        public override void SaySpell()
        {
            SaySpell(Owner, 85);
        }
        public override string ToString()
        {
            return "Отомри!/n" + base.ToString();
        }
    }
}
