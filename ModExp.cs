using System.Numerics;

namespace CyrptoFibMatrix.CryptoAssignment3
{

    public class ModExp
    {
        /// <summary>
        /// Computes x^n mod p
        /// </summary>
        /// <returns>k </returns>
        public static int powerMod(BigInteger p)
        {
            BigInteger two = BigInteger.Parse("2");            
            bool pass = false;            
            int k = 0;
            
            BigInteger newP = BigInteger.Parse("0");
            newP = p;
           
            while (!pass)
            {
                
                if (BigInteger.ModPow(two,newP - 1, newP) != 1)
                {

                    k = k++;
                    

                    newP = p + 2;

                }
                else
                {
                    pass = true;
                }
            }
            System.Console.WriteLine(newP);// For Testing
            return k;
        }

    }
}
