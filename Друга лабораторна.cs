using System;
using System.Collections.Generic;
using labs2;
namespace labs2
{
    public class Stroka
    {
        private string _Content;
        public string Content
        {
            get { return _Content; }
            set { _Content = value; }
        }
        public Stroka(string str)
        {
            _Content = str;
        }

    }



    class Program
    {

        static void Main(string[] args)
        {
            Text text = new Text();
            Console.WriteLine("Illia's Malanchuk lab work , number 2");
            text.Add_String("I'm programmer");
            text.Add_String("Hello World");
            text.Add_String("Hel123456");

            int chars = text.AllChar();
            Console.WriteLine(chars);
            Console.WriteLine(text.LetterPersentage);
            Console.WriteLine(text.NumbersPersentage);
            text.Delete_String("I'm programmer");

            Console.WriteLine(text.LongestString);
            text.RemoveStrings();
            text.Display();

            Console.ReadKey();
        }
    }
}
    

