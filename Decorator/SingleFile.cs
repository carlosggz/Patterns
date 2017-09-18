using System.IO;

namespace Decorator
{
    public class SingleFile : FileComponent
    {
        #region FileComponent

        public override void Save(string fileName, string content)
        {
            File.WriteAllText(fileName, content);
        }

        public override string Load(string fileName)
        {
            return File.ReadAllText(fileName);
        }

        #endregion
    }
}
