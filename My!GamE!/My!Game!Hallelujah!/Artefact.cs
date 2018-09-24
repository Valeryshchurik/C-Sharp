using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Of_The_Year
{
    public abstract class Artefact : IMagic //абстрактный класс артефакта
    {
        public abstract void SaySpell(); //перекруженные методы интерфейса
        public abstract void SaySpell(Hero hero);
        public abstract void SaySpell(Hero hero, int power);
        public int Power { get; set; } //мощность артефакта
        public bool IsRenewable { get; protected set; } //возобновляемый ли артефакт
        public bool Ispoweroptioned { get; protected set; }
        protected Hero Owner; //владелец артефакта
        public abstract void give_nishtjachki(Hero owner);
        public abstract void ungive_nishtjachki(Hero owner);
        public Artefact(Hero owner, int power, bool isrenewabale) //конструктор
        {
            Owner = owner;
            Power = power;
            IsRenewable = isrenewabale;
        }
        public override string ToString()
        {
            return "Артефакт";
        }
    }
    public abstract class LivingWaterBottle : Artefact //бутылка живой воды (абстрактный)
    {
        public LivingWaterBottle(Hero owner, int power) : base(owner, power, false) { Ispoweroptioned = false; }

        public override void SaySpell(Hero hero)
        {
            hero.HeroHP += Power;
        }
        public override void SaySpell(Hero hero, int power)
        {
            SaySpell(hero);
        }
        public override void SaySpell()
        {
            SaySpell(Owner);
        }
        public override void give_nishtjachki(Hero owner) { }
        public override void ungive_nishtjachki(Hero owner) { }
        public override string ToString()
        {
            return "Бутылка живой воды (" + this.Power + ")";
        }
    }
    public class LivingWaterBottle10 : LivingWaterBottle // живая вода на 10
    {
        public LivingWaterBottle10(Hero owner) : base(owner, 10) { }
    }
    public class LivingWaterBottle25 : LivingWaterBottle //живая вода на 25
    {
        public LivingWaterBottle25(Hero owner) : base(owner, 25) { }
    }
    public class LivingWaterBottle50 : LivingWaterBottle //живая вода на 50
    {
        public LivingWaterBottle50(Hero owner) : base(owner, 50) { }
    }

    //-------------------------------------------------------------
    public abstract class DeadWaterBottle : Artefact //бутылка мёртвой воды (абстрактный)
    {
        public DeadWaterBottle(Hero owner, int power) : base(owner, power, false) { Ispoweroptioned = false; }

        public override void SaySpell(Hero hero)
        {
            if (hero is MagicHero)
                (hero as MagicHero).HeroMP += Power;
        }
        public override void SaySpell(Hero hero, int power)
        {
            SaySpell(hero);
        }
        public override void SaySpell()
        {
            SaySpell(Owner);
        }
        public override void give_nishtjachki(Hero owner) { }
        public override void ungive_nishtjachki(Hero owner) { }
        public override string ToString()
        {
            return "Бутылка мёртвой воды (" + this.Power + ")";
        }
    }
    public class DeadWaterBottle10 : DeadWaterBottle //мёртвая вода на 10
    {
        public DeadWaterBottle10(Hero owner) : base(owner, 10) { }
    }
    public class DeadWaterBottle25 : DeadWaterBottle //мёртвая вода на 25
    {
        public DeadWaterBottle25(Hero owner) : base(owner, 25) { }
    }
    public class DeadWaterBottle50 : DeadWaterBottle //мёртвая вода на 50
    {
        public DeadWaterBottle50(Hero owner) : base(owner, 50) { }
    }
    //-------------------------------------------------------------
    public class LightningStick : Artefact //посох молнии
    {
        public LightningStick(Hero owner, int power) : base(owner, power, true) { Ispoweroptioned = true; }
        public override void SaySpell(Hero hero, int power)
        {
            if (power > 0)
            {
                if (Power < power)
                {
                    hero.HeroHP -= Power;
                    Power = 0;
                }
                else
                {
                    hero.HeroHP -= power;
                    Power -= power;
                }
            }
        }
        public override void give_nishtjachki(Hero owner)
        {
            owner.HeroAttack.damage += 5;
        }
        public override void ungive_nishtjachki(Hero owner)
        {
            owner.HeroAttack.damage -= 5;
        }
        public override void SaySpell(Hero hero)
        {
            SaySpell(hero, Power);
        }
        public override void SaySpell() { }
        public override string ToString()
        {
            return "Посох Молнии. Сила "+Power+"Использование - молния. 1 сила-1 урон";
        }
    }
    //-------------------------------------------------------------
    public class FrogLegs : Artefact //декокт из лягушачьих лапок
    {
        public FrogLegs(Hero owner, int power) : base(owner, power, false) { Ispoweroptioned = false; }
        public override void SaySpell(Hero hero)
        {
            if (hero.IsPoisoned)
            {
                hero.IsPoisoned = false;
                if (hero.HeroHP * 100 / hero.MaxHP < 10)
                {
                    hero.HeroState = State.Weak;
                }
                else
                    hero.HeroState = State.Normal;
            }
        }
        public override void SaySpell(Hero hero, int power)
        {
            SaySpell(hero);
        }
        public override void SaySpell()
        {
            SaySpell(Owner);
        }
        public override void give_nishtjachki(Hero owner) { }
        public override void ungive_nishtjachki(Hero owner) { }
        public override string ToString()
        {
            return "Декокт из лягушачьих лапок";
        }
    }
    //-------------------------------------------------------------
    public class PoisonousSaliva : Artefact //ядовитая слюна
    {
        public PoisonousSaliva(Hero owner, int power) : base(owner, power, true) { Ispoweroptioned = true; }
        public override void SaySpell(Hero hero)
        {
            if (hero.HeroState == State.Normal || hero.HeroState == State.Weak)
            {
                hero.HeroState = State.Poisoned;
                hero.IsPoisoned = true;
                hero.HeroHP -= Power;
            }
            hero.dampoison += Power / 3;
            Power = 0;
        }
        public override void SaySpell(Hero hero, int power)
        {
            int p;
            if (power > Power)
                p = Power;
            else p = power;
            if (hero.HeroState == State.Normal || hero.HeroState == State.Weak)
            {
                hero.HeroState = State.Poisoned;
                hero.IsPoisoned = true;
                hero.HeroHP -= p;
            }
            hero.dampoison = p / 3;
            Power -= p;
        }
        public override void SaySpell() { }
        public override void give_nishtjachki(Hero owner) { }
        public override void ungive_nishtjachki(Hero owner) { }
        public override string ToString()
        {
            return "Ядовитая слюна. Использование:1сила-1урон-1/3 яда.";
        }
    }
    //-------------------------------------------------------------
    public class BasiliskEye : Artefact //глаз василиска
    {
        public BasiliskEye(Hero owner, int power) : base(owner, power, false) { Ispoweroptioned = false; }
        public override void SaySpell(Hero hero)
        {
            if (hero.HeroState != State.Dead)
            {
                hero.IsParalyzed = true;
                hero.HeroState = State.Paralyzed;
                hero.IsMovable = false;
            }
        }
        public override void SaySpell(Hero hero, int power)
        {
            SaySpell(hero);
        }
        public override void SaySpell() { }
        public override void give_nishtjachki(Hero owner) { }
        public override void ungive_nishtjachki(Hero owner) { }
        public override string ToString()
        {
            return "Глаз василиска. Использование: станит на ход.";
        }
    }
}
