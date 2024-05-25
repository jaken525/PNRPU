using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm.Saver
{
    public class BinarySaver : ISaver
    {
        public async Task Serialize(string fileName, object objNeedToSave, string path = "")
        {
            BinaryFormatter formatter = new BinaryFormatter();

            var stopwatch = new Stopwatch();
            var stopwatchSync = new Stopwatch();

            using (FileStream fs = new FileStream(path + "\\" + fileName + ".bin", FileMode.Create))
            {               
                stopwatch.Start();

                await Task.Run(() => formatter.Serialize(fs, objNeedToSave));

                stopwatch.Stop();
            }

            using (FileStream fs = new FileStream(path + "\\" + fileName + ".bin", FileMode.Create))
            {
                stopwatchSync.Start();

                formatter.Serialize(fs, objNeedToSave);

                stopwatchSync.Stop();
            }

            MessageBox.Show($"Асинхронная сериализация Binary: {stopwatch.ElapsedMilliseconds} мс\nСинхронная сериализация Binary: {stopwatchSync.ElapsedMilliseconds} мс");
        }

        public void Save(string fileName, object objNeedToSave, string path = "")
        {
            Serialize(fileName, objNeedToSave, path);
        }
    }
}
