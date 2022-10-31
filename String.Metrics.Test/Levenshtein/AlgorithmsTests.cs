using Microsoft.VisualStudio.TestTools.UnitTesting;
using String.Metrics.Levenshtein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String.Metrics.Levenshtein.Tests;

[TestClass()]
public class AlgorithmsTests
{
    [TestMethod()]
    public void LevenshteinTest()
    {
        Assert.AreEqual(
            1,
            Algorithms.Levenshtein("Marcin", "Martin"));

        Assert.AreEqual(
            6,
            Algorithms.Levenshtein("Bożydar", "Barnaba"));
    }

    [TestMethod()]
    public void LevenshteinFromLCSLengthTest()
    {
        Assert.AreEqual(
            Algorithms.Levenshtein("Marcin", "Martin"),
            Algorithms.LevenshteinFromLCSLength("Marcin", "Martin"));

        Assert.AreEqual(
            Algorithms.Levenshtein("Bożydar", "Barnaba"),
            Algorithms.LevenshteinFromLCSLength("Bożydar", "Barnaba"));

        Assert.AreEqual(
            Algorithms.Levenshtein("ab", "abcdefg"),
            Algorithms.LevenshteinFromLCSLength("ab", "abcdefg"));
    }
}