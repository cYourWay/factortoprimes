using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerHelperFactorToPrimes
{
    class Program
    {
        //2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
        //What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?

        //known primes 
        //static int[] primes = { 2, 3, 5, 7, 11, 13, 17, 19 };
        static void Main(string[] args)
        {

            //test this step
            Console.Write("Enter number to factor:   ");

            long numToFactor = long.Parse(Console.ReadLine());
            List<long> lstPrimes = GetPrimes(numToFactor);
            List<long> l = FactorOneToPrimes(numToFactor, lstPrimes);
            Console.WriteLine("Factors are: ");
            foreach (int one in l)
            {
                Console.Write("{0}, ", one.ToString());
            }
            Console.ReadLine();

        }// Main

        static List<long> FactorOneToPrimes(long numToFactor, List<long> primes)
        {
            List<long> lstFactors = new List<long>();
            int primeCtr = 0;
            long remainder = numToFactor;
            bool done = false;

            while (!done)
            {
                if (remainder % primes[primeCtr] == 0)
                {
                    remainder = remainder / primes[primeCtr];
                    lstFactors.Add(primes[primeCtr]);
                }
                else
                {
                    primeCtr++;
                }
                if (MultiplyFactors(lstFactors) == numToFactor) { done = true; }
            }

            return lstFactors;
        }

        static long MultiplyFactors(List<long> lstInts)
        {
            long i = 1;
            foreach (long one in lstInts)
            {
                i = i * one;
            }
            return i;
        }

        static List<long> GetPrimes(long maxPrime)
        {
            maxPrime++;
            List<long> lstPrimes = new List<long>();
            //default is false, so we will switch the multiples of primes (that is, 
            // the not primes) to true
            bool[] bits = new bool[maxPrime + 2];


            for (long ctr = 2; ctr < maxPrime; ctr++)
            {
                if (bits[ctr] == false)
                {
                    for (long p = ctr + ctr; p < maxPrime; p += ctr)
                    {
                        bits[p] = true;
                    }
                }
            }

            for (long ctr = 2; ctr < maxPrime; ctr++)
            {
                if (bits[ctr] == false)
                { lstPrimes.Add(ctr); }
            }
            return lstPrimes;
        }

    }// Program
}
