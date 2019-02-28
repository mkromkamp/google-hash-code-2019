using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashCode
{
    public partial class Challenge
    {
        public Solution SolveSimpleWithFirstOpt()
        {
            var totalScore = 0;
            var slides = new List<Slide>();

            var remainingSlides = OrderList(Photos);
            var currentSlide = remainingSlides.First();
            slides.Add(currentSlide);

            remainingSlides.Remove(currentSlide); // <- should work :P

            while (remainingSlides.Any())
            {
                Slide nextHighest = null;
                var interestFactor = -1;

                foreach (var slide in remainingSlides)
                {
                    var interest = currentSlide.GetInterestFactor(slide);
                    if (interest > interestFactor)
                    {
                        nextHighest = slide;
                        interestFactor = interest;
                    }
                }

                slides.Add(nextHighest);
                currentSlide = nextHighest;
                remainingSlides.Remove(nextHighest);
                totalScore = totalScore + interestFactor;

                Console.WriteLine($"Slides found: {slides.Count}");
            }

            Console.WriteLine(totalScore);

            return new Solution
            {
                Slides = slides,
            };
        }

        private static List<Slide> OrderList(List<Photo> photos)
        {
            var slides = CreateSlidesFromVertical(photos);
            slides.AddRange(CreateSlidesFromHorizontal(photos));

            var keys = photos
                .SelectMany(x => x.Tags)
                .GroupBy(n => n)
                .ToDictionary(x => x.Key, x => x.Key.Count())
                .OrderByDescending(x => x.Value)
                .Select(x => x.Key)
                .ToList();

            var result = new List<Slide>(slides.Count);
            foreach (var key in keys)
            {
                var dave = slides.Where(x => x.Tags.Contains(key)).ToList();
                result.AddRange(dave);

                dave.ForEach(x=> slides.Remove(x));
            }

            return slides;
        }

        private static List<Slide> CreateSlidesFromVertical(List<Photo> photos)
        {
            var verticalPhotos = photos.Where(x => x.Orientation.Equals(Orientation.Vertical))
                .ToArray();

            var result = new List<Slide>();
            for (var i = 0; i < verticalPhotos.Length; i += 2)
            {
                var list = new List<Photo> { verticalPhotos[i], verticalPhotos[i + 1] };
                result.Add(new Slide { Photos = list });
            }

            return result;
        }
        private static List<Slide> CreateSlidesFromHorizontal(List<Photo> photos)
        {
            return photos
                .Where(x => x.Orientation.Equals(Orientation.Horizontal))
                .Select(t => new List<Photo> {t}).Select(list => new Slide {Photos = list})
                .ToList();
        }
    }
}

