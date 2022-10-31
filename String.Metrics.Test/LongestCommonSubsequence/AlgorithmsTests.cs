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
        int l1 = Algorithms.ClassicalAlgorithm("balbina", "albinos");
        Assert.AreEqual(5, l1); // albin is Longest Common Subsequence

        int l2 = Algorithms.ClassicalAlgorithm("mirosław", "mirosławie");
        Assert.AreEqual(8, l2); // mirosław is Longest Common Subsequence

        int l3 = Algorithms.ClassicalAlgorithm("", "mirosławie");
        int l4 = Algorithms.ClassicalAlgorithm("mirosław", "");
        Assert.AreEqual(0, l3);
        Assert.AreEqual(0, l4);

        int l5 = Algorithms.ClassicalAlgorithm("abcde", "fghij");
        Assert.AreEqual(0, l5);
    }
}