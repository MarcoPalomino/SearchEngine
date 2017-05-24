
namespace SearchEngine.Entities
{
    public class SearchLibraryResults
    {
        public string EngineName { get; set; }

        public long? NumberOfOcurrencies { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="numberOfOcurrencies"></param>
        public SearchLibraryResults(string name, long? numberOfOcurrencies) {
            EngineName = name;
            NumberOfOcurrencies = numberOfOcurrencies;
        }
    }
}
