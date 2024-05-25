using System.Threading.Tasks;

namespace WinForm.Saver
{
    public interface ISaver
    {
        public void Save(string fileName, object objNeedToSave, string path = "");
    }
}
