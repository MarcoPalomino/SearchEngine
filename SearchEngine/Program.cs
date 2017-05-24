using System;
using System.Collections.Generic;
using SearchEngine.Entities;
using SearchEngine.Util;

namespace SearchEngine
{
    class Program
    {
        
        private static SearchUtil _searchUtil;
        public static SearchUtil SearchUtil {
            get {
                if(_searchUtil == null)
                    return _searchUtil = new SearchUtil();

                return _searchUtil;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("[Formatting the words entered...]");

            /* Formatting all words from the given parameters */
            var wordsToSearch = SearchUtil.PrepareWordsToSearch(args);

            Console.WriteLine("[Do some validations...]");

            /* Validate the parameters entered*/
            if (SearchUtil.DoValidate(wordsToSearch))
            {
                Console.WriteLine("[Executing Search Engine...]");

                /* Using the Comparator class for performing the comparisson */
                var Comparator = new SearchComparator(wordsToSearch);
                Comparator.Run();

                SearchUtil.DisplayResults(Comparator);
            }

            Console.ReadLine();
        }

        
     
    }
}
