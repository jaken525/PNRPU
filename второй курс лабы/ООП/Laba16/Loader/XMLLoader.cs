using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using WinForm.Persons;

namespace WinForm.Loader
{
    public class XMLLoader: ILoader<List<Person>>
    {
        public string Extension { get => "xml"; }
        public List<Person> Load(string fileName, string path = "")
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
            using FileStream fileStream = new FileStream(path + "\\" + fileName, FileMode.Open);
            return (List<Person>)serializer.Deserialize(fileStream);
        }
    }
}
