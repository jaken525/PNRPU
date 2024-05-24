using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitalikTeamLibraries;


namespace Laba13
{
    public class CollectionHandlerEventArgs : EventArgs
    {
        public string NameOfCollection { get; }
        public string TypeOfChange { get; }

        public Person chainedObject { get; }

        public CollectionHandlerEventArgs(string NameOfCollection, string TypeOfChange, Person chainedObject)
        {
            this.NameOfCollection = NameOfCollection;
            this.TypeOfChange = TypeOfChange;
            this.chainedObject = chainedObject;
        }

        public override string ToString()
        {
            return $"Имя коллекции = {NameOfCollection}, Тип замены = {TypeOfChange}";
        }
    }

    class NewDoublyLinkedList : DoublyLinkedList<Person>
    {
        public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);
        public event CollectionHandler CollectionCountChanged;
        public event CollectionHandler CollectionReferenceChanged;

        public override Person this[int Index] 
        { 
            get => base[Index];
            set
            {
                base[Index] = value;
                OnCollectionReferenceChanged(this, new CollectionHandlerEventArgs(Name, "Изменено", value));
            }
        }

        public string Name { get; set; }

        public NewDoublyLinkedList()
        {
            Name = "New List";
        }

        public override void Add(Person people)
        {
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs(Name, "Добавлен элемент", people));
            base.Add(people);
        }

        public override void Insert(int Index, Person element)
        {
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs(Name, $"Вставлен после индекса = {Index}", element));
            base.Insert(Index, element);
        }

        public override bool Contains(Person data)
        { 
            return base.Contains(data);
        }

        public override void RemoveAt(int number)
        {
            Person tmp = this[number];
            base.RemoveAt(number);
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs(Name, "Удалён элемент", tmp));        
        }
        
        public override void Clear()
        {
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs(Name, "Коллекция очищена", null));
            base.Clear();
        }

        public void OnCollectionCountChanged(object source, CollectionHandlerEventArgs e)
        {
            CollectionCountChanged?.Invoke(this, e);
        }

        public void OnCollectionReferenceChanged(object source, CollectionHandlerEventArgs e)
        {
            CollectionReferenceChanged?.Invoke(this, e);
        }
    }
}
