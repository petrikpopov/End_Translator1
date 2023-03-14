using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Threading;

namespace _NET_End_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Создать словарь --> 1)Англо-русский, 2)Русско-английский\n");
            Console.WriteLine("3)Добавить слово в словарь\n");
            Console.WriteLine("4)Удалить слово из словаря\n");
            Console.WriteLine("5)Найти слово в словаре\n");
            
            int vibor = Convert.ToInt32(Console.ReadLine());
            if (vibor == 1)
            {
                XmlTextWriter xmlText = new XmlTextWriter("../../English.xml", Encoding.UTF8);
                xmlText.WriteStartDocument();
                xmlText.WriteStartElement("Dictionary");
                xmlText.WriteComment("English");
                xmlText.WriteStartElement("Word");
                xmlText.Close();
            }
            if (vibor == 2)
            {
                XmlTextWriter xmlText = new XmlTextWriter("../../Russian.xml", Encoding.UTF8);
                xmlText.WriteStartDocument();
                xmlText.WriteStartElement("Словарь");
                xmlText.WriteComment("Русский");
                xmlText.WriteStartElement("Слово");
                xmlText.Close();
            }
            if (vibor == 3)
            {
                Console.WriteLine("В какой словарь вы хотите добавить слово??");
                Console.WriteLine("1)Англо-русский\t2)русско-английский");
                int vibo1 = Convert.ToInt32(Console.ReadLine());
                if (vibo1 == 1)
                {
                    Console.WriteLine("Введите английское слово!");
                    string word1 = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Введите русское слово!");
                    string word2 = Convert.ToString(Console.ReadLine());
                    XmlDocument xml = new XmlDocument();
                    xml.Load("../../English.xml");
                    xml.DocumentElement["Word"].SetAttribute(word1, word2);
                    xml.Save("../../English.xml");
                    Console.WriteLine("Вы добавили слово!!!");
                }
                if (vibo1 == 2)
                {
                    Console.WriteLine("Введите русское слово!");
                    string word2 = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Введите английское слово!");
                    string word1 = Convert.ToString(Console.ReadLine());
                    XmlDocument xml = new XmlDocument();
                    xml.Load("../../Russian.xml");
                    xml.DocumentElement["Слово"].SetAttribute(word1, word2);
                    xml.Save("../../Russian.xml");
                    Console.WriteLine("Вы добавили слово!!!");
                }
            }
            if (vibor == 4)
            {
                Console.WriteLine("Из какого словаря вы хотите удалить слово??");
                Console.WriteLine("1)Aнгло-русского\t2)русско-английского\n");
                int vibor2 = Convert.ToInt32(Console.ReadLine());
                if (vibor2 == 1)
                {
                    Console.WriteLine("Введите слово которые вы хотите удалить!");
                    string word_delet = Convert.ToString(Console.ReadLine());
                    XmlDocument xml = new XmlDocument();
                    xml.Load("../../English.xml");
                    XmlAttributeCollection collection = xml.DocumentElement.Attributes;// получает атрибус с указаным элиментов
                    collection.Remove(collection[word_delet]);
                    xml.Save("../../English.xml");
                    Console.WriteLine("Вы удалили слово!!!");
                }
                if (vibor == 2)
                {
                    Console.WriteLine("Введите слово которые вы хотите удалить!");
                    string word_delet = Convert.ToString(Console.ReadLine());
                    XmlDocument xml = new XmlDocument();
                    xml.Load("../../Russian.xml");
                    XmlAttributeCollection collection = xml.DocumentElement.Attributes;
                    collection.Remove(collection[word_delet]);
                    xml.Save("../../Russian.xml");
                    Console.WriteLine("Вы удалили слово!!!");
                }
                Console.WriteLine("Хотите ли вы удалить перевод слова");
                Console.WriteLine("1)Да - В английском словаре\t2)Да - в русском словаре\t3)Нет");
                int A = Convert.ToInt32(Console.ReadLine());
                if (A == 1)
                {
                    Console.WriteLine("Введите перевод слова которого вы хотите удалить!");
                    string word_tr = Convert.ToString(Console.ReadLine());
                    XmlDocument xml = new XmlDocument();
                    xml.Load("../../English.xml");
                    XmlAttributeCollection collection = xml.DocumentElement.Attributes;
                    collection.GetNamedItem(word_tr).InnerText = "\t";
                    xml.Save("../../English.xml");
                    Console.WriteLine("Вы удалили перевод!!!");
                }
                if (A == 2)
                {
                    Console.WriteLine("Введите перевод слова которого вы хотите удалить!");
                    string word_tr = Convert.ToString(Console.ReadLine());
                    XmlDocument xml = new XmlDocument();
                    xml.Load("../../Russian.xml");
                    XmlAttributeCollection collection = xml.DocumentElement.Attributes;
                    collection.GetNamedItem(word_tr).InnerText = "\t";
                    xml.Save("../../Russian.xml");
                    Console.WriteLine("Вы удалили перевод!!!");
                }
                if (A==3)
                {
                    Console.WriteLine("Вы выбрали выбор не удалять слово из словаря!!");
                }
            }
            if (vibor==5)
            {
                Console.WriteLine("В каком словаре вы хотите найти перевод слова?");
                Console.WriteLine("1)Англо-русском\t2)Русско-английском");
                int v = Convert.ToInt32(Console.ReadLine());
                if (v==1)
                {
                    Console.WriteLine("Введите слово которое вы хотите перевести");
                    string w = Convert.ToString(Console.ReadLine());
                    XElement xElement = XElement.Load("../../English.xml");
                    foreach (XElement i in xElement.Elements("Word"))
                    {
                        Console.Write($"{i.Name} ");
                        foreach (XAttribute a in i.Attributes())
                        {
                            if (a.Name == w)
                            {
                                Console.Write($"{a.Name}--->{a.Value} ");
                            }
                        }

                    }
                }
                if (v==2)
                {
                    Console.WriteLine("Введите слово которое вы хотите перевести");
                    string w = Convert.ToString(Console.ReadLine());
                    XElement xElement = XElement.Load("../../Russian.xml");
                    foreach (XElement i in xElement.Elements("Слово"))
                    {
                        Console.Write($"{i.Name} ");
                        foreach (XAttribute a in i.Attributes())
                        {
                            if (a.Name == w)
                            {
                                Console.Write($"{a.Name}--->{a.Value} ");
                            }
                        }

                    }
                }
            }
            

        }
    }
}


