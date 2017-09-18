namespace Decorator
{
    public abstract class Decorator: FileComponent
    {
        private readonly FileComponent fileComponent;

        public Decorator(FileComponent fileComponent)
        {
            this.fileComponent = fileComponent;
        }

        public override void Save(string fileName, string content)
        {
            fileComponent.Save(fileName, content);
        }

        public override string Load(string fileName)
        {
            return fileComponent.Load(fileName);
        }
    }
}
