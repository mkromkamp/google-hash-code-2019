using System.Linq;

namespace HashCode
{
    public class Challenge
    {
        public string SomeParam { get; set; }

        public Solution SolveSimple()
        {
            return new Solution
            {
                SomeSolutionParam = string.Join(string.Empty, SomeParam.Reverse()),
            };
        }
    }
}