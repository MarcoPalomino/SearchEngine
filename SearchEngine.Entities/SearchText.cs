using System.Collections.Generic;

namespace SearchEngine.Entities
{
    public class SearchText
    {
        /// <summary>
        /// 
        /// </summary>
        public string Text = string.Empty;
        
        /// <summary>
        /// 
        /// </summary>
        private List<SearchLibraryResults>  _results = new List<SearchLibraryResults>();
        public List<SearchLibraryResults> Results
        {
            get {
                if (_results == null)
                    _results = new List<SearchLibraryResults>();
                return _results;
            }
            set {
                this._results = value;     
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="word"></param>
        public SearchText(string word) {
            this.Text = word;
        }
        
    }
}
