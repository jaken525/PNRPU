namespace WinForm.Loader
{
    public interface ILoader<out T>
    {
        public string Extension { get; }
        public T Load(string fileName, string path = "");
    }
}
