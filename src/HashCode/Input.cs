using System;
using System.Collections.Generic;
using System.Linq;

namespace HashCode
{
    public static class Input
    {
        public static Challenge Parse(string[] lines)
        {
            var capacity = Convert.ToInt32(lines[0]);
            var result = new List<Photo>(capacity);

            for (var i = 0; i < capacity; i++)
            {
                var line = lines[i + 1];
                var props = line.Split(' ');

                var photo = new Photo();
                var ori = props[0];
                photo.Id = i;
                photo.Orientation = ori == "H" ? Orientation.Horizontal : Orientation.Vertical;

                var amountOfTags = Convert.ToInt32(props[1]);
                var tags = new string[amountOfTags];

                for (var j = 0; j < amountOfTags; j++)
                {
                    tags[j] = props[j + 2];
                }
                photo.Tags = tags.ToList();
                result.Add(photo);
            }
            return new Challenge
            {
                Photos = result
            };
        }
    }
}