//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Game_Of_The_Year
//{
//    class Battle_Hero
//    {
//        public MagicHero one, two;
//        //System.Media.SoundPlayer a = new System.Media.SoundPlayer(@"C:\batb.wav");
//        //System.Media.SoundPlayer c = new System.Media.SoundPlayer(@"C:\mob.wav");
//        //a.Play();
//        //static void Main(string[] args)
//        //{
//        //    Console.WriteLine("Game Of The Year, beta v.0.0.1.2, All Rights Reserved");
//        //    MagicHero elf = new MagicHero("cutja1", Race.Elf, Gender.Male);
//        //    elf.MaxHP = 10000;
//        //    elf.HeroHP = elf.MaxHP;
//        //    Console.WriteLine(elf);

//        //    AddHP Heal1=new AddHP(elf);
//        //    Antidote Antidote = new Antidote(elf);
//        //    Armor Armor = new Armor(elf);
//        //    Unfreeze Unfreeze = new Unfreeze(elf);

//        //    LightningStick lightning_stick = new LightningStick(elf, 20);
//        //    LivingWaterBottle50 LivingWaterBottle50 = new LivingWaterBottle50(elf);
//        //    DeadWaterBottle10 DeadWaterBottle10 = new DeadWaterBottle10(elf);
//        //    FrogLegs FrogLegs = new FrogLegs(elf, 5);
//        //    PoisonousSaliva PoisonousSaliva = new PoisonousSaliva(elf, 9);
//        //    BasiliskEye BasiliskEye = new BasiliskEye(elf, 5);

//        //    elf.PickUpArtefact(lightning_stick);
//        //    elf.PickUpArtefact(LivingWaterBottle50);
//        //    elf.PickUpArtefact(DeadWaterBottle10);
//        //    elf.PickUpArtefact(FrogLegs);
//        //    elf.PickUpArtefact(PoisonousSaliva);
//        //    elf.PickUpArtefact(BasiliskEye);

//        //    elf.LearnSpell(Armor);
//        //    elf.LearnSpell(Unfreeze);
//        //    elf.LearnSpell(Antidote);
//        //    elf.LearnSpell(Heal1);

//        //    MagicHero gik = new MagicHero("cutja2", Race.Elf, Gender.Female);
//        //    gik.HeroHP = 100;
//        //    gik.HeroAttack.stan = 0.3;
//        //    gik.HeroAttack.poiso = 0.2;
//        //    gik.HeroAttack.poisondamage = 4;
//        //    Console.WriteLine(gik);
//        //    AddHP Heal2 = new AddHP(gik);
//        //    gik.LearnSpell(Heal2);
//        //    Battle(elf, gik);
//        //}
//        static public void Battle (MagicHero one, MagicHero two)
//        {
//            //System.Media.SoundPlayer a = new System.Media.SoundPlayer(@"C:\batb.wav");
//            //System.Media.SoundPlayer c = new System.Media.SoundPlayer(@"C:\mob.wav");
//            //a.Play();
//            bool run = false;
//            bool deadik=false;
//            bool turnover = false;
//            string information="";
//            char action;
//            while ((!run)&&(!deadik))
//                {
//                    turnover = false;
//                    while (!turnover)
//                    {
//                        Console.Clear();
//                        Battleinformation(one, two);
//                        if (one.HeroState == State.Paralyzed)
//                        {
//                            Console.WriteLine("Вы в стане");
//                            //pressbutton();
//                            turnover = true;
//                            continue;
//                        }
//                        offerturn(one);
//                        action = (char)Console.ReadKey(true).Key;
//                        switch (action)
//                        {
//                            case '1': information="Вы нанесли противнику " + SimpleAttack(one, two) + " урона"; turnover = true; break;//удар с руки
//                            case '2': turnover = OpenMagicBook(one, two); if (turnover) information = "Вы успешно прокастили что-то"; break;//открыть книжку заклинаний
//                            case '3': turnover = OpenInventory(one, two); if (turnover) information = "Вы успешно юзнули что-то"; break;//открыть инвентарь
//                            case '4': SimpleAttack(two, one);
//                                information = "Вы пытаетесь бежать";
//                                if (one.HeroState == State.Paralyzed)
//                                {
//                                    information = "Вас застанили. Не получилось убежать";
//                                    break;
//                                }
//                                run = true; turnover = true; break;//попытка отступить
//                            case 'Z': turnover = true; break;
//                            default:
//                                //Console.Beep();
//                                break;
//                        }
//                        Console.Clear();
//                        Battleinformation(one, two);
//                        Console.WriteLine(information);
//                    }
//                    one.afterturn();
//                    Console.WriteLine("Ваш ход завершен.");
//                    pressbutton();
//                    Console.Clear();
//                    Console.WriteLine("Ход противника!");//Ход компа
//                    if (!((int)two.HeroState==6))
//                    {
//                        if (!(two.HeroState == State.Paralyzed))
//                        {
//                            Console.WriteLine("Противник нанес вам " + SimpleAttack(two, one) + " урона");
//                        }
//                        else
//                        {
//                            Console.WriteLine("Противник в стане");
//                        }
//                        two.afterturn();
//                    }
//                    pressbutton();
//                    if (((int)one.HeroState == 6) || ((int)two.HeroState == 6))
//                        deadik = true;
//                }
//            Console.Clear();
//            if (run)
//                Console.WriteLine("Вы убежали от врага.");
//            else
//            {
//                if ((int)one.HeroState == 6)
//                {
//                    Console.WriteLine("Вас кокнули.");
//                    //call endgame
//                }
//                if ((int)two.HeroState == 6)
//                {

//                    Console.WriteLine("Вы отличились в бою и победили!");
//                    FinishBattle(one, two);
//                    //a.Stop();
//                    //a.Dispose();
//                    //c.Play();
//                    //System.Threading.Thread.Sleep(5000);
//                    //call battlenagrads
//                }
//            }
//            //c.Play();
//        }
        
//        static public int SimpleAttack (MagicHero attacker, MagicHero defencer)
//        {
//            int a, b;
//            b = defencer.HeroHP;
//            attacker.HeroAttack.Attack(defencer);
//            a = defencer.HeroHP;
//            return b - a;
//        }
//        static public bool OpenMagicBook(MagicHero hero, MagicHero enemy)
//        {
//            string readed;
//            int pow=0;
//            char spell='z', target='z';
//            MagicHero OW=hero;
//            bool wascasted = false, nothingdone = true, rightmana=false;
//            BS:while (nothingdone)
//            {
//                Console.Clear();
//                Console.WriteLine("Ваша книга заклинаний:"); Console.WriteLine();
//                Console.WriteLine("Закрыть книгу" + " - " + 0);
//                int k = hero.SpellList.Count;
//                for (int i = 0; i < k; i++)
//                {
//                    Console.WriteLine(hero.SpellList[i] + " - " + (i + 1));
//                }
//                while ((spell < 48) || (spell >= 49 + k))
//                {
//                    spell = (char)Console.ReadKey(true).Key;
//                }
//                if (!(spell == '0'))
//                {
//                    Console.WriteLine(); Console.WriteLine("Маны " + hero.HeroMP);
//                    if (hero.HeroMP < hero.SpellList[spell - 49].MinMP)
//                    {
//                        Console.WriteLine("Вам не хватает маны");
//                        spell = 'z';
//                        Console.ReadKey();
//                    }
//                    else
//                    {
//                        Console.WriteLine("Выберите цель заклинания. 0-чтобы вернуться");
//                        Console.WriteLine("1-"+hero.Name);
//                        Console.WriteLine("2-"+enemy.Name);
//                        while ((target < 48) || (target >= 51))
//                        {
//                            target = (char)Console.ReadKey(true).Key;
//                        }
//                        switch (target)
//                        {
//                            case '0': target = 'z'; spell = 'z'; goto BS;
//                            case '1': OW = hero; break;
//                            case '2': OW = enemy; break;
//                            default: break;
//                        }
//                        if (!hero.SpellList[spell - 49].Ispoweroptioned)
//                        {
//                            hero.SaySpell(OW, hero.SpellList[spell - 49]);
//                            nothingdone = false;
//                            wascasted = true;
//                        }
//                        else
//                        {
//                            Console.WriteLine(); Console.WriteLine("Введите силу заклинания. Неположительное число, чтобы вернуться");
//                            while (!rightmana)
//                            {
//                                readed = Console.ReadLine();
//                                rightmana = Int32.TryParse(readed, out pow);
//                                if (rightmana)
//                                {
//                                    if (pow > 0)
//                                    {
//                                        hero.SaySpell(OW, hero.SpellList[spell - 49], pow);
//                                        nothingdone = false;
//                                        wascasted = true;
//                                    }
//                                    else
//                                    {
//                                        spell = 'z';
//                                        target = 'z';
//                                    }
//                                }
//                                else
//                                {
//                                    Console.WriteLine("Нужно ввести число!");
//                                    //Console.ReadKey();
//                                }
//                            }
//                        }  
//                    }
//                    rightmana = false;
//                }
//                else
//                {
//                    nothingdone = false;
//                }
//            }
//            return wascasted;
//        }
//        static public bool OpenInventory(MagicHero hero, MagicHero enemy)
//        {
//            string readed;
//            char artefact = 'z', target='z';
//            MagicHero OW = hero;
//            bool wascasted = false, nothingdone = true, rightpower = false;
//            int pow;
//            BA:while (nothingdone)
//            {
//                Console.Clear();
//                Console.WriteLine("Ваш инвентарь:"); Console.WriteLine();
//                Console.WriteLine("Закрыть инвентарь" + " - " + 0);
//                int k = hero.Inventory.Count;
//                for (int i = 0; i < k; i++)
//                {
//                    Console.WriteLine(hero.Inventory[i] + " - " + (i + 1));
//                }
//                while ((artefact < 48) || (artefact >= 49 + k))
//                {
//                    artefact = (char)Console.ReadKey(true).Key;
//                }
//                if (!(artefact == '0'))
//                {
//                    Console.WriteLine("Сила артефакта " + hero.HeroMP);
//                    if (hero.Inventory[artefact - 49].Power==0)
//                    {
//                        Console.WriteLine("Сила артефакта закончилась");
//                        artefact = 'z';
//                        Console.ReadKey();
//                    }
//                    else
//                    {
//                        Console.WriteLine("Выберите цель заклинания. 0-чтобы вернуться");
//                        Console.WriteLine("1-" + hero.Name);
//                        Console.WriteLine("2-" + enemy.Name);
//                        while ((target < 48) || (target >= 51))
//                        {
//                            target = (char)Console.ReadKey(true).Key;
//                        }
//                        switch (target)
//                        {
//                            case '0': target = 'z'; artefact = 'z'; goto BA;
//                            case '1': OW = hero; break;
//                            case '2': OW = enemy; break;
//                            default: break;
//                        }
//                        if (!hero.Inventory[artefact - 49].Ispoweroptioned)
//                        {
//                            hero.UseArtefact(hero.Inventory[artefact - 49], OW);
//                            nothingdone = false;
//                            wascasted = true;
//                        }
//                        else
//                        {
//                            Console.WriteLine("Введите заряд артефакта. Неположительное число, чтобы вернуться");
//                            while (!rightpower)
//                            {
//                                readed = Console.ReadLine();
//                                rightpower = Int32.TryParse(readed, out pow);
//                                if (rightpower)
//                                {
//                                    if (pow > 0)
//                                    {
//                                        hero.UseArtefact(hero.Inventory[artefact - 49], OW, pow);
//                                        nothingdone = false;
//                                        wascasted = true;
//                                    }
//                                    else
//                                    {
//                                        artefact = 'z';
//                                        target = 'z';
//                                    }
//                                }
//                                else
//                                    Console.WriteLine("Нужно ввести число!");
//                            }
//                        }
//                    }
//                    rightpower = false;
//                }
//                else
//                {
//                    nothingdone = false;
//                }
//            }
//            return wascasted;
//        }
//        static public void FinishBattle(MagicHero winner, MagicHero notwinner)
//        {
//            uint XP=(uint)Math.Abs(notwinner.MaxHP / 10);
//            winner.HeroXP += XP;
//            //a.Stop();
//            //a.Dispose();
//            //c.Play();
//            //System.Threading.Thread.Sleep(5000);
//            Console.WriteLine("Вы получили " + XP+" опыта");
//        }
//        static public void Battleinformation (MagicHero one, MagicHero two)
//        {
//            Console.WriteLine("Ваши хапэ - " + one.HeroHP);
//            Console.WriteLine("Ваша мана - " + one.HeroMP);
//            Console.WriteLine("Не ваши хапэ - " + two.HeroHP);
//            Console.WriteLine();
//        }
//        static public void pressbutton ()
//        {
//            Console.WriteLine();
//            Console.WriteLine("Нажмите клавишу для продолжения...");
//            Console.ReadKey(true);
//        }
//        static public void offerturn(MagicHero one)
//        {
//            Console.WriteLine();
//            Console.WriteLine("Ваш ход");//Ход игрока
//            Console.WriteLine("1-тычка с руки. Урон-" + one.HeroAttack.damage);
//            Console.WriteLine("2-открыть книгу заклинаний");
//            Console.WriteLine("3-открыть инвентарь");
//            Console.WriteLine("4-бежать");
//        }
//    }
//}
