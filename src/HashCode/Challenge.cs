using System;
using System.Collections.Generic;
using System.Linq;

namespace HashCode
{
    public class Challenge
    {
        public List<Photo> Photos { get; set; }

        public Solution SolveStupid()
        {
            var remainingPhotos = Photos;
            var slides = new List<Slide>();

            var currentSlide = Slide.Create(remainingPhotos.First(p => p.Orientation == Orientation.Horizontal));
            slides.Add(currentSlide);
            
            remainingPhotos.Remove(currentSlide.Photos.First()); // <- should work :P
            
            while (remainingPhotos.Any())
            {
                var photo = remainingPhotos.First();
                var next = Slide.Create(photo);
                if (photo.Orientation == Orientation.Vertical)
                {
                    var otherVertical = remainingPhotos.First(p => p.Id != photo.Id && photo.Orientation == Orientation.Vertical);
                    next.Photos.Add(otherVertical);
                }

                slides.Add(next);
                currentSlide = next;
                next.Photos.ForEach(p => remainingPhotos.Remove(p));

                Console.WriteLine($"Slides found: {slides.Count}");
            }

            return new Solution
            {
                Slides = slides,
            };
        }

        public Solution SolveSimple()
        {
            var totalScore = 0;
            var remainingPhotos = Photos;
            var slides = new List<Slide>();

            var currentSlide = Slide.Create(remainingPhotos.First(p => p.Orientation == Orientation.Horizontal));
            slides.Add(currentSlide);
            
            remainingPhotos.Remove(currentSlide.Photos.First()); // <- should work :P
            
            while (remainingPhotos.Any())
            {
                Slide nextHighest = null;
                var interestFactor = -1;
                
                foreach (var photo in remainingPhotos)
                {
                    var possibleNext = Slide.Create(photo);
                    if (photo.Orientation == Orientation.Vertical)
                    {
                        var otherVertical = remainingPhotos.First(p => p.Id != photo.Id && photo.Orientation == Orientation.Vertical);
                        possibleNext.Photos.Add(otherVertical);
                    }

                    var interest = currentSlide.GetInterestFactor(possibleNext);
                    if (interest > interestFactor)
                    {
                        nextHighest = possibleNext;
                        interestFactor = interest;
                    }
                }

                slides.Add(nextHighest);
                currentSlide = nextHighest;
                nextHighest.Photos.ForEach(p => remainingPhotos.Remove(p));
                totalScore = totalScore + interestFactor;

                Console.WriteLine($"Slides found: {slides.Count}");
            }

            Console.WriteLine(totalScore);

            return new Solution
            {
                Slides = slides,
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