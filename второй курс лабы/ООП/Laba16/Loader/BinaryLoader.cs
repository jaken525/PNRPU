using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using WinForm.Persons;

namespace WinForm.Loader
{
    internal class BinaryLoader: ILoader<List<Person>>
    {
        public string Extension { get => "bin"; }
        public List<Person> Load(string fileName, string path = "")
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using FileStream fileStream = new FileStream(path + "\\" + fileName, FileMode.Open);
            return (List<Person>)binaryFormatter.Deserialize(fileStream);
        }
    }
}
