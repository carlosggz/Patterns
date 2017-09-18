using System;
using System.IO;
using System.IO.Compression;

namespace Decorator
{
    public class ZipFileDecorator : Decorator
    {
        #region Constructor

        public ZipFileDecorator(FileComponent fileComponent)
            :base(fileComponent)
        {}

        #endregion

        #region FileComponent

        public override void Save(string fileName, string content)
        {
            var folderPath = GetTemporalFolder();
            Directory.CreateDirectory(folderPath);

            base.Save(GetTemporalFile(folderPath), content);

            if (File.Exists(fileName))
                File.Delete(fileName);

            ZipFile.CreateFromDirectory(folderPath, fileName);

            Directory.Delete(folderPath, true);
        }

        public override string Load(string fileName)
        {
            var folderPath = GetTemporalFolder();
            Directory.CreateDirectory(folderPath);

            ZipFile.ExtractToDirectory(fileName, folderPath);

            var toReturn = base.Load(GetTemporalFile(folderPath));

            Directory.Delete(folderPath, true);

            return toReturn;
        }

        #endregion

        #region Private methods

        private string GetTemporalFolder()
        {
            return Path.Combine(Path.GetTempPath(), "Decorator", DateTime.Now.Ticks.ToString());
        }

        private string GetTemporalFile(string folderPath)
        {
            return Path.Combine(folderPath, "content.out");
        }

        #endregion
    }


}
