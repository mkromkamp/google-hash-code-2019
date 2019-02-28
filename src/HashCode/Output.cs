using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HashCode
{
    public static class Output
    {
        public static void Write(Solution solution, string fileName)
        {
            using (var outputFile = File.Open(fileName, FileMode.Truncate))
            {
                using (var writer = new StreamWriter(outputFile))
                {
                    writer.WriteLine(solution.Slides.Count);
                    foreach (var slide in solution.Slides)
                    {
                        writer.WriteLine(string.Join(' ', slide.Photos.Select(p => p.Id)));   
                    }
                }
            }
        }
    }
}