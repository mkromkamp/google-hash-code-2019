using System.Collections.Generic;
using System.Linq;

namespace HashCode
{
    public class Solution
    {
        public List<Slide> Slides { get; set; }
    }
    
    public class Slide
    {
        public List<Photo> Photos { get; set; }
        public List<string> Tags
        {
            get { return Photos.SelectMany(x => x.Tags).ToList(); }
        }

        public static Slide Create(Photo photo)
        {
            return new Slide{
                Photos = new List<Photo>{photo}
            };
        }

        public static Slide Create(Photo photo1, Photo photo2)
        {
            return new Slide{
                Photos = new List<Photo>{photo1, photo2}
            };
        }

        public int GetInterestFactor(Slide other)
        {
            var thisTags = Photos.SelectMany(p => p.Tags);
            var otherTags = other.Photos.SelectMany(p => p.Tags);

            var lowest = thisTags.Intersect(otherTags).Count();
            
            var thisExceptOther = thisTags.Except(otherTags).Count();
            if (thisExceptOther < lowest)
                lowest = thisExceptOther;

            var otherExceptThis = otherTags.Except(thisTags).Count();
            if (otherExceptThis < lowest)
                lowest = otherExceptThis;

            return lowest;
        }
    }
}