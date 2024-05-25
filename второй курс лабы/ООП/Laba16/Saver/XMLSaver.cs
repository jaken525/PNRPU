using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WinForm.Saver
{
    public class XMLSaver : ISaver
    {
        public async Task Serialize(string fileName, object objNeedToSave, string path = "")
        {
            XmlSerializer serializer = new XmlSerializer(objNeedToSave.GetType());
            var stopwatch = new Stopwatch();
            var stopwatchSync = new Stopwatch();

            using (var stream = new FileStream(path + "\\" + fileName + ".xml", FileMode.Create))
            {
                stopwatch.Start();

                await Task.Run(() => serializer.Serialize(stream, objNeedToSave)); 
                
                stopwatch.Stop();
            }
            
            using (var stream = new FileStream(path + "\\" + fileName + ".xml", FileMode.Create))
            {
                stopwatchSync.Start();

                serializer.Serialize(stream, objNeedToSave);

                stopwatchSync.Stop();
            }

            MessageBox.Show($"Асинхронная сериализация Xml: {stopwatch.ElapsedMilliseconds} мс\nСинхронная сериализация Xml: {stopwatchSync.ElapsedMilliseconds} мс");
        }

        public void Save(string fileName, object objNeedToSave, string path = "")
        {
            Serialize(fileName, objNeedToSave, path);
        }
    }
}
