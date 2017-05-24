using System;
using System.Collections.Generic;
using System.Linq;
using SearchEngine.Common;
using SearchEngine.Entities;

namespace SearchEngine.Util
{
    public class SearchUtil
    {
        public SearchUtil()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public List<SearchText> PrepareWordsToSearch(string[] parameters)
        {
            var wordsToSearch = new List<SearchText>();

            parameters.ToList().ForEach(parameter =>
            {
                wordsToSearch.Add(new SearchText(parameter));
            });

            return wordsToSearch;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public bool DoValidate(List<SearchText> words)
        {
            var differentWords = words.Cast<SearchText>().Select(word => word.Text).ToList();
                
            if(words.Count() > differentWords.Distinct().Count())
            {
                Console.WriteLine("Please, enter different words to search");
                return false;
            }

            if (!words.Any())
            {
                Console.WriteLine("Please, enter at least one valid word to search");
                return false;
            }

            if (words.Count() < AppConstant.numberOfWords)
            {
                Console.WriteLine("Please, enter at least two valid words to compare");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Visual representation of the results
        /// </summary>
        /// <param name="ResultsByWord"></param>
        public void DisplayResults(SearchComparator Comparator)
        {
            Console.WriteLine("The results of the comparisson is:");
            var resultsByWord = Comparator.WordsToCompare;

            resultsByWord.ForEach(Word => {

                Console.Write(string.Format("[{0}]: ", Word.Text));

                Word.Results.ForEach(result => {
                    Console.Write(string.Format("{0}: {1} ", result.EngineName, result.NumberOfOcurrencies));
                });
            });

            Console.Write("\n");

            AppConstant.SearchEngine.GetAvailableSearchEngines().ToList().ForEach(searchEngine => DisplayWinner(searchEngine, resultsByWord));
            
            DisplayTotalWinner(resultsByWord);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchEngineName"></param>
        /// <param name="searchEngineResults"></param>
        private void DisplayWinner(string searchEngineName, List<SearchText> ResultsByWord) {

            long? currentMaxCountbyWord = 0;
            var winnerWordBySearchEngine = string.Empty;

            ResultsByWord.ForEach(word =>
            {
                /* Getting the Search Engine results regarding the [Search Engine] specified */
                var searchEngineResult = word.Results.FirstOrDefault(engine => engine.EngineName.Equals(searchEngineName));

                if (searchEngineResult.NumberOfOcurrencies >= currentMaxCountbyWord)
                {
                    currentMaxCountbyWord = searchEngineResult.NumberOfOcurrencies;
                    winnerWordBySearchEngine = word.Text;
                }
            });

            Console.Write(string.Format("Winner in {0}: {1}", searchEngineName, winnerWordBySearchEngine));
            Console.Write("\n");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ResultsByWord"></param>
        private void DisplayTotalWinner(List<SearchText> ResultsByWord) {

            long? currentMaxTotalOcurrences = 0;
            long? totalOcurrencesByWord = 0;
            var wordWithMoreTotalOcurrences = string.Empty;

            ResultsByWord.ForEach(word =>
            {
                /* Getting the SUM of number of ocurrences from a specific word in ALL available search engines */
                totalOcurrencesByWord = word.Results.Sum(item => item.NumberOfOcurrencies);

                if (totalOcurrencesByWord > currentMaxTotalOcurrences)
                {
                    currentMaxTotalOcurrences = totalOcurrencesByWord;
                    wordWithMoreTotalOcurrences = word.Text;
                }
            });

            Console.Write(string.Format("Total Winner: {0}", wordWithMoreTotalOcurrences));
        }

    }
}
