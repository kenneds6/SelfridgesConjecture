using System.Numerics;

namespace CyrptoFibMatrix.CryptoAssignment3
{
    public class MatrixFib
    {
        private BigInteger c1, c2, c3, c4;

        public MatrixFib(BigInteger C1, BigInteger C2, BigInteger C3, BigInteger C4)
        {
            c1 = C1;
            c2 = C2;
            c3 = C3;
            c4 = C4;
        }

        public MatrixFib()
        {
        }

        public MatrixFib Multiply(MatrixFib x)
        {
            var res = new MatrixFib();

            var i = x.c1;
            var j = x.c2;

            res.c1 = c1 * i + c3 * j;
            res.c2 = c2 * i + c4 * j;

            i = x.c3;
            j = x.c4;

            res.c3 = c1 * i + c3 * j;
            res.c4 = c2 * i + c4 * j;

            return res;
        }
        public MatrixFib MatrixPower(BigInteger p)
        {
            if (p == 1) return this;
            if (p % 2 == 1)
            {
                var tmp = MatrixPower(p - 1);
                return this.Multiply(tmp);
            }
            var res = MatrixPower(p / 2);
            return res.Multiply(res);
        }

        public MatrixFib MatrixPowerMod(BigInteger p, BigInteger m)
        {
            if (p == 1) return this;
            if (p % 2 == 1)
            {
                var tmp = MatrixPowerMod(p - 1, m);
                return this.MultiplyMod(tmp, m);
            }
            var res = MatrixPowerMod(p / 2, m);
            return res.MultiplyMod(res, m);
        }

        public MatrixFib MultiplyMod(MatrixFib v, BigInteger divisor)
        {
            var res = new MatrixFib();
            var i = v.c1;
            var j = v.c2;
            res.c1 = (c1 * i + c3 * j) % divisor;
            res.c2 = (c2 * i + c4 * j) % divisor;
            i = v.c3;
            j = v.c4;
            res.c3 = (c1 * i + c3 * j) % divisor;
            res.c4 = (c2 * i + c4 * j) % divisor;
            return res;
        }

        public BigInteger Result()
        {
            return c1;
        }
    }
}
