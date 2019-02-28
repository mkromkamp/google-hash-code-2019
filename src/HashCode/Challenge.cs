using System.Collections.Generic;
using System.Linq;

namespace HashCode
{
    public class Challenge
    {
        public List<Photo> Photos { get; set; }

        public Solution SolveSimple()
        {
            var remainingPhotos = Photos;
            var slides = new List<Slide>();

            var currentSlide = Slide.Create(remainingPhotos.First(p => p.Orientation == Orientation.Horizontal));
            slides.Add(currentSlide);
            
            remainingPhotos.Remove(currentSlide.Photos.First()); // <- should work :P
            
            while (remainingPhotos.Any())
            {
                Slide nextHighest = null;
                var interestFactor = 0;
                
                foreach (var photo in remainingPhotos)
                {
                    // if (photo.Orientation == Orientation.Vertical);

                    var possibleNext = Slide.Create(photo);
                    var interest = currentSlide.GetInterestFactor(possibleNext);
                    if (interest > interestFactor)
                    {
                        nextHighest = possibleNext;
                        interestFactor = interest;
                    }
                }

                slides.Add(nextHighest);
                nextHighest.Photos.ForEach(p => remainingPhotos.Remove(p));
            }

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