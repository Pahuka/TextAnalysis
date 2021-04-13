using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        static void RemoveControl(string[] str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                str[i] = str[i].ToLower();
                str[i] = str[i].Replace('\t', ' ');
                str[i] = str[i].Replace('\r', ' ');
                str[i] = str[i].Replace('\n', ' ');
            }
        }

        static List<List<string>> FormatingProcess(string[] str, List<List<string>> sentencesList)
        {
            var builder = new StringBuilder();
            var wordsList = new List<string>();
            string word = null;

            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 0; j < str[i].Length; j++)
                {
                    if (char.IsLetter(str[i][j]) || str[i][j] == '\'')
                    {
                        builder.Append(str[i][j]);
                        if (j == str[i].Length - 1)
                        {
                            word = builder.ToString();
                            if (word != "") wordsList.Add(word);
                        }
                    }
                    else
                    {
                        word = builder.ToString();
                        if (word != "") wordsList.Add(word);
                        builder.Clear();
                    }
                }
                if (wordsList.Count != 0) sentencesList.Add(wordsList.ToList());
                wordsList.Clear();
                builder.Clear();
            }

            return sentencesList;
        }

        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();
            char[] split = new char[] { '.', '!', '?', ';', ':', '(', ')' };
            string[] str = text.Split(split);

            RemoveControl(str);

            return FormatingProcess(str, sentencesList);
        }
    }
}