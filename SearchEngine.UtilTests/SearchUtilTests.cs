using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchEngine.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchEngine.Entities;

namespace SearchEngine.Util.Tests
{
    [TestClass()]
    public class SearchUtilTests
    {
        /// <summary>
        /// 
        /// </summary>
        [TestMethod()]
        public void DoValidateFailsWhenThereIsOnlyOneWord()
        {
            /*Arrange*/
            var searchUtil = new SearchUtil();
            var searchText = new SearchText(".net");

            var words = new SearchText[] { searchText };
            var isValid = true;

            /*Act*/
            isValid = searchUtil.DoValidate(words.ToList());

            /*Assert*/
            Assert.AreEqual(false, isValid);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod()]
        public void DoValidateFailsWhenThereIsNoWord()
        {
            /*Arrange*/
            var searchUtil = new SearchUtil();

            var words = new SearchText[] {};
            var isValid = true;

            /*Act*/
            isValid = searchUtil.DoValidate(words.ToList());

            /*Assert*/
            Assert.AreEqual(false, isValid);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod()]
        public void DoValidateSuccessWhenThereAreAtLeastTwoWords()
        {
            /*Arrange*/
            var searchUtil = new SearchUtil();
            var word1 = new SearchText(".net");
            var word2 = new SearchText(".net");

            var words = new SearchText[] { word1, word2 };
            var isValid = true;

            /*Act*/
            isValid = searchUtil.DoValidate(words.ToList());

            /*Assert*/
            Assert.AreEqual(true, isValid);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod()]
        public void DoValidateFailsWhenThereAreDuplicatedWords()
        {
            /*Arrange*/
            var searchUtil = new SearchUtil();
            var searchText1 = new SearchText("java");
            var searchText2 = new SearchText("java");

            var words = new SearchText[] { searchText1, searchText2 };
            var isValid = true;

            /*Act*/
            isValid = searchUtil.DoValidate(words.ToList());

            /*Assert*/
            Assert.AreEqual(false, isValid);
        }
    }
}