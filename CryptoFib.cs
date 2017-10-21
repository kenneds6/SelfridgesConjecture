
using System.Numerics;
using System;

namespace CyrptoFibMatrix.CryptoAssignment3
{
    public class CryptoFib

    {
        public static bool isPrime(int number)
        {

            if (number == 1) return false;
            if (number == 2) return true;

            for (int i = 2; i <= Math.Ceiling(Math.Sqrt(number)); ++i)
            {
                if (number % i == 0) return false;
            }

            return true;

        }

        public static int [] GeneratePrimes()
        {

            //initialize variables
            int [] primes = new int[1000];
            int count = 0;
            int number = 2;

            //loop until the array is full
            while (count < 1000)
            {

                //if the number is prime
                if (isPrime(number))
                {

                    //add it to the array and increment the array index / prime count
                    primes[count] = number;
                    count++;
                }

                //increment the number being checked
                number++;
            }
            return primes;
        }
        public static BigInteger fermatTest(BigInteger p)
        {
            BigInteger two = BigInteger.Parse("2");
            bool pass = false;
            int k = 0;


            //BigInteger newP = BigInteger.Parse("0");
            //newP = p;

            while (!pass)
            {
                int [] primes = GeneratePrimes();

                if (BigInteger.ModPow(two, p - 1, p) != 1)
                {

                    k++;
                    p = p + 2;

                }
                else
                {
                    pass = true;
                    
                }
            }
            System.Console.WriteLine(k);// For Testing
            return p;
        }


        public static BigInteger FibMod(BigInteger M, BigInteger P)
        {
            if (M == 0) return 0;
            if (M == 1) return 0;
            var m = new MatrixFib(1, 1, 1, 0);
            m = m.MatrixPowerMod(M - 1, P);
            return m.Result();
        }

        public static int kFib(BigInteger M, BigInteger P)
        {
            BigInteger m = M;
            BigInteger p = P;
            bool pass = false;
            int k = 0;
            int tenK = k * 10;

            while (pass != true)
            {
                if (FibMod(m, p) != 0)
                {
                    k++;
                    //tenK = k * 10;
                    p = p + 10;
                    m = m + 10;
                }
                else
                {
                    pass = true;     
                }
            }
        
            //System.Console.WriteLine(p);//for testing
            return k;           
            
        }

        static void Main(string[] args)
        {

            BigInteger p = BigInteger.Parse("2074720549658310084416732550087");
            BigInteger two = BigInteger.Parse("2");

            //int fibK = kFib(pp1,p);
            //BigInteger pp1 = BigInteger.Parse("3624838065575969338652388");

            int[] primes = GeneratePrimes();
            int k = 0;
            bool pass = false;

            while (pass != true)
            {
                pass = true;
                for (int i = 0; i < 1000; i++)
                {
                    if ((p % primes[i]) == 0)
                    {
                        pass = false;
                    }
 
                }

                if (pass == false)
                {
                    System.Console.WriteLine("Prime Division Test Failed....");
                    p = p + 10;
                    k++;
                    continue;

                }
                if (pass == true)
                {
                    System.Console.WriteLine("Prime Division Test Passed");
                }
                if (BigInteger.ModPow(two, p - 1, p) != 1)
                {
                    System.Console.WriteLine("Fermat Test Failed...");
                    p = p + 10;
                    k++;
                    pass = false;
                    continue;
                }
                else
                {
                    System.Console.WriteLine("Fermat Test Passed");
                    pass = true;
                }
                if (FibMod(p + 1, p) != 0)
                {
                    System.Console.WriteLine("Fibonacci Test Failed");
                    pass = false;
                    k++;
                    p = p + 10;
                    continue;
                }
                else
                {
                    System.Console.WriteLine("All Tests Passed");
                    pass = true;
                }
            }

            //System.Console.WriteLine(fibK);
            System.Console.WriteLine(k);
            System.Console.WriteLine(p);
        }
    

    }
}
