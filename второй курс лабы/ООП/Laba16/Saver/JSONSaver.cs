using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm.Saver
{
    public class JSONSaver : ISaver
    {
        public async Task Serialize(string fileName, object objNeedToSave, string path = "")
        {
            string json = "";

            var stopwatchSync = new Stopwatch();
            var stopwatch = new Stopwatch();

            await Task.Run(() => json = JsonConvert.SerializeObject(objNeedToSave));

            using (var streamWriter = new StreamWriter(path + "\\" + fileName + ".json"))
            {
                stopwatch.Start();

                await streamWriter.WriteAsync(json);

                stopwatch.Stop();
            }
            
            JsonConvert.SerializeObject(objNeedToSave);

            using (var streamWriter = new StreamWriter(path + "\\" + fileName + ".json"))
            {
                stopwatchSync.Start();

                streamWriter.Write(json);

                stopwatchSync.Stop();
            }

            MessageBox.Show($"Асинхронная сериализация Json: {stopwatch.ElapsedMilliseconds} мс\nСинхронная сериализация Json: {stopwatchSync.ElapsedMilliseconds} мс");
        }

        public void Save(string fileName, object objNeedToSave, string path = "")
        {
            Serialize(fileName, objNeedToSave, path);
        }
    }
}
