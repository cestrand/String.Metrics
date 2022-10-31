using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String.Metrics.LongestCommonSubsequence;

public record LongestCommonSubsequence
{
    /// <summary>
    /// Subsequence starting index for first string.
    /// Null if subsequence is not found.
    /// </summary>
    public int? FirstStart { get; init; } = default;

    /// <summary>
    /// Subsequence starting index for second string. 
    /// Null if subsequence is not found.
    /// </summary>
    public int? SecondStart { get; init; } = default;

    /// <summary>
    /// Matched subsequence.
    /// Null if subsequence is not found.
    /// </summary>
    public string? Subsequence { get; init; } = default!;
}
