using Microsoft.VisualStudio.TestTools.UnitTesting;
using String.Metrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String.Metrics.Tests;

[TestClass()]
public class LongestCommonSubsequenceTests
{
    [TestMethod()]
    public void ClassicalAlgorithmTest()
    {
        int l1 = LongestCommonSubsequence.ClassicalAlgorithm("balbina", "albinos");
        Assert.AreEqual(5, l1); // albin is Longest Common Subsequence

        int l2 = LongestCommonSubsequence.ClassicalAlgorithm("mirosław", "mirosławie");
        Assert.AreEqual(8, l2); // mirosław is Longest Common Subsequence

        int l3 = LongestCommonSubsequence.ClassicalAlgorithm("", "mirosławie");
        int l4 = LongestCommonSubsequence.ClassicalAlgorithm("mirosław", "");
        Assert.AreEqual(0, l3);
        Assert.AreEqual(0, l4);

        int l5 = LongestCommonSubsequence.ClassicalAlgorithm("abcde", "fghij");
        Assert.AreEqual(0, l5);
    }
}