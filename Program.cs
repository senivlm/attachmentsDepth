using System;
using System.IO;

namespace AttechmentsDepth
{
    class Program
    {
        static void Main(string[] args)
        {
            AttechmentsDepth attechmentsDepth = new AttechmentsDepth();

            try
            {
                //Вважається, що речення закінчується крапкою та може бути розміщене в одному або декількох рядках
                attechmentsDepth.AddSentenceFromFile("../../../input.txt");

                //Якщо кількість відкриваючих дужок не дорівнює кількості закриваючих, то виводиться повідомлення про цю стрічку на консоль, при цьому пошук не переривається
                Console.WriteLine("String with max attechments depth:\n" + 
                    attechmentsDepth.MaxAttechmentsDepth((message) => Console.WriteLine($"Incorrect attechments count in sentence: \"{message}\"")));

                attechmentsDepth.SortSentence((sentence1, sentence2) => sentence1.Length > sentence2.Length ? 1 : (sentence1.Length < sentence2.Length ? -1 : 0));
                Console.WriteLine("\nSentence sorted by length:");
                foreach (var elem in attechmentsDepth.Sentence)
                    Console.WriteLine(elem);
            }
            catch(FileNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
