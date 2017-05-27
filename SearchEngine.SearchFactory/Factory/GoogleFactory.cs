using System;
using Google.Apis.Customsearch.v1;
using Google.Apis.Services;
using SearchEngine.Common;

namespace SearchEngine.SearchFactory.Factory
{
    public class GoogleFactory : ISearch
    {
        const string AppId = "YOUR_APP_ID";
        const string SearchEngineId = "009437644929674769216:pw_6okwojos";

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetName() {
            return AppConstant.SearchEngine.Google;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetAppId() {
            return AppId;
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
                /* Main Execution */
                var googleSearchService = new CustomsearchService(new BaseClientService.Initializer { ApiKey = AppId });
                var googleRequest = googleSearchService.Cse.List(wordToSearch);
                googleRequest.Cx = SearchEngineId;
                
                /* Results */
                totalOcurrences = googleRequest.Execute().SearchInformation.TotalResults;
            }
            catch (Exception)
            {
                totalOcurrences = 0;
            }

            return totalOcurrences;
        }
    }
}
