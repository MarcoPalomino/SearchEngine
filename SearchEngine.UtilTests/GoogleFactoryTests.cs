using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchEngine.SearchFactory.Factory;

namespace SearchEngine.Util.Tests
{
    [TestClass()]
    public class GoogleFactoryTests
    {
        /// <summary>
        /// 
        /// </summary>
        [TestMethod()]
        public void VerifyGoogleSearchReturnsElements()
        {
            /*Arrange*/
            var googleFactory = new GoogleFactory();
            long? results = 0;
            var testWord = "java";

            /*Act*/
            results = googleFactory.Search(testWord);

            /*Assert*/
            Assert.AreNotEqual(0, results);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod()]
        public void VerifyAppIdIsNotEmpty()
        {
            /*Arrange*/
            var googleFactory = new GoogleFactory();
            var isValid = true;

            /*Act*/
            isValid = !googleFactory.GetAppId().Equals(string.Empty);

            /*Assert*/
            Assert.AreEqual(true, isValid);
        }
    }
}