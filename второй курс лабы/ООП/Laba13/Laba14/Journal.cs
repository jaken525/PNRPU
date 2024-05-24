using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba13
{
    public class JournalEntry
    {
        public string NameOfCollection { get; }
        public string TypeOfChange { get; }
        public string InfoOfObject { get; }

        public JournalEntry(string NameOfCollection, string TypeOfChange, string InfoOfObject)
        {
            this.InfoOfObject = InfoOfObject;
            this.NameOfCollection = NameOfCollection;
            this.TypeOfChange = TypeOfChange;
        }

        public override string ToString()
        {
            return $"\tИмя коллекции - {NameOfCollection}\n\tТип изменения - {TypeOfChange}\n\tИнформация об объекте:\n\n{InfoOfObject}\n";
        }
    }
    public class Journal
    {
        public List<JournalEntry> journal = new List<JournalEntry>();

        public void CollectionCountChanged(object source, CollectionHandlerEventArgs e)
        {
            JournalEntry journalEntry = new JournalEntry(e.NameOfCollection, e.TypeOfChange, e.chainedObject.ToString());
            journal.Add(journalEntry);
        }

        public void CollectionReferenceChanged(object source, CollectionHandlerEventArgs e)
        {
            JournalEntry journalEntry = new JournalEntry(e.NameOfCollection, e.TypeOfChange, e.chainedObject.ToString());
            journal.Add(journalEntry);
        }
    }
}
