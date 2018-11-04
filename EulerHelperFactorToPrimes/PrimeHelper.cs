using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerHelperFactorToPrimes
{
    class PrimeHelper
    {
        List<long> lstPrimes;

        public PrimeHelper(long numToFactor)
        {
            GetPrimes(numToFactor);
        }

        public List<long> FactorOneToPrimes(long numToFactor
            )
        {
            List<long> lstFactors = new List<long>();
            int primeCtr = 0;
            long remainder = numToFactor;
            bool done = false;

            while (!done)
            {
                if (remainder % lstPrimes[primeCtr] == 0)
                {
                    remainder = remainder / lstPrimes[primeCtr];
                    lstFactors.Add(lstPrimes[primeCtr]);
                }
                else
                {
                    primeCtr++;
                }
                if (MultiplyFactors(lstFactors) == numToFactor) { done = true; }
            }

            return lstFactors;
        }

        private long MultiplyFactors(List<long> lstInts)
        {
            long i = 1;
            foreach (long one in lstInts)
            {
                i = i * one;
            }
            return i;
        }

        private List<long> GetPrimes(long maxPrime)
        {
            maxPrime++;
            lstPrimes = new List<long>();
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
    }
}
