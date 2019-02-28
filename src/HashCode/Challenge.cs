using System;
using System.Collections.Generic;
using System.Linq;

namespace HashCode
{
    public partial class Challenge
    {
        public List<Photo> Photos { get; set; }

        public Solution SolveStupid()
        {
            var remainingPhotos = Photos;
            var slides = new List<Slide>();
            
            Slide currentSlide = null;

            var horizontalPhoto = remainingPhotos.FirstOrDefault(p => p.Orientation == Orientation.Horizontal);
            if (horizontalPhoto != null)
            {
                currentSlide = Slide.Create(horizontalPhoto);
            }
            else
            {
                currentSlide = Slide.Create(remainingPhotos.ElementAt(0), remainingPhotos.ElementAt(1));
            }

            slides.Add(currentSlide);            
            currentSlide.Photos.ForEach(p => remainingPhotos.Remove(p));
            
            while (remainingPhotos.Any())
            {
                var photo = remainingPhotos.First();
                var next = Slide.Create(photo);
                if (photo.Orientation == Orientation.Vertical)
                {
                    if (remainingPhotos.Count == 1)
                        break;

                    var otherVertical = remainingPhotos.FirstOrDefault(otherPhoto => otherPhoto.Id != photo.Id && otherPhoto.Orientation == Orientation.Vertical);
                    if (otherVertical != null)
                        next.Photos.Add(otherVertical);
                    else
                        continue;
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
                        var otherVertical = remainingPhotos.First(p =>
                            p.Id != photo.Id && photo.Orientation == Orientation.Vertical);
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

        public Solution SolveSimpleWithFirstOpt()
        {
            var totalScore = 0;
            var remainingPhotos = Photos;
            var slides = new List<Slide>();

            var currentSlide = GetFirstSlide(remainingPhotos);
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
                        var otherVertical = remainingPhotos.First(p =>
                            p.Id != photo.Id && photo.Orientation == Orientation.Vertical);
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

        private static Slide GetFirstSlide(List<Photo> photos)
        {
            /*var selectMany = photos.SelectMany(x=>x.Tags);
            var enumerable = selectMany.GroupBy(x=>x);


            var groupBy = photos.GroupBy(x=>x.Tags);
            groupBy.*/
            return Slide.Create(photos.First(p => p.Orientation == Orientation.Horizontal));
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