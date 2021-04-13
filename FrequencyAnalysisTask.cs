using System.Collections.Generic;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var result = new Dictionary<string, string>();
            var wordsCount = new Dictionary<string, int>();
            var sentences = text;

            //string.CompareOrdinal();
            //result.Comparer;

            foreach (var item in sentences)
            {
                foreach (var words in item)
                {
                    if (!wordsCount.ContainsKey(words)) wordsCount[words] = 1;
                    else wordsCount[words]++;
                }
            }

            for (int i = 0; i < sentences.Capacity; i++)
            {
                for (int j = 0; j < sentences[i][j].Length; j++)
                {
                    if (sentences[0].Capacity > 2)
                    {
                        if (!result.ContainsKey(sentences[i][j])) result[sentences[i][j]] = sentences[i][j+1];
                    }
                }
            }

            return result;
        }
   }
}