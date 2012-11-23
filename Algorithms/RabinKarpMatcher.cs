using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
{
    /// <summary>
    /// http://www.cs.bc.edu/~alvarez/Algorithms/Notes/stringMatching.html
    /// </summary>
    public class RabinKarpMatcher
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="pattern"></param>
        /// <param name="d"></param>
        /// <param name="prime"></param>
        /// <returns></returns>
        public static int Find(string text, string pattern, int d, int prime)
        {            
            var n = text.Length;
            var m = pattern.Length;
            var h = ((int)Math.Pow(d, (m - 1))) % prime;

            var p = 0;
            var t0 = 0;

            // Preprocessing
            for (var i = 0; i < m; i++)
            {
                p = (d * p + pattern[i]) % prime;
                t0 = (d * t0 + text[i]) % prime;
            }

            var ts = t0;

            // Matching
            for (var s = 0; s <= n - m; s++) 
            {
                if(p == ts)
                {
                    if(pattern == text.Substring(s, m))
                    {
                        return s;
                    }
                }

                if (s < n - m) 
                {
                    ts = (d * (ts - text[s] * h) + text[s + m]) % prime;
                    //if (ts < 0)
                    //{
                    //    ts += prime;
                    //}
                }
            }

                
            return -1;
        }
    }
}
