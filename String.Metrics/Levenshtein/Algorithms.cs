using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String.Metrics.Levenshtein;
public class Algorithms
{
    /// <summary>
    /// Calculate generalized Levenshtein distance between two strings.
    /// Generalization is the use of weight function <c>delta</c>.
    /// If function <c>delta</c> is not symmetric then result could be interpreted as how costly it is to turn <c>x</c> into <c>y</c>.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="delta">Returns how costly it is to turn character <c>x</c> into <c>y</c>.
    /// For character insertion set <c>x = (char)0</c>.
    /// For character deletion set <c>y = (char)0</c>.
    /// </param>
    /// <returns></returns>
    public static float GeneralizedLevenshtein(string x, string y, Func<char, char, float> delta)
    {
        var m = x.Length;
        var n = y.Length;

        var D = new float[m + 1, n + 1];

        // set boundary values
        for (var i = 1; i <= m; i++)
        {
            D[i, 0] = D[i - 1, 0] + delta(x[i - 1], (char)0);
        }
        for (var j = 1; j <= n; j++)
        {
            D[0, j] = D[0, j - 1] + delta((char)0, y[j - 1]);
        }

        // calculate matrix recursively
        for (var i = 1; i <= m; i++)
        {
            for (var j = 1; j <= n; j++)
            {
                if (x[i - 1] == y[j - 1])
                {
                    D[i, j] = D[i - 1, j - 1];
                }
                else
                {
                    float v = D[i, j - 1] + delta((char)0, y[j - 1]);
                    float h = D[i - 1, j] + delta(x[i - 1], (char)0);
                    float u = D[i - 1, j - 1] + delta(x[i - 1], y[j - 1]);
                    var r = Math.Min(v, h);
                    D[i, j] = Math.Min(r, u);
                }
            }
        }

        return D[m, n];
    }

    public static float CommonDelta(char x, char y)
    {
        if (x == y)
        {
            return 0;
        }
        else
        {
            if (x == (char)0 || y == (char)0)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
    }

    /// <summary>
    /// Calculate Levenshtein distance which says how many indels (inserts and deletions) it takes to turn one string into another.
    /// <para>Substitution is insert and deletion and counts as 2.</para>
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public static int Levenshtein(string x, string y) => 
        (int)Math.Round(GeneralizedLevenshtein(x, y, CommonDelta), MidpointRounding.AwayFromZero);

    /// <summary>
    /// Calculate Levenshtein distance using relationship between Longest Common Subsequence length and Levenshtein.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public static int LevenshteinFromLCSLength(string x, string y)
    {
        int d = LongestCommonSubsequence.Algorithms.ClassicalLengthOnly(x, y);
        return x.Length + y.Length - 2*d;
    }
}
