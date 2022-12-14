using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String.Metrics.LongestCommonSubsequence;

public class Algorithms
{
    /// <summary>
    /// Calculate length of longest common subsequence using recursively defined matrix.
    /// <para>This method requires O(mn) time and space.</para>
    /// </summary>
    /// <returns>Length of longest common subsequence.</returns>
    /// <see cref="Alberto Apostolico, Zvi Galil - Pattern Matching Algorithms (1997): Classical LCS Algorithm"/>
    public static int ClassicalLengthOnly(string x, string y)
    {
        var m = x.Length;
        var n = y.Length;

        var L = new int[m + 1, n + 1];

        // boundary L[0,*] = 0 and L[*,0] = 0 is set by the way C# creates arrays.

        for (var i = 1; i <= m; i++)
        {
            for (var j = 1; j <= n; j++)
            {
                if (x[i - 1] == y[j - 1])
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

    /// <summary>
    /// Calculate length of longest common subsequence using recursively defined matrix.
    /// <para>This method requires O(mn) time and space.</para>
    /// </summary>
    /// <see cref="Alberto Apostolico, Zvi Galil - Pattern Matching Algorithms (1997): Classical LCS Algorithm"/>
    public static LongestCommonSubsequence Classical(string x, string y)
    {
        var m = x.Length;
        var n = y.Length;

        var L = new int[m + 1, n + 1];
        var P = new Direction[m + 1, n + 1];

        // boundary L[0,*] = 0 and L[*,0] = 0 is set by the way C# creates arrays.

        for (var i = 1; i <= m; i++)
        {
            for (var j = 1; j <= n; j++)
            {
                if (x[i - 1] == y[j - 1])
                {
                    L[i, j] = 1 + L[i - 1, j - 1];
                }
                else
                {
                    L[i, j] = Math.Max(L[i - 1, j], L[i, j - 1]);
                }

                // calculate direction values
                if (x[i - 1] == y[j - 1])
                {
                    P[i, j] = Direction.Both;
                }
                else if (L[i-1, j] > L[i, j-1])
                {
                    P[i, j] = Direction.Vertical;
                }
                else
                {
                    P[i, j] = Direction.Horizontal;
                }
            }
        }

        StringBuilder b = new StringBuilder();
        string? subsequence = null;
        int? x_start = null;
        int? y_start = null;
        {
            int k = L[m, n];
            int i = m;
            int j = n;
            if (k > 0)
            {
                while (k > 0)
                {
                    if (P[i, j] == Direction.Both)
                    {
                        b.Insert(0, x[i - 1]);
                        k--; i--; j--;
                    }
                    else if (P[i, j] == Direction.Vertical)
                    {
                        i--;
                    }
                    else
                    {
                        j--;
                    }
                }
                subsequence = b.ToString();
                x_start = i; 
                y_start = j;
            }
        }
        
        LongestCommonSubsequence lcs = new(x_start, y_start, subsequence);
        return lcs;
    }

    /// <summary>
    /// Calculate length of longest common subsequence.
    /// <para>This method requires O(n) time and space.</para>
    /// </summary>
    /// <see cref="Alberto Apostolico, Zvi Galil - Pattern Matching Algorithms (1997): Classical LCS Algorithm"/>
    public static int FindRow(string x, string y)
    {
        var m = x.Length;
        var n = y.Length;
        var L = new int[n+1];
        for (int i = 1; i <= m; i++)
        {
            var Lnew = new int[n+1];
            for (int j = 1; j <= n; j++)
            {
                if (x[i-1] == y[j-1])
                {
                    Lnew[j] = 1 + L[j-1];
                }
                else
                {
                    Lnew[j] = Math.Max(Lnew[j - 1], L[j]);
                }
            }
            Array.Copy(Lnew, L, n+1);
        }
        return L[n];
    }

    /// <summary>
    /// Calculate length of longest common subsequence.
    /// <para>This method requires O(n) time and space.</para>
    /// </summary>
    /// <see cref="Alberto Apostolico, Zvi Galil - Pattern Matching Algorithms (1997): Classical LCS Algorithm"/>
    public static int FindMid(string x, string y)
    {
        var m = x.Length;
        var n = y.Length;
        var L = new int[n + 1];
        for (int i = 1; i <= m; i++)
        {
            var Lnew = new int[n + 1];
            for (int j = 1; j <= n; j++)
            {
                if (x[i - 1] == y[j - 1])
                {
                    Lnew[j] = 1 + L[j - 1];
                }
                else
                {
                    Lnew[j] = Math.Max(Lnew[j - 1], L[j]);
                }
            }
            Array.Copy(Lnew, L, n + 1);
        }
        int[] P = Enumerable.Range(0, n).ToArray();
        for (int i = (int)Math.Ceiling(m/2.0m); i <= m; i++)
        {
            var Lnew = new int[n + 1];
            var Pnew = new int[n + 1];
            for (int j = 1; j <= n; j++)
            {
                if (x[i] == y[j])
                {
                    Lnew[j] = 1 + L[j - 1];
                }
                else
                {
                    Lnew[j] = Math.Max(Lnew[j - 1], L[j]);
                }
                if (x[i] == y[j])
                {
                    Pnew[j] = P[j - 1];
                }
                else if (Lnew[j-1] > L[j])
                {
                    Pnew[j] = Pnew[j - 1];
                }
                else
                {
                    Pnew[j] = P[j];
                }
            }
            Array.Copy(Lnew, L, n + 1);
            Array.Copy(Pnew, P, n + 1);
        }
        return P[n];
    }
}
