using System.Collections.Generic;
using System.Linq;

namespace HashCode
{
    public class Challenge
    {
        public List<Photo> Photos { get; set; }

        public Solution SolveSimple()
        {
            return new Solution
            {
                SomeSolutionParam = string.Join(string.Empty, SomeParam.Reverse()),
            };
        }
    }

    public class Photo
    {
        public int Id { get; set; }
        public Oriientiation Oriientiation { get; set; }
        public List<string> Tags { get; set; }
    }

    public enum Oriientiation
    {
    }
}