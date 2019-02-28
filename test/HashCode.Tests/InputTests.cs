using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace HashCode.Tests
{
    public class InputTests
    {
        private const string ExampleInput = @"4
H 3 cat beach sun
V 2 selfie smile
V 2 garden selfie
H 2 garden cat
";

        [Fact]
        public void InputExampleCorrectlyParses()
        {
            var inputLines = ExampleInput.Split('\n').ToList();
            var actual = Input.Parse(inputLines);

            Assert.NotNull(actual);
        }
    }
}
