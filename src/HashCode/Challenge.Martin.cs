using System;
using System.Collections.Generic;
using System.Linq;

namespace HashCode
{
    public partial class Challenge
    {
        public Solution CurrentBestTake(int takeCount)
        {
            var score = 0;
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
                Slide next = null;
                var nextInterest = -1;

                foreach (var photo in remainingPhotos.Take(takeCount))
                {
                    var nextPossible = Slide.Create(photo);

                    if (photo.Orientation == Orientation.Vertical)
                    {
                        if (remainingPhotos.Count == 1)
                            break;

                        var otherVertical = remainingPhotos.FirstOrDefault(otherPhoto => otherPhoto.Id != photo.Id && otherPhoto.Orientation == Orientation.Vertical);
                        if (otherVertical != null)
                            nextPossible.Photos.Add(otherVertical);
                        else
                            continue;
                    }

                    var interest = currentSlide.GetInterestFactor(nextPossible);
                    if (interest > nextInterest)
                    {
                        next = nextPossible;
                        nextInterest = interest;
                    }
                }

                score = score + currentSlide.GetInterestFactor(next);
                slides.Add(next);
                currentSlide = next;
                next.Photos.ForEach(p => remainingPhotos.Remove(p));

                Console.WriteLine($"Current slides: {slides.Count}");
            }

            Console.WriteLine(score);

            return new Solution
            {
                Slides = slides,
            };
        }

        public Solution CurrentBestThree()
        {
            var score = 0;
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
                Slide next = null;
                var nextInterest = -1;

                foreach (var photo in remainingPhotos)
                {
                    var nextPossible = Slide.Create(photo);

                    if (photo.Orientation == Orientation.Vertical)
                    {
                        if (remainingPhotos.Count == 1)
                            break;

                        var otherVertical = remainingPhotos.FirstOrDefault(otherPhoto => otherPhoto.Id != photo.Id && otherPhoto.Orientation == Orientation.Vertical);
                        if (otherVertical != null)
                            nextPossible.Photos.Add(otherVertical);
                        else
                            continue;
                    }

                    var interest = currentSlide.GetInterestFactor(nextPossible);
                    if (interest > nextInterest)
                    {
                        next = nextPossible;
                        nextInterest = interest;
                    }
                }

                score = score + currentSlide.GetInterestFactor(next);
                slides.Add(next);
                currentSlide = next;
                next.Photos.ForEach(p => remainingPhotos.Remove(p));
            }

            Console.WriteLine(score);

            return new Solution
            {
                Slides = slides,
            };
        }

        public Solution CurrentBest()
        {
            var score = 0;
            var remainingPhotos = Photos.OrderByDescending(p => p.Tags.Count).ToList();
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

                score = score + currentSlide.GetInterestFactor(next);
                slides.Add(next);
                currentSlide = next;
                next.Photos.ForEach(p => remainingPhotos.Remove(p));
            }

            Console.WriteLine(score);

            return new Solution
            {
                Slides = slides,
            };
        }       
    }
}