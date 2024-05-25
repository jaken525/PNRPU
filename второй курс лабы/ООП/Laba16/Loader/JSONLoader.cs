using System.Collections.Generic;
using WinForm.Persons;
using Newtonsoft.Json;

namespace WinForm.Loader
{
    internal class JSONLoader: ILoader<List<Person>>
    {
        public string Extension { get => "json"; }
        public List<Person> Load(string fileName, string path = "")
        {
            string json = System.IO.File.ReadAllText(path + "\\" + fileName);
            return (JsonConvert.DeserializeObject<List<Person>>(json));
        }
    }
}
