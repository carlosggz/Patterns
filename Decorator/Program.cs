using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var textFile = new SingleFile();
            var crypted = new CryptedFileDecorator(textFile, "My secret key", "my secret vector");
            var zipped = new ZipFileDecorator(crypted);

            var p = new Program();

            p.Test(textFile, "single.txt", "This is the text file content!!!");
            p.Test(crypted, "crypted.txt", "This is the crypted file content!!!");
            p.Test(zipped, "zipped.zip", "This is the zipped and crypted file content!!!");

            Console.WriteLine("Press ENTER to end...");
            Console.ReadLine();
        }

        private void Test(FileComponent file, string fileName, string content)
        {
            Console.Write($"Testing type { file.GetType().Name } ...");
            file.Save(fileName, content);
            Console.WriteLine(file.Load(fileName) == content ? "Ok" : "Failed");
        }
    }
}
