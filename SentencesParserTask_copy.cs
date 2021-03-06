using System.Collections.Generic;
using System.Text;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();
            var wordsList = new List<string>(); //список слов для одного предложения
            char[] split = new char[] { '.', '!', '?', ';', ':', '(', ')' };
            string[] str = text.Split(split);
            var builder = new StringBuilder();
            string word = null;

            for (int i = 0; i < str.Length; i++)
            {
                str[i] = str[i].ToLower();
            }

            for (int i = 0; i < str.Length; i++)
            {
                if (builder.Length > 0)
                {
                    word = builder.ToString();
                    sentencesList.Add(new List<string>() { word });
                    builder.Clear();
                }
                for (int j = 0; j < str[i].Length; j++)
                {
                    if (char.IsLetter(str[i][j]) || str[i][j] == '\'')
                    {
                        builder.Append(str[i][j]);
                    }
                    else
                    {
                        word = builder.ToString();
                        if (word != "") wordsList.Add(word);
                        builder.Clear();
                    }
                }
            }

            word = builder.ToString();
            if (word != "")
            {
                wordsList.Add(word);
                sentencesList.Add(wordsList);
            }
            builder.Clear();

            return sentencesList;
        }
    }
}