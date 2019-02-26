using System.Collections.Generic;
using System.Linq;

namespace HashCode
{
    public static class Input
    {
        public static Challenge Parse(List<string> lines)
        {
            var input = lines.First();

            return new Challenge
            {
                SomeParam = input,
            };
        }
    }
}