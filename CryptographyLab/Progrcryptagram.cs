using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Cryptagr1
{
    public class ElGamal
    {
        private static Random _random;
        private const int ByteLength = 768 / 8;

        public static bool IsCorrect(BigInteger p, BigInteger g, BigInteger m, BigInteger e, BigInteger r, BigInteger s)
        {
            BigInteger g1 = BigInteger.ModPow(g, m, p);
            BigInteger g2 = BigInteger.ModPow(BigInteger.ModPow(e, r, p) * (BigInteger.ModPow(r, s, p)), 1, p);
            return g1 == g2;
        }

        public static BigInteger[] Subscribe(BigInteger p, BigInteger q, BigInteger g, BigInteger k, BigInteger m, BigInteger d)
        {
            BigInteger r = BigInteger.ModPow(g, k, p);
            BigInteger s = Inverse(k, q) * (m - (d * r)) % q;
            s = s < 0 ? s + q : s;
            return new BigInteger[] { r, s };
        }

        public static void Generate(BigInteger hash, BigInteger hash2)
        {
            _random = new Random();
            BigInteger q = RandomIntegerFromNumBits(ByteLength);
            while (Math.Abs(MillerRabin(++q)) < 0.5) { }
            BigInteger mn = RandomIntegerFromNumBits(ByteLength / 2) * 2;
            BigInteger p = RandomIntegerFromNumBits(ByteLength);

            while (MillerRabin(p) < 0.5)
            {
                mn = RandomIntegerFromNumBits(6) * 2;
                p = q * mn + 1;
            }

            //порядок g = q
            BigInteger g = BigInteger.ModPow(RandomIntegerBelow(q), mn, p);
            while (g == 1)
            {
                g = BigInteger.ModPow(RandomIntegerBelow(q), mn, p);
            }

            BigInteger x = RandomIntegerBelow(q);
            BigInteger y = BigInteger.ModPow(g, x, p);

            //HASH
            BigInteger k = RandomIntegerBelow(q);
            BigInteger[] rs = Subscribe(p, q, g, k, hash, x);
            Console.WriteLine("P: " + p + "\nG: " + q + "\nY: " + y);
            Console.WriteLine("R: " + rs[0] + "\nS: " + rs[1]);
            Console.WriteLine("Verification of a signature: " + IsCorrect(p, g, hash2, y, rs[0], rs[1]));
        }

        private static BigInteger RandomIntegerBelow(BigInteger n)
        {
            byte[] bytes = n.ToByteArray();
            BigInteger r;
            do
            {
                _random.NextBytes(bytes);
                bytes[bytes.Length - 1] &= (byte)0x7F;
                r = new BigInteger(bytes);
            } while (r > n);

            return r;
        }

        private static BigInteger RandomIntegerFromNumBits(int num)
        {
            var bytes = new byte[num];
            _random.NextBytes(bytes);
            bytes[bytes.Length - 1] &= (byte)0x7F;
            var R = new BigInteger(bytes);
            return R;
        }

        private static BigInteger Inverse(BigInteger modulus, BigInteger n)
        {
            var a = modulus;
            BigInteger b = n, x = 0, d = 1;
            while (a != 0)
            {
                var q = b / a;
                var y = a;
                a = b % a;
                b = y;
                y = d;
                d = x - q * d;
                x = y;
            }

            x = x % n;

            if (x < 0)
            {
                x = (x + n) % n;
            }
            return x;
        }
        public static BigInteger RandomLessThan(BigInteger x)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            BigInteger a = new BigInteger(r.Next());
            return (BigInteger.Remainder(a, (x - 2)) + 2);
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
    }
}