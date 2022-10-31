using Microsoft.VisualStudio.TestTools.UnitTesting;
using String.Metrics.LongestCommonSubsequence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String.Metrics.LongestCommonSubsequence.Tests;

[TestClass()]
public class AlgorithmsTests
{
    [TestMethod()]
    public void ClassicalAlgorithmTest()
    {
        int l1 = Algorithms.ClassicalLengthOnly("balbina", "albinos");
        Assert.AreEqual(5, l1); // albin is Longest Common Subsequence

        int l2 = Algorithms.ClassicalLengthOnly("mirosław", "mirosławie");
        Assert.AreEqual(8, l2); // mirosław is Longest Common Subsequence

        int l3 = Algorithms.ClassicalLengthOnly("", "mirosławie");
        int l4 = Algorithms.ClassicalLengthOnly("mirosław", "");
        Assert.AreEqual(0, l3);
        Assert.AreEqual(0, l4);

        int l5 = Algorithms.ClassicalLengthOnly("abcde", "fghij");
        Assert.AreEqual(0, l5);

        Assert.AreEqual(
            5,
            Algorithms.ClassicalLengthOnly("abcde", "abcde"));
    }

    [TestMethod()]
    public void ClassicalTest()
    {
        Assert.AreEqual(
            new LongestCommonSubsequence(1, 0, "albin"),
            Algorithms.Classical("balbina", "albinos"));
        Assert.AreEqual(
            new LongestCommonSubsequence(0, 0, "mirosław"),
            Algorithms.Classical("mirosław", "mirosławie"));
        Assert.AreEqual(
            new LongestCommonSubsequence(null, null, null),
            Algorithms.Classical("", "mirosławie"));
        Assert.AreEqual(
            new LongestCommonSubsequence(null, null, null),
            Algorithms.Classical("mirosław", ""));
        Assert.AreEqual(
            new LongestCommonSubsequence(null, null, null),
            Algorithms.Classical("abcde", "fghij"));
        Assert.AreEqual(
            new LongestCommonSubsequence(0, 0, "abcde"),
            Algorithms.Classical("abcde", "abcde"));
    }
}