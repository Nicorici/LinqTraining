using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Globalization;

namespace LinqTraining
{
    public class OrderPhotoByDate
    {
        static void Main(string[] args)
        {
            string source = args.First(p => p.StartsWith("source=")).Substring(7);
            string destination = args.First(p => p.StartsWith("destination=")).Substring(12);
            string subdirectoryStruct = args.First(p => p.StartsWith("subdirectoryStruct=")).Substring(19);
            string namePrefix = args.First(p => p.StartsWith("addPrefix=")).Substring(10);

            if (source.Length < 0 || !new DirectoryInfo(source).Exists)
            {
                Console.WriteLine("The source file does not exist");
                return;
            }

            if (!IsIvalidPath(destination))
            {
                Console.WriteLine("The destiantion file could not be created");
                return;
            }

            if (subdirectoryStruct.Length == 0 && namePrefix.Length == 0)
            {
                Console.WriteLine("No sorting type was given");
                return;
            }

            Directory.CreateDirectory(destination);
            var photos = new DirectoryInfo(source).GetFiles();
            string directory;
            foreach (var photo in photos)
            {
                directory = Directory.CreateDirectory($"{destination}\\{SubdirectoryPath(photo.CreationTime, subdirectoryStruct)}").FullName;
                photo.MoveTo(directory + "\\" + AddPrefixToName(photo, namePrefix));
            }
        }

        public static string SubdirectoryPath(DateTime date, string format)
        {
            return (date.ToString(format, CultureInfo.InvariantCulture)).Replace("/", "\\");
        }

        private static string AddPrefixToName(FileInfo file, string format)
        {
            return (file.CreationTime.ToString(format, CultureInfo.InvariantCulture) + file.Name);
        }

        static bool IsIvalidPath(string path)
        {
            return path.Length < 0 ||
                     path.Any(f => Path.GetInvalidFileNameChars().Contains(f)) ||
                     path.Any(f => Path.GetInvalidPathChars().Contains(f));

        }
    }
}
