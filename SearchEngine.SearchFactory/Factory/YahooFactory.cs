using System;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json.Linq;
using SearchEngine.Common;

namespace SearchEngine.SearchFactory.Factory
{
    public class YahooFactory
    {
        public const int maxNumberOfOcurrences = 50000;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return AppConstant.SearchEngine.Yahoo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wordToSearch"></param>
        /// <returns></returns>
        public long? Search(string wordToSearch)
        {
            long? totalOcurrences = 0;
            try
            {
                /* Search Settings */
                var yahooServiceAddress = new StringBuilder();
                yahooServiceAddress.Append("http://query.yahooapis.com/v1/public/yql?");

                yahooServiceAddress.Append("q=" + Uri.UnescapeDataString(string.Format("select * from local.search(0,{0}) where zip='94085' and query='{1}'", maxNumberOfOcurrences.ToString(), wordToSearch)));
                yahooServiceAddress.Append("&format=json");
                yahooServiceAddress.Append("&diagnostics=false");

                var results = string.Empty;
                using (var wc = new WebClient())
                {
                    results = wc.DownloadString(yahooServiceAddress.ToString());
                }

                var resultData = JObject.Parse(results);
                var formattedResult = new JArray();

                if (resultData.HasValues)
                {
                    formattedResult = (JArray)resultData["query"]["results"]["Result"];
                    totalOcurrences = formattedResult.Count();
                }
            }
            catch (Exception)
            {
                totalOcurrences = 0;
            }

            return totalOcurrences;
        }
    }
    
}
