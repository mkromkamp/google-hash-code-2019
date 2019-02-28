using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace HashCode.Tests
{
    public class InputTests
    {
        private const string ExampleInput = @"";

        [Fact]
        public void InputExampleCorrectlyParses()
        {
            var inputLines = ExampleInput.Split('\n').ToList();
            var actual = Input.Parse(inputLines);

            Assert.NotNull(actual);
        }
    }
}
