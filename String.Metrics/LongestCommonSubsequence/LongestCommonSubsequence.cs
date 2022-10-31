using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String.Metrics.LongestCommonSubsequence;

/// <summary>
/// Output of Longest Common Subsequence algorithm.
/// </summary>
/// <param name="FirstStart">Subsequence starting index in first string.</param>
/// <param name="SecondStart">Subsequence starting index in second string. </param>
/// <param name="Subsequence">Matched subsequence.</param>
public record struct LongestCommonSubsequence(
    int? FirstStart,
    int? SecondStart,
    string? Subsequence)
{
    
}