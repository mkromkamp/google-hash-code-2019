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
            var inputLines = ExampleInput.Split('\n').ToArray();
            var actual = Input.Parse(inputLines);

            Assert.NotNull(actual);
            Assert.Equal(actual.Photos.Count, 4);

            var photo = actual.Photos.Last();
            Assert.Equal(photo.Id, 3);
            Assert.Equal(photo.Orientation, Orientation.Horizontal);
            Assert.Equal(photo.Tags.Count, 2);
            Assert.Equal(photo.Tags.First(), "garden");
            Assert.Equal(photo.Tags.Last(), "cat");
        }
    }
}
