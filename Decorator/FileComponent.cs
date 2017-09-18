namespace Decorator
{
    public abstract class FileComponent
    {
        public abstract void Save(string fileName, string content);
        public abstract string Load(string fileName);
    }
}
