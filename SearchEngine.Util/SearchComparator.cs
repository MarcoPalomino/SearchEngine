
using System.Collections.Generic;
using SearchEngine.Entities;
using SearchEngine.SearchFactory.Factory;

namespace SearchEngine.Util
{
    public class SearchComparator
    {
        private List<SearchText> _wordsToCompare;
        public List<SearchText> WordsToCompare
        {
            get
            {
                if (_wordsToCompare == null)
                    return new List<SearchText>();

                return _wordsToCompare;
            }

            set {
                this._wordsToCompare = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wordsToSearch"></param>
        public SearchComparator(List<SearchText> wordsToSearch) {
            WordsToCompare = wordsToSearch;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<SearchText> Run() {

            var numberOfOcurrences = (long?)0;
            
            /* Running the search engine in all words entered */
            WordsToCompare.ForEach(word =>
            {
                var GoogleComparator = new GoogleFactory();
                numberOfOcurrences = (GoogleComparator).Search(word.Text);
                word.Results.Add(new SearchLibraryResults(GoogleComparator.GetName(), numberOfOcurrences));

                var YahooComparator = new YahooFactory();
                numberOfOcurrences = (YahooComparator).Search(word.Text);
                word.Results.Add(new SearchLibraryResults(YahooComparator.GetName(), numberOfOcurrences));

                /* New Search Engines To Be Called */

            });

            return WordsToCompare;
        }
    }
}
