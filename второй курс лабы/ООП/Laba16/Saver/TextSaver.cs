using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm.Persons;
using WinForm.Saver;

namespace Laba16.Saver
{
    internal class TXTSaver : ISaver
    {
        public async Task Serialize(string fileName, object objNeedToSave, string path = "")
        {
            string txt = "";

            var stopwatchSync = new Stopwatch();
            var stopwatch = new Stopwatch();

            IList collection = (IList)objNeedToSave;

            using (var streamWriter = new StreamWriter(path + "\\" + fileName + ".txt"))
            {
                stopwatch.Start();

                foreach (Person person in collection)
                    await streamWriter.WriteLineAsync(person.ToString());

                stopwatch.Stop();
            }

            using (var streamWriter = new StreamWriter(path + "\\" + fileName + ".txt"))
            {
                stopwatchSync.Start();

                foreach (Person person in collection)
                    streamWriter.WriteLine(person.ToString());

                stopwatchSync.Stop();
            }

            MessageBox.Show($"Асинхронная сериализация Text: {stopwatch.ElapsedMilliseconds} мс\nСинхронная сериализация Text: {stopwatchSync.ElapsedMilliseconds} мс");
        }

        public void Save(string fileName, object objNeedToSave, string path = "")
        {
            Serialize(fileName, objNeedToSave, path);
        }
    }
}
