using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String.Metrics;
public class LongestCommonSubsequence
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <see cref="Alberto Apostolico, Zvi Galil - Pattern Matching Algorithms (1997): Classical LCS Algorithm"/>
    public static int ClassicalAlgorithm(string x, string y)
    {
        int m = x.Length;
        int n = y.Length;

        int[,] L = new int[m+1, n+1];

        // boundary L[0,*] = 0 and L[*,0] = 0 is set by the way C# creates arrays.

        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (x[i-1] == y[j-1])
                {
                    L[i, j] = 1 + L[i - 1, j - 1];
                }
                else
                {
                    L[i, j] = Math.Max(L[i - 1, j], L[i, j - 1]);
                }
            }
        }

        return L[m, n];
    }

}
