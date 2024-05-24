using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitalikTeamLibrary;
using VitalikTeamLibraries;

namespace Laba13
{
    class Program
    {
        static void Main(string[] args)
        {
            NewDoublyLinkedList doubleLinkedList1 = new();
            NewDoublyLinkedList doubleLinkedList2 = new();
            doubleLinkedList1.Name = "Коллекция 1";
            doubleLinkedList2.Name = "Коллекция 2";
            
            Journal journal1 = new();
            Journal journal2 = new();

            doubleLinkedList1.CollectionCountChanged += journal1.CollectionCountChanged;
            doubleLinkedList1.CollectionReferenceChanged += journal1.CollectionReferenceChanged;
            doubleLinkedList1.CollectionReferenceChanged += journal2.CollectionReferenceChanged;
            doubleLinkedList2.CollectionReferenceChanged += journal2.CollectionReferenceChanged;

            doubleLinkedList1.Add(new Adminstartor(10, 150, "Админ1", "Админов1", "Админович1", 32));
            doubleLinkedList1.Add(new Adminstartor(4, 132, "Админ2", "Админов2", "Админович2", 42));
            doubleLinkedList1.Add(new Adminstartor(2, 23, "Админ3", "Админов3", "Админович3", 25));
            doubleLinkedList2.Add(new Employee(16, "Работник1", "Работников1", "Работникович1", 50));
            doubleLinkedList2.Add(new Employee(6, "Работник2", "Работников2", "Работникович2", 45));
            doubleLinkedList2.Add(new Employee(50, "Работник3", "Работников3", "Работникович3", 35));

            doubleLinkedList1.RemoveAt(2);
            doubleLinkedList1.Insert(0, new Engineer(15,"Техник-инженер1", "имя1", "фамилия1", "отчество1", 45));
            doubleLinkedList2.Insert(1, new Engineer(55, "Техник-инженер2", "имя2", "фамилия2", "отчество2", 65));

            doubleLinkedList1[0] = new Person();
            doubleLinkedList2[0] = new Person();

            Console.WriteLine("\t\tЗаписи из первого журнала");
            foreach (JournalEntry entry in journal1.journal)
                Console.WriteLine(entry + "\n\n");

            Console.WriteLine("\t\tЗаписи из второго журнала");
            foreach (JournalEntry entry in journal2.journal)
                Console.WriteLine(entry + "\n\n");

            Console.WriteLine("\n\t Коллекция 1:\n");         
            for(int i = 0; i < doubleLinkedList1.Count; ++i)
                Console.WriteLine(doubleLinkedList1[i]);

            Console.WriteLine("\n\n\t Коллекция 2:\n");
            for (int i = 0; i < doubleLinkedList2.Count; ++i)
                Console.WriteLine(doubleLinkedList2[i]);
        }
    }
}
