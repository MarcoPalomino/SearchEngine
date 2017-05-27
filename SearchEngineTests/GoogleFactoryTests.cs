using NUnit.Framework;
using SearchEngine.SearchFactory.Factory;

namespace SearchEngineTests
{
    [TestFixture]
    public class GoogleFactoryTests
    {
        [Test]
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

        [Test]
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
