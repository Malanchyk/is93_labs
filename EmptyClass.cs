using System;
using System.Collections.Generic;
namespace labs2
{

  

    public class EmptyClass
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

        public class Text
        {
            private List<Stroka> _Content;
            private string _LongestString;
            private double _LetterPersentage;
            private double _NumbersPersentage;
            public string LongestString
            {
                get { return _LongestString; }
            }

            public Text()
            {
                _Content = new List<Stroka>();
                _LongestString = "";
                _LetterPersentage = 0;
                _NumbersPersentage = 0;


            }
            public double LetterPersentage
            {
                get { return _LetterPersentage; }
            }
            public double NumbersPersentage
            {
                get { return _NumbersPersentage; }
            }



            public void Add_String(string str)
            {
                _Content.Add(new Stroka(str));
                Big_String();
                CharsAndNumbers();
            }
            public void Display()
            {
                foreach (Stroka stroka in _Content)
                {
                    Console.WriteLine(stroka.Content);
                }
            }
            public void Delete_String(string str)
            {
                _Content.RemoveAll(item => item.Content == str);
                Big_String();
                CharsAndNumbers();
            }
            public void Big_String()
            {
                string str = "";


                foreach (Stroka stroka in _Content)
                {
                    if (stroka.Content.Length > str.Length)
                    {
                        str = stroka.Content;
                    }

                }
                _LongestString = str;
            }
            public void RemoveStrings()
            {
                _Content.Clear();
            }
            public int AllChar()
            {
                int count = 0;
                foreach (Stroka stroka in _Content)
                {
                    count += stroka.Content.Length;
                }
                return count;



            }
            public void CharsAndNumbers()
            {
                int numCounter = 0;
                int letterCounter = 0;
                foreach (Stroka stroka in _Content)
                {
                    foreach (char ch in stroka.Content)
                    {
                        if (ch == '0' || ch == '1' || ch == '2' || ch == '3' || ch == '4' || ch == '5' || ch == '6' || ch == '7' || ch == '8' || ch == '9')
                        {
                            numCounter++;
                        }
                        else
                        {
                            letterCounter++;
                        }
                    }

                }
                double numberOfChars = numCounter + letterCounter;
                _LetterPersentage = letterCounter / numberOfChars;
                _NumbersPersentage = numCounter / numberOfChars;
            }



        }
    }
}
