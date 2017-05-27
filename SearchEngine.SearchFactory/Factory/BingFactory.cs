using System;
using SearchEngine.Common;


namespace SearchEngine.SearchFactory.Factory
{
    public class BingFactory: ISearch
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return AppConstant.SearchEngine.Bing;
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
                /*To Be Implemented using Bing API v5 requests */
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Error when calculating {0} results: {1}", GetName(), ex.Message));
            }
            return totalOcurrences;
        }
    }
}
