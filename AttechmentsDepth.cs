using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;

namespace AttechmentsDepth
{
    class AttechmentsDepth
    {некоректна назва. Називайте колекції в множині
        public List<string> Sentence { get; }

        public AttechmentsDepth()
        {
            Sentence = new List<string>();
        }

        public void AddSentenceFromFile(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                bool flagIsNewSentence = true;

                while (!reader.EndOfStream)
                {
                    string input = reader.ReadLine();

                    foreach (string elem in input.Split('.', StringSplitOptions.RemoveEmptyEntries))
                    {
                        if (flagIsNewSentence == true)
                            Sentence.Add(elem);
                        else
                        {
                            Sentence[Sentence.Count - 1] += elem;
                            flagIsNewSentence = true;
                        }
                    }

                    if (input[input.Length - 1] != '.')
                        flagIsNewSentence = false;
                }
            }
        }

        public string MaxAttechmentsDepth(Action<string> OnIncorrectSentence)
        {
            int maxDepth = 0;
            string result = "";

            if (Sentence.Count == 0)
                throw new ArgumentException("Error when called MaxAttechmentsDepth: there are no sentence. Add sentence using AddSentenceFromFile");

            foreach (string elem in Sentence)
            {
                int currMaxDepth = 0, currDepth = 0;

                for (int i = 0; i < elem.Length; i++)
                {
                    if (elem[i] == '(' && ++currDepth > currMaxDepth)
                    {
                        currMaxDepth = currDepth;
                    }
                    else if (elem[i] == ')')
                    {
                        currDepth--;
                    }
                }

                if (currDepth != 0)
                {
                    OnIncorrectSentence?.Invoke(elem);
                    currDepth = 0;
                }
                else if (currMaxDepth > maxDepth)
                {
                    maxDepth = currMaxDepth;
                    result = elem;
                }
            }

            return result;
        }

        public void SortSentence(Comparison<string> comparison)
        {
            Sentence.Sort(comparison);
        }
    }
}
