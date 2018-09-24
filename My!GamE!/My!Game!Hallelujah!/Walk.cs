using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Of_The_Year
{
    class Walk_Hero
    {
        //-----------настройка карты и консоли------------------------------
        static System.Media.SoundPlayer a = new System.Media.SoundPlayer(@"map.wav");
        static System.Media.SoundPlayer b = new System.Media.SoundPlayer(@"battle.wav");
        static System.Media.SoundPlayer c = new System.Media.SoundPlayer(@"respect.wav");

        static char[] borders;
        static char player = '☺';
        static char fog = '░';
        static char backgroung = ' ';
        static int visionRange = 16;
        static ConsoleColor backGroundConsoleColor = ConsoleColor.DarkCyan;
        static ConsoleColor fontConsoleColor = ConsoleColor.Red;
        static public void Battle(MagicHero one, MagicHero two)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            a.Stop();
            b.Play();
            bool run = false;
            bool deadik = false;
            bool turnover = false;
            string information = "";
            char action;
            while ((!run) && (!deadik))
            {
                turnover = false;
                while (!turnover)
                {
                    Console.Clear();
                    Battleinformation(one, two);
                    if (one.HeroState == State.Paralyzed)
                    {
                        Console.WriteLine("Вы в стане");
                        //pressbutton();
                        turnover = true;
                        continue;
                    }
                    offerturn(one);
                    action = (char)Console.ReadKey(true).Key;
                    switch (action)
                    {
                        case '1': information = "Вы нанесли противнику " + SimpleAttack(one, two) + " урона"; turnover = true; break;//удар с руки
                        case '2': turnover = OpenMagicBook(one, two); if (turnover) information = "Вы успешно прокастили что-то"; break;//открыть книжку заклинаний
                        case '3': turnover = OpenInventory(one, two); if (turnover) information = "Вы успешно юзнули что-то"; break;//открыть инвентарь
                        case '4':
                            SimpleAttack(two, one);
                            information = "Вы пытаетесь бежать";
                            if (one.HeroState == State.Paralyzed)
                            {
                                information = "Вас застанили. Не получилось убежать";
                                turnover = true;
                                break;
                            }
                            run = true; turnover = true; break;//попытка отступить
                        case 'Z': turnover = true; break;
                        default:
                            //Console.Beep();
                            break;
                    }
                    Console.Clear();
                    Battleinformation(one, two);
                    Console.WriteLine();
                    Console.WriteLine(information);
                }
                Console.WriteLine("Ваш ход завершен.");
                pressbutton();
                Console.Clear();
                one.afterturn();
                if (!((int)two.HeroState == 6))
                {
                    Console.WriteLine("Ход противника!");//Ход компа
                    if (!(two.HeroState == State.Paralyzed))
                    {
                        Console.WriteLine("Противник нанес вам " + SimpleAttack(two, one) + " урона");
                    }
                    else
                    {
                        Console.WriteLine("Противник в стане");
                    }
                    two.afterturn();
                }
                else
                    Console.WriteLine("Противник уничтожен");
                pressbutton();
                if (((int)one.HeroState == 6) || ((int)two.HeroState == 6))
                    deadik = true;
            }
            Console.Clear();
            if (run)
            {
                Console.WriteLine("Вы убежали от врага.");
                b.Stop();
                a.Play();
            }
            else
            {
                if ((int)one.HeroState == 6)
                {
                    Console.WriteLine("Вас кокнули.");
                    b.Stop();
                    //call досвидания
                }
                if ((int)two.HeroState == 6)
                {
                    FinishBattle(one, two);
                    //a.Stop();
                    //a.Dispose();
                    //c.Play();
                    //System.Threading.Thread.Sleep(5000);
                    //call battlenagrads
                }
            }
            //c.Play();
        }
        //_______
        static public int SimpleAttack(MagicHero attacker, MagicHero defencer)
        {
            int a, b;
            b = defencer.HeroHP;
            attacker.HeroAttack.Attack(defencer);
            a = defencer.HeroHP;
            return b - a;
        }
        static public bool OpenMagicBook(MagicHero hero, MagicHero enemy)
        {
            string readed;
            int pow = 0;
            char spell = 'z', target = 'z';
            MagicHero OW = hero;
            bool wascasted = false, nothingdone = true, rightmana = false;
            BS:
            while (nothingdone)
            {
                Console.Clear();
                Console.WriteLine("Ваша книга заклинаний:"); Console.WriteLine();
                Console.WriteLine("Закрыть книгу" + " - " + 0);
                int k = hero.SpellList.Count;
                for (int i = 0; i < k; i++)
                {
                    Console.WriteLine(hero.SpellList[i] + " - " + (i + 1));
                }
                while ((spell < 48) || (spell >= 49 + k))
                {
                    spell = (char)Console.ReadKey(true).Key;
                }
                if (!(spell == '0'))
                {
                    Console.WriteLine(); Console.WriteLine("Маны " + hero.HeroMP);
                    if (hero.HeroMP < hero.SpellList[spell - 49].MinMP)
                    {
                        Console.WriteLine("Вам не хватает маны");
                        spell = 'z';
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Выберите цель заклинания. 0-чтобы вернуться");
                        Console.WriteLine("1-" + hero.Name);
                        Console.WriteLine("2-" + enemy.Name);
                        while ((target < 48) || (target >= 51))
                        {
                            target = (char)Console.ReadKey(true).Key;
                        }
                        switch (target)
                        {
                            case '0': target = 'z'; spell = 'z'; goto BS;
                            case '1': OW = hero; break;
                            case '2': OW = enemy; break;
                            default: break;
                        }
                        if (!hero.SpellList[spell - 49].Ispoweroptioned)
                        {
                            hero.SaySpell(OW, hero.SpellList[spell - 49]);
                            nothingdone = false;
                            wascasted = true;
                        }
                        else
                        {
                            Console.WriteLine(); Console.WriteLine("Введите силу заклинания. Неположительное число, чтобы вернуться");
                            while (!rightmana)
                            {
                                readed = Console.ReadLine();
                                rightmana = Int32.TryParse(readed, out pow);
                                if (rightmana)
                                {
                                    if (pow > 0)
                                    {
                                        hero.SaySpell(OW, hero.SpellList[spell - 49], pow);
                                        nothingdone = false;
                                        wascasted = true;
                                    }
                                    else
                                    {
                                        spell = 'z';
                                        target = 'z';
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Нужно ввести число!");
                                    //Console.ReadKey();
                                }
                            }
                        }
                    }
                    rightmana = false;
                }
                else
                {
                    nothingdone = false;
                }
            }
            return wascasted;
        }
        static public bool OpenInventory(MagicHero hero, MagicHero enemy)
        {
            string readed;
            char artefact = 'z', target = 'z';
            MagicHero OW = hero;
            bool wascasted = false, nothingdone = true, rightpower = false;
            int pow;
            BA:
            while (nothingdone)
            {
                Console.Clear();
                Console.WriteLine("Ваш инвентарь:"); Console.WriteLine();
                Console.WriteLine("Закрыть инвентарь" + " - " + 0);
                int k = hero.Inventory.Count;
                for (int i = 0; i < k; i++)
                {
                    Console.WriteLine(hero.Inventory[i] + " - " + (i + 1));
                }
                while ((artefact < 48) || (artefact >= 49 + k))
                {
                    artefact = (char)Console.ReadKey(true).Key;
                }
                if (!(artefact == '0'))
                {
                    Console.WriteLine("Сила артефакта " + hero.HeroMP);
                    if (hero.Inventory[artefact - 49].Power == 0)
                    {
                        Console.WriteLine("Сила артефакта закончилась");
                        artefact = 'z';
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Выберите цель заклинания. 0-чтобы вернуться");
                        Console.WriteLine("1-" + hero.Name);
                        Console.WriteLine("2-" + enemy.Name);
                        while ((target < 48) || (target >= 51))
                        {
                            target = (char)Console.ReadKey(true).Key;
                        }
                        switch (target)
                        {
                            case '0': target = 'z'; artefact = 'z'; goto BA;
                            case '1': OW = hero; break;
                            case '2': OW = enemy; break;
                            default: break;
                        }
                        if (!hero.Inventory[artefact - 49].Ispoweroptioned)
                        {
                            hero.UseArtefact(hero.Inventory[artefact - 49], OW);
                            nothingdone = false;
                            wascasted = true;
                        }
                        else
                        {
                            Console.WriteLine("Введите заряд артефакта. Неположительное число, чтобы вернуться");
                            while (!rightpower)
                            {
                                readed = Console.ReadLine();
                                rightpower = Int32.TryParse(readed, out pow);
                                if (rightpower)
                                {
                                    if (pow > 0)
                                    {
                                        hero.UseArtefact(hero.Inventory[artefact - 49], OW, pow);
                                        nothingdone = false;
                                        wascasted = true;
                                    }
                                    else
                                    {
                                        artefact = 'z';
                                        target = 'z';
                                    }
                                }
                                else
                                    Console.WriteLine("Нужно ввести число!");
                            }
                        }
                    }
                    rightpower = false;
                }
                else
                {
                    nothingdone = false;
                }
            }
            return wascasted;
        }
        static public void FinishBattle(MagicHero winner, MagicHero notwinner)
        {
            b.Stop();
            c.Play();
            Console.Clear();
            Console.WriteLine("Вы отличились в бою и победили!");
            uint XP = (uint)Math.Abs(notwinner.MaxHP / 10);
            winner.HeroXP += XP;
            //a.Stop();
            //a.Dispose();
            //c.Play();
            Console.WriteLine("Вы получили " + XP + " опыта");
            System.Threading.Thread.Sleep(5000);
            pressbutton();
            a.Play();
        }
        static public void Battleinformation(MagicHero one, MagicHero two)
        {
            //Console.WriteLine("Вы:");
            //one.BattleInfo();
            //Console.WriteLine();
            //Console.WriteLine("Противник:");
            //two.BattleInfo();
            //Console.WriteLine();
            one.BattleInfo(two);
        }
        static public void pressbutton()
        {
            Console.WriteLine();
            Console.WriteLine("Нажмите клавишу для продолжения...");
            Console.ReadKey(true);
        }
        static public void offerturn(MagicHero one)
        {
            Console.WriteLine();
            Console.WriteLine("Ваш ход");//Ход игрока
            Console.WriteLine("1-тычка с руки. Урон-" + one.HeroAttack.damage);
            Console.WriteLine("2-открыть книгу заклинаний");
            Console.WriteLine("3-открыть инвентарь");
            Console.WriteLine("4-бежать");
        }
        //------------------------------------------------------------------

        //-_____________________________________________________________________________________________
        struct Point
        {
            public int x;
            public int y;
        }

        struct thing
        {
            public int x;
            public int y;
            public char thingSymbol;
            public ConsoleColor backGroungColor;
            public ConsoleColor thingColor;
            public object obj;
        }                                           //структура объекта взаимодействия

        class Gold
        {
            public int Value { get; set; }
            public Gold(int val)
            {
                Value = val;
            }

        };                                              //gOLG object



        static int X;                                              //размер карты
        static int Y;                                              //размер карты
        static char[,] map;                                        //карта
        static bool[,] vision;                                     //туман войны
        static List<thing> things = new List<thing>();             //обЪекты взаимодействия
        static bool dirtyArea;
        //____________________________________________________________________________________________________
        static void drawMap(Point player)
        {
            Console.BackgroundColor = backGroundConsoleColor;
            Console.ForegroundColor = fontConsoleColor;

            for (int i = 0; i < Y; i++)
            {
                string s = "";
                Console.SetCursorPosition(0, i);
                for (int j = 0; j < X; j++)
                {
                    if ((((j - player.x) * (j - player.x) + (i - player.y) * (i - player.y)) <= visionRange) || vision[j, i])
                    {
                        s += map[j, i].ToString();
                        vision[j, i] = true;
                    }
                    else
                        s += fog.ToString();
                }
                Console.WriteLine(s);

            }

            DrawNPC();
        }      //прорисовка карты с игроком и инфой
        static bool is_border(int x, int y)
        {
            foreach (char b in borders)
                if (map[x, y] == b)
                    return false;
            return true;
        }                     //чек на границу

        static int is_near_thing(Point player)
        {
            foreach (thing T in things)
                if (Math.Abs(player.x - T.x) < 2 && Math.Abs(player.y - T.y) < 2)
                    return things.IndexOf(T);
            return -1;
        }
        static int is_on_thing(Point player)
        {
            foreach (thing T in things)
                if (player.x == T.x && player.y == T.y)
                    return things.IndexOf(T);
            return -1;
        }

        static Point previousPosition;

        static thing Walk_Interface(Point start_position)
        {
            Point player_position = start_position;
            //---------------------------------------------------------
            map[player_position.x, player_position.y] = player;
            drawMap(start_position);
            //---------------------------------------------------------
            ConsoleKeyInfo k;
            int cmp;
            do
            {
                k = Console.ReadKey(true);
                previousPosition = player_position;

                int dx = 0, dy = 0;
                if (k.Key == ConsoleKey.LeftArrow && is_border(player_position.x - 1, player_position.y)) dx = -1;
                else
                if (k.Key == ConsoleKey.RightArrow && is_border(player_position.x + 1, player_position.y)) dx = +1;
                else
                if (k.Key == ConsoleKey.UpArrow && is_border(player_position.x, player_position.y - 1)) dy = -1;
                else
                if (k.Key == ConsoleKey.DownArrow && is_border(player_position.x, player_position.y + 1)) dy = +1;

                map[player_position.x, player_position.y] = backgroung;
                map[player_position.x + dx, player_position.y + dy] = player;
                player_position.x += dx; player_position.y += dy;

                print_Thing_Information(is_near_thing(player_position));

                drawMap(player_position);
                cmp = is_on_thing(player_position);
            }
            while (cmp == -1);
            map[player_position.x, player_position.y] = backgroung;
            return things[cmp];
        }                       //цикл хождения по карте

        static void DrawNPC()
        {
            foreach (thing n in things)
                if (vision[n.x, n.y])
                {
                    Console.ForegroundColor = n.thingColor;
                    Console.BackgroundColor = n.backGroungColor;
                    Console.SetCursorPosition(n.x, n.y);
                    Console.Write(n.thingSymbol);
                }
        }                                   //прорисовка объектов взаимодействия

        static void initialize()
        {
            Console.SetWindowSize(140, 70);
            Console.SetBufferSize(140, 70);
            Console.CursorVisible = false;
            for (int i = 0; i < Y; i++)
                for (int j = 0; j < X; j++)
                    vision[j, i] = false;


        }                                //инициализация элементов

        static void loadMap(string adress)
        {
            string[] input = System.IO.File.ReadAllLines(adress);
            string[] coords = input[0].Split(' ');
            X = int.Parse(coords[0]);
            Y = int.Parse(coords[1]);

            map = new char[X, Y];
            vision = new bool[X, Y];

            int things_description = 0;
            thing T = new thing();
            for (int y = 0; y < Y; y++)
                for (int x = 0; x < X; x++)
                {
                    if (input[y + 1][x] == 'T')                                             ///описание плюшек
                    {
                        things_description++;
                        map[x, y] = backgroung;
                        T.x = x;
                        T.y = y;

                        MagicHero mob = new MagicHero("MOBIK", Race.Goblin, Gender.Male);
                        mob.HeroAttack.damage = 10;
                        mob.HeroAttack.stan = 0.3;
                        mob.HeroAttack.poiso = 0.2;
                        mob.HeroAttack.poisondamage = 10;

                        if (things_description == 2) {
                            T.thingColor = ConsoleColor.Red;
                            T.thingSymbol = 'M';
                            T.obj = mob;
                            T.backGroungColor = backGroundConsoleColor;
                        }
                        else
                            if (things_description == 1)
                        {
                            Gold g = new Gold(100);
                            T.thingColor = ConsoleColor.Yellow;
                            T.backGroungColor = backGroundConsoleColor;
                            T.thingSymbol = 'G';
                            T.obj = g;
                        }
                        else
                            if (things_description == 3)
                        {

                            LightningStick s = new LightningStick(mob, 100);
                            mob.PickUpArtefact(s);
                            mob.PassArtefact(mob, s);
                        }

                        things.Add(T);
                    }
                    else
                    {
                        map[x, y] = input[y + 1][x];
                    }
                }


            string[] bdr = input[Y + 1].Split(' ');
            borders = new char[bdr.Count()];
            for (int i = 0; i < bdr.Count(); i++)
                borders[i] = bdr[i][0];
        }                      //загрузка карты из файла

        static void print_Thing_Information(int indexOfThing)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            if (dirtyArea == true && indexOfThing == -1)
            {

                for (int i = 0; i < 15; i++)
                {
                    Console.SetCursorPosition(X+5, Y+3+i);
                    Console.WriteLine("                                      ");

                }
                dirtyArea = false;
            }
            else
            if (indexOfThing != -1)
            {
                dirtyArea = true;
                if (things[indexOfThing].obj is Gold)
                {
                    Console.SetCursorPosition(X + 5, Y + 3);
                    Console.WriteLine("+{0} золотых монет", (things[indexOfThing].obj as Gold).Value);
                }
                else
                    if (things[indexOfThing].obj is Hero)
                {
                    string[] Hero_Information = (things[indexOfThing].obj as Hero).ToString().Split('\n');
                    for (int i = 0; i < Hero_Information.Count(); i++)
                    {
                        Console.SetCursorPosition(X + 5, i+Y+3);
                        Console.WriteLine(Hero_Information[i]);
                    }
                }
                else
                    if (things[indexOfThing].obj is Artefact)
                {
                    string[] Artefact_Information = (things[indexOfThing].obj as Artefact).ToString().Split('\n');
                    for (int i = 0; i < Artefact_Information.Count(); i++)
                    {
                        Console.SetCursorPosition(X + 5, i + Y + 3);
                        Console.WriteLine(Artefact_Information[i]);
                    }
                }
            }

            

        }

        static void print_Hero_Infomation(Hero H)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            string[] Hero_Information = H.ToString().Split('\n');
            for (int i = 0; i < Hero_Information.Count(); i++)
            {
                Console.SetCursorPosition(X + 5, i);
                Console.WriteLine(Hero_Information[i]);
            }
        }

        static void draw_krasotu ()
        {
            // 70 140
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            for (int i = 0; i < 70; i++)
            {
                Console.SetCursorPosition(X + 2, i);
                Console.Write('║');
            }
            for (int i = 0; i < 140; i++)
            {
                Console.SetCursorPosition(i, Y+1);
                Console.Write('═');
            }
            Console.SetCursorPosition(X+2, Y + 1);
            Console.Write('╬');



            Console.SetCursorPosition(1, Y + 3);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Легенда карты (Совсем легенда)");

            Console.SetCursorPosition(1, Y+6);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write('G');
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write(" - золото");

            Console.SetCursorPosition(1, Y + 8);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write('M');
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write(" - вражеские npc(Красный - опасный, Зеленый не очень)");

            Console.SetCursorPosition(1, Y + 10);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write('A');
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write(" - артефакты");








        }
        static void Main(string[] args)
        {
            MagicHero elf = new MagicHero("cutja1", Race.Elf, Gender.Male);
            elf.MaxHP = 500;
            elf.HeroHP = elf.MaxHP;

            AddHP Heal1 = new AddHP(elf);
            Antidote Antidote = new Antidote(elf);
            Armor Armor = new Armor(elf);
            Unfreeze Unfreeze = new Unfreeze(elf);

            LightningStick lightning_stick = new LightningStick(elf, 20);
            LivingWaterBottle50 LivingWaterBottle50 = new LivingWaterBottle50(elf);
            DeadWaterBottle10 DeadWaterBottle10 = new DeadWaterBottle10(elf);
            FrogLegs FrogLegs = new FrogLegs(elf, 5);
            PoisonousSaliva PoisonousSaliva = new PoisonousSaliva(elf, 9);
            BasiliskEye BasiliskEye = new BasiliskEye(elf, 5);

            elf.PickUpArtefact(lightning_stick);
            elf.PickUpArtefact(LivingWaterBottle50);
            elf.PickUpArtefact(DeadWaterBottle10);
            elf.PickUpArtefact(FrogLegs);
            elf.PickUpArtefact(PoisonousSaliva);
            elf.PickUpArtefact(BasiliskEye);

            elf.LearnSpell(Armor);
            elf.LearnSpell(Unfreeze);
            elf.LearnSpell(Antidote);
            elf.LearnSpell(Heal1);

            loadMap("IN.txt");
            
            initialize();
            Point P = new Point();
            P.x = 1;
            P.y = 1;
            a.Play();

            do
            {
                draw_krasotu();
                print_Hero_Infomation(elf);
                thing T = Walk_Interface(P);
                if (T.obj is Gold)
                {
                    //                    elf.gold++
                    things.Remove(T);
                }
                else
                if (T.obj is Artefact)
                {
                    elf.PickUpArtefact(T.obj as Artefact);
                    things.Remove(T);
                }

                P.x = T.x;
                P.y = T.y;

                if (T.obj is MagicHero)
                {
                    Console.Clear();
                    Battle(elf, (T.obj as MagicHero));
                    if ((T.obj as MagicHero).HeroState == State.Dead)
                    {
                        things.Remove(T);// deistvie na pobedu
                    }
                    else
                    {
                        P = previousPosition;
                    }
                }

            }
            while (things.Count() != 0);
            Console.WriteLine("Вы прошли игру! Ставьте лайки подписывайтесь на наш канал!");
            Console.Read();
        }
    }
}
