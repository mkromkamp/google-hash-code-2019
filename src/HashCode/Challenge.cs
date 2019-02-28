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
            };
        }
    }

    public class Photo
    {
        public int Id { get; set; }
        public Orientation Orientation { get; set; }
        public List<string> Tags { get; set; }
    }

    public enum Orientation
    {
        Horizontal,
        Vertical
    }
}