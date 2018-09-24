using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.IO;
namespace Cryptagr1
{
    class Program
    {
        static void Main(string[] args)
        {
            //FileStream file1 = new FileStream("Hash.txt", FileMode.Open); //создаем файловый поток
            //StreamReader reader = new StreamReader(file1); // создаем «потоковый читатель» и связываем его с файловым потоком
            //FileStream file2 = new FileStream("Hash2.txt", FileMode.Open); //создаем файловый поток
            //StreamReader reader2 = new StreamReader(file2); // создаем «потоковый читатель» и связываем его с файловым потоком
            //string blabla = reader.ReadLine();
            //long n = long.Parse(blabla);
            //BigInteger writtenHash = n;
            //blabla = reader2.ReadLine();
            //n = long.Parse(blabla);
            //BigInteger readHash = n;
            ////readHash = writtenHash;
            //ElGamal.Generate(writtenHash, readHash);
            ElepticParams elpar;
            elpar = elepticCurve(5);
            if (checkElepticCurve(elpar, 5))
                Console.WriteLine("Yeah");
            else
                Console.WriteLine("No");
            //elpar.a = a;
            //elpar.p = p;
            //elpar.G = G;
            //elpar.q = q;
            //elpar.b = b;
        }
        public struct Point
        {
            public BigInteger x;
            public BigInteger y;
            bool nul;
        };
        public struct ElepticParams
        {
            public BigInteger p;
            public BigInteger a;
            public BigInteger b;
            public BigInteger q;
            public Point G;
        };
        static public ElepticParams elepticCurve(int l)
        {
            ElepticParams elpar = new ElepticParams();
            BigInteger p = new BigInteger(5);
            BigInteger x = new BigInteger();
            BigInteger y = new BigInteger();
            BigInteger a = new BigInteger(1);
            BigInteger b = new BigInteger(1);
            BigInteger q = new BigInteger(9);
            Point po=new Point();


            while (true)
            {
                p = getPrimeNumber(2 * l - 1);
                x = RandomLessThan(p);
                y = RandomLessThan(p);
                a = RandomLessThan(p);
                b = BigInteger.Pow(y, 2) - (BigInteger.Pow(x, 3) + a * x);
                b %= p;
                while (b < 0)
                    b += p;
                if (legandreSymbol(b, p) != 1)
                    continue;
                if ((4 * BigInteger.Pow(a, 3) + 27 * BigInteger.Pow(b, 2)) % p == 0)
                    continue;
                bool flag = false;
                q = new BigInteger(((long)p + 1 + 2 * Math.Sqrt((long)p)));

                for (int m = 1; m <= 50; m++)
                {
                    if (BigInteger.ModPow(p, m, q) == 1)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                    continue;
                break;
            }
            //cout << "Hello!" << endl;

            po.x = 0;
            po.y = BigInteger.ModPow(b, (p + 1) / 4, p);

            Point G = new Point();
            elpar.a = a;
            elpar.p = p;
            elpar.G = G;
            elpar.q = q;
            elpar.b = b;
            return elpar;
        }
        public static BigInteger RandomLessThan(BigInteger x)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            BigInteger a = new BigInteger(r.Next());
            return (BigInteger.Remainder(a, (x - 2)) + 2);
        }

        public static BigInteger getPrimeNumber(int l)
        {
            BigInteger p=new BigInteger();
            BigInteger lp=BigInteger.Pow(2, l);
            BigInteger rp = BigInteger.Pow(2, l+1);
            long k;
            Random a=new Random();
            while (true)
            {
                long t = long.MaxValue;
                double o = (double)(t);
                long prom = (long)(a.NextDouble() * o);
                long prom2 = (long)rp;
                k = prom % (prom2+1)+(long)lp;
                if (MillerRabin2(k)>0)
                {
                    if (k % 4 == 3 && k > lp && k < rp)
                        break;
                }
            }
            p = k;
            return p;
        }
        static int legandreSymbol(BigInteger u, BigInteger n)
        {
            BigInteger copyn = n;
            BigInteger copyu = u;

            int t = 1;

            while (copyn > 1)
            {
                if (copyu == 0)
                    return 0;
                if (copyu == 1)
                    return t;
                BigInteger r=copyu;
                long s = 0;
                while (true)
                {
                    if (r >> 1 << 1 == r)
                    {  //проверка на четность
                        s++;
                        r /= 2;
                    }
                    else
                        break;
                }

                if (s % 2 != 0)
                {
                    if (copyn % 8 == 3 || copyn % 8 == 5)
                        t = -t;
                }
                if (copyn % 4 == 3 && r % 4 == 3)
                    t = -t;
                copyu = n % r;
                copyn = r;
            }
            return t;
        }
        public static double MillerRabin(BigInteger x)
        {
            var t = x.ToByteArray().Length / 4;
            var d = x - 1;
            var s = 0;

            if (d % 2 == 0)
                while (d % 2 == 0)
                {
                    d /= 2;
                    s++;
                }

            for (var i = 0; i < t; i++)
            {
                var a = RandomLessThan(x);
                BigInteger r = 1;
                BigInteger mp = 0;
                mp = BigInteger.ModPow(a, d, x);
                if (mp == 1 || mp == x - 1)
                    continue;
                for (; r < s; r++)
                {
                    mp = BigInteger.ModPow(a, BigInteger.ModPow(2, r, x - 1) * d, x);
                    if (mp == x - 1)
                        break;
                }
                if (r < s)
                    continue;
                return 0;
            }
            return 1 - Math.Pow(0.25, t);
        }
        public static double MillerRabin2(BigInteger x)
        {
            double state = 1;
            long t = (long)x;
            for (int i = 2; i < t; i++)
                if (x % i == 0)
                    state = 0;
            return state;
        }
        public static bool checkElepticCurve(ElepticParams elpar, int l)
        {
            long bits = 2 * l - 1;
            BigInteger lp = BigInteger.Pow(2, 2 * l - 1);
            BigInteger rp = BigInteger.Pow(2, 2 * l);
            //1)
            if (!(lp < elpar.p && elpar.p < rp))
                return false;
            //2)
            if (MillerRabin2(elpar.p)==0)
                return false;
            //if (!TestMilleraRabina(elpar.q, bits / 2))
            //return false;
            //3)
            if (elpar.p % 4 != 3)
                return false;
            //4)
            if (elpar.p == elpar.q)
                return false;
            //5)
            for (int m = 1; m <= 50; m++)
            {
                if (BigInteger.ModPow(elpar.p, m, elpar.q) == 1)
                    return false;
            }
            //6)
            if ((4 * BigInteger.Pow(elpar.a, 3) + 27 * BigInteger.Pow(elpar.b, 2)
                ) % elpar.p == 0)
                return false;
            //7)
            if (legandreSymbol(elpar.b, elpar.p) != 1)
                return false;
            return true;
        }
    }

}
