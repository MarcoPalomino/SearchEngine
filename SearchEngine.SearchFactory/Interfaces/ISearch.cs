
namespace SearchEngine.SearchFactory
{
    public interface ISearch
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="WordsToSearch"></param>
        /// <returns></returns>
        long? Search(string WordsToSearch);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string GetName();
    }
}
