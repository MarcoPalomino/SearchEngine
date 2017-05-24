using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Common
{
    public static class AppConstant
    {
        public static class SearchEngine{

            public const string Google = "Google";
            public const string Yahoo = "Yahoo";
            public const string Bing = "Bing";
            
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public static string[] GetAvailableSearchEngines()
            {
                var availableSearchEngines = new string[] { Google, Yahoo /*, Bing */ };
                return availableSearchEngines;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public const int numberOfWords = 2;

    }
}
