using System;
using Xunit;
using DotNetExercises;

namespace TestExercises2
{
    public class CodeInterviewTest
    {
        [Theory]
        [InlineData("", "")]
        [InlineData("invalid", "")]
        [InlineData("starters", "tartare or pancake")]
        [InlineData("mains", "risotto, lamb or salmon")]
        [InlineData("desserts", "icecream")]
        public void GenerateServed(string category, string expected)
        {
            var codeInterview = new CodeInterview();
            var actual = codeInterview.GenerateServed(category);
            Assert.Equal(expected, actual);
        }
    }
}
