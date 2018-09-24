using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Of_The_Year
{
    public enum Gender //перечисление пола
    {
        Male = 1,
        Female
    }

    public enum Race //перечисление расы
    {
        Human = 1,
        Dwarf,
        Elf,
        Ogre,
        Goblin
    }

    public enum State //перечисление состояния
    {
        Normal = 1,
        Weak,
        Ill,
        Poisoned,
        Paralyzed,
        Dead
    }
    //-------------------------------------------------------------

    public class Hero : IComparable //класс "герой"
    {
        protected static uint ID = 0; //для уникального ID
        protected uint HeroID { get; private set; } //свойство для ID
        public string Name { get; protected set; } //свойство для имени
        public State HeroState { get; set; } //свойство для состояния
        public bool IsSilenced { get; set; } //свойство "может ли говорить"
        public bool IsMovable { get; set; } //свойство "может ли передвигаться"
        public bool IsPoisoned { get; set; }
        public bool IsParalyzed { get; set; }
        public Race HeroRace { get; protected set; } //свойство дл расы
        public Gender HeroGender { get; protected set; } //свойство для пола
        public uint Age { get; set; } //свойство для возраста
        protected int currentHP; //поле для здоровья, смотри свойство ниже
        public int dampoison { get; set; }
        public attack HeroAttack;
        public void afterturn()
        {
            if (IsParalyzed)
            {
                HeroState = State.Normal;
                IsParalyzed = false;
            }

            if (IsPoisoned)
            {
                //if (immortal==0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Яд наносит " + Name + " " + dampoison + " урона");
                    Console.ForegroundColor = ConsoleColor.White;
                    HeroHP -= dampoison;
                    if (dampoison < (int)this.HeroRace)
                    {
                        HeroState = State.Normal;
                        dampoison = 0;
                        IsPoisoned = false;
                    }
                    else
                        dampoison -= (int)this.HeroRace;
                }
                //else 
                //{
                //    Console.ForegroundColor = ConsoleColor.Green;
                //    Console.WriteLine("Яд наносит " + Name + " " + 0 + " урона");
                //    Console.ForegroundColor = ConsoleColor.White;
                //}
            }
        }
        public int HeroHP
        { //свойство для здоровья
            get
            {
                return (int)currentHP;
            }
            set
            {
                if (HeroState == State.Dead) { }
                else if (value < currentHP && IsImmortal)
                    immortal--;
                else if (value <= 0)
                {
                    currentHP = 0;
                    HeroState = State.Dead;
                }
                else if (value > MaxHP)
                {
                    currentHP = (int)MaxHP;
                    if (HeroState != State.Ill && HeroState != State.Poisoned && HeroState != State.Paralyzed && HeroState != State.Dead)
                        HeroState = State.Normal;
                }
                else if (value * 100 / MaxHP < 10)
                {
                    currentHP = (int)value;
                    if (HeroState != State.Ill && HeroState != State.Poisoned && HeroState != State.Paralyzed)
                        HeroState = State.Weak;
                }
                else
                {
                    currentHP = (int)value;
                    if (HeroState != State.Ill && HeroState != State.Poisoned && HeroState != State.Paralyzed)
                        HeroState = State.Normal;
                }
            }
        }

        public class attack
        {
            public int damage { get; set; }
            public int poisondamage { get; set; }
            public double stan { get; set; }
            public double poiso { get; set; }
            public attack(int dam)
            {
                damage = dam;
                poisondamage = 0;
                stan = 0;
                poiso = 0;
            }
            public attack(int dam, double st, double p, int pd)
            {
                damage = dam;
                stan = st;
                poiso = p;
                poisondamage = pd;
            }
            public void Attack(Hero enemy)
            {
                int rn;
                enemy.HeroHP -= damage;
                Random rnd = new Random();
                if (enemy.HeroState != State.Dead)
                {
                    rn = rnd.Next(1, 100);
                    if (rn <= 100 * stan)
                    {
                        enemy.HeroState = State.Paralyzed;
                        enemy.IsParalyzed = true;
                    }
                    rn = rnd.Next(1, 100);
                    if (rn <= 100 * poiso)
                    {
                        enemy.dampoison = poisondamage;
                        enemy.IsPoisoned = true;
                    }
                }
            }
        }
        protected int immortal;
        public bool IsImmortal
        {
            get
            {
                return (immortal > 0);
            }
        }
        public void SetImmortal(int times)
        {
            immortal = (times > 0) ? times : 0;
        }
        public int MaxHP { get; set; } //свойство для максимального здоровья
        public uint HeroXP { get; set; } //свойство для опыта
        public override string ToString() //возвращает строку - характеристика
        {
            return String.Format("Имя героя: {0}\nСостояние: {1}\nРаса: {2}\nПол: {3}\nВозраст: {4}\nТекущее здоровье: {5}\nТекущий опыт: {6}\n", new object[] { Name, HeroState.ToString(), HeroRace.ToString(), HeroGender.ToString(), Age.ToString(), HeroHP.ToString(), HeroXP.ToString() });
        }
        public Hero(string name, Race race, Gender gender) //конструктор
        {
            HeroID = ++ID;
            Name = name;
            HeroRace = race;
            HeroGender = gender;
            HeroState = State.Normal;
            Age = 18;
            HeroHP = MaxHP = 100;
            HeroAttack = new attack(15 - (int)HeroRace);
            IsMovable = true;
            IsSilenced = false;
            immortal = 0;
            Inventory = new List<Artefact>();
            dampoison = 0;
        }
        public int CompareTo(object obj) //переопределённый CompareTo из интерфейса IComparable
        {
            if (!(obj is Hero))
            {
                throw new ArgumentException("Object is not a Hero");
            }
            Hero _Hero = obj as Hero;
            if (this.HeroXP < _Hero.HeroXP)
            {
                return -1;
            }
            if (this.HeroXP > _Hero.HeroXP)
            {
                return 1;
            }
            return 0;
        }
        public List<Artefact> Inventory { get; set; } //мешок-инвентарь
        public void PickUpArtefact(Artefact art) //подобрать артефакт и положить в инвентарь
        {
            bool isalready = false;
            if (art.IsRenewable)
            {
                foreach (Artefact a in Inventory)
                    if (a.GetType() == art.GetType())
                    {
                        isalready = true;
                        a.Power += art.Power;
                        return;
                    }
                Inventory.Add(art);
            }
            else
                Inventory.Add(art);
            if (!isalready)
                art.give_nishtjachki(this);
        }
        public void ThrowOutArtefact(Artefact art) //выбросить артефакт из мешка
        {
            if (Inventory.Contains(art))
            {
                Inventory.Remove(art);
                art.ungive_nishtjachki(this);
            }
        }
        public void PassArtefact(Hero hero, Artefact art) //передать артефакт
        {
            ThrowOutArtefact(art);
            hero.PickUpArtefact(art);
        }
        public void UseArtefact(Artefact art, Hero hero, int power) //перегруженные методы "использовать артефакт"
        {
            if (Inventory.Contains(art))
            {
                art.SaySpell(hero, power);
                if (!art.IsRenewable)
                    ThrowOutArtefact(art);
                //Inventory.Remove(art);
            }
        }
        public void UseArtefact(Artefact art, Hero hero)
        {
            if (Inventory.Contains(art))
            {
                art.SaySpell(hero);
                if (!art.IsRenewable)
                    ThrowOutArtefact(art);
                //Inventory.Remove(art);
            }
        }
        public void UseArtefact(Artefact art)
        {
            if (Inventory.Contains(art))
            {
                art.SaySpell();
                if (!art.IsRenewable)
                    ThrowOutArtefact(art);
                //Inventory.Remove(art);
            }
        }
    }
    //-------------------------------------------------------------
    public class MagicHero : Hero //класс-наследник "герой, владеющий магией"
    {
        public MagicHero(string name, Race race, Gender gender)
            : base(name, race, gender)
        {
            HeroMP = MaxMP = 100;
            SpellList = new List<Spell>();
        }

        protected int currentMP; //поле для маны, смотри свойство ниже
        public int HeroMP //свойство для маны
        {
            get
            {
                return (int)currentMP;
            }
            set
            {
                if (value < 0)
                    currentMP = 0;
                else
                    currentMP = (int)value;
            }
        }
        public int MaxMP { get; set; } //свойство для максимальной маны
        public void Heal(Hero hero) //лечение персонажа за счёт маны
        {
            if (HeroMP != 0)
            {
                int neededHP = hero.MaxHP - hero.HeroHP;
                int possible_to_addHP = HeroMP / 2;
                if (neededHP <= possible_to_addHP)
                {
                    hero.HeroHP = hero.MaxHP;
                    HeroMP -= neededHP * 2;
                }
                else
                {
                    hero.HeroHP += possible_to_addHP;
                    HeroMP = 0;
                }
            }
        }
        public override string ToString() //возвращает строку - характеристика
        {
            return String.Format("Имя героя: {0}\nСостояние: {1}\nРаса: {2}\nПол: {3}\nВозраст: {4}\nТекущее здоровье: {5}\nТекущий опыт: {6}\nТекущая мана: {7}\n", new object[] { Name, HeroState.ToString(), HeroRace.ToString(), HeroGender.ToString(), Age.ToString(), HeroHP.ToString(), HeroXP.ToString(), HeroMP.ToString() });
        }
        public List<Spell> SpellList { get; set; } //перечень заклинаний, которыми владеет маг
        public void LearnSpell(Spell spell) //выучить заклинание
        {
            if (!SpellList.Contains(spell))
                SpellList.Add(spell);
        }
        public void ForgetSpell(Spell spell) //забыть заклинание
        {
            if (SpellList.Contains(spell))
                SpellList.Remove(spell);
        }
        public void SaySpell(Spell spell) //перегруженные методы "произнести заклинание"
        {
            if (SpellList.Contains(spell))
                spell.SaySpell();
        }
        public void SaySpell(Spell spell, int power)
        {
            if (SpellList.Contains(spell))
                spell.SaySpell(this, power);
        }
        public void SaySpell(Hero hero, Spell spell)
        {
            if (SpellList.Contains(spell))
                spell.SaySpell(hero);
        }
        public void SaySpell(Hero hero, Spell spell, int power)
        {
            if (SpellList.Contains(spell))
                spell.SaySpell(hero, power);
        }
        public void BattleInfo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Здоровье: {0}/{1}", HeroHP, MaxHP);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Мана: {0}/{1}", HeroMP, MaxMP);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Текущее состояние: " + HeroState.ToString());
            Console.Write("Персонаж отравлен - ");
            if (IsPoisoned)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Да (урон от яда " + dampoison + ")");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
                Console.WriteLine("Нет");
            Console.Write("Персонаж парализован - ");
            if (IsParalyzed)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Да");
            }
            else
                Console.WriteLine("Нет");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void BattleInfo(MagicHero enemy)
        {
            int o = 80;
            Console.Write("Герой: " + Name); Console.CursorLeft = Console.BufferWidth - o; Console.Write("Герой: " + enemy.Name);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Здоровье: {0}/{1}", HeroHP, MaxHP); Console.CursorLeft = Console.BufferWidth - o;
            Console.Write("Здоровье: {0}/{1}", enemy.HeroHP, enemy.MaxHP);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Мана: {0}/{1}", HeroMP, MaxMP); Console.CursorLeft = Console.BufferWidth - o;
            Console.Write("Мана: {0}/{1}", enemy.HeroMP, enemy.MaxMP);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Текущее состояние: " + HeroState.ToString()); Console.CursorLeft = Console.BufferWidth - o;
            Console.Write("Текущее состояние: " + enemy.HeroState.ToString());
            Console.WriteLine();
            Console.Write("Персонаж отравлен - ");
            if (IsPoisoned)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Да (урон от яда " + dampoison + ")");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
                Console.Write("Нет");
            Console.CursorLeft = Console.BufferWidth - o;
            Console.Write("Персонаж отравлен - ");
            if (enemy.IsPoisoned)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Да (урон от яда " + enemy.dampoison + ")");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
                Console.Write("Нет");
            Console.WriteLine();
            Console.Write("Персонаж парализован - ");
            if (IsParalyzed)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Да");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
                Console.Write("Нет");
            Console.CursorLeft = Console.BufferWidth - o;
            Console.Write("Персонаж отравлен - ");
            if (enemy.IsParalyzed)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Да");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
                Console.Write("Нет");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
