using System;
using System.Collections.Generic;

namespace lab3
{
    class Table
    {
        private List<string> _Name;         //мої дані
        private List<string> _SirName;
        private List<string> _Patronimic;
        private int _PersonsWithSirnameNechai;

        public Table() //Конструктор в якому ініціалізуємо дані 
        {
            _Name = new List<string>();
            _SirName = new List<string>();
            _Patronimic = new List<string>();
            _PersonsWithSirnameNechai = 0;


        }

        public void Insert(string name, string sirname, string patronimic)  //Вводимо дані
        {
            _Name.Add(name);
            _SirName.Add(sirname);
            _Patronimic.Add(patronimic);
            if (sirname == "Nechai") { _PersonsWithSirnameNechai++; }  //Рахуємо к-сть фамілій Нечай
        
            
        }
        public int PersonsWithSirnameNechai    //Повертаємо фамілії Нечай
        {
            get { return _PersonsWithSirnameNechai; }
        }
        public List<string> this [string index ]    //Індексатор
        {
            get
            {
                if (index == "name")
                {
                    return _Name;
                }
                if (index == "sirname")
                {
                    return _SirName;
                }
                if (index == "patronimic")
                {
                    return _Patronimic;
                }
                return null;
            }
        }




    }

    class Program
    {
        public static void PrintList(List<string> list)    //Виводимо на екран нашу табличку з іменами фаміліями або по батькові
        {
            foreach (string item in list)
            {
                Console.WriteLine(item);
            }

        }


        static void Main(string[] args)
        {
            Table table = new Table();  //Ініціалізація для використовування классу Table  
            table.Insert("Vasya", "Danya", "Dima");
            table.Insert("Vasya", "Nechai", "Ivanovich");
            table.Insert("Illia", "Nechai", "Illiich");

            Console.WriteLine(table.PersonsWithSirnameNechai);  //Виводимо на екран к-сть фамілій Нечай
            PrintList(table["sirname"]);

        } }
}
