using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestRegExp
{
    [TestClass]
    public class UnitTestName
    {

        [TestMethod]
        public void TestCheckNameRegexValidity_EmptyString_Fails()
        {
            Assert.IsFalse(RegExp.MainWindow.CheckNameRegexValidity("", RegExp.MainWindow.nameRegex));
        }

        [TestMethod]
        public void TestCheckNameRegexValidity_OnlyOneLetter_Fails()
        {
            Assert.IsFalse(RegExp.MainWindow.CheckNameRegexValidity("a", RegExp.MainWindow.nameRegex));
        }

        [TestMethod]
        public void TestCheckNameRegexValidity_OnlyOneDash_Fails()
        {
            Assert.IsFalse(RegExp.MainWindow.CheckNameRegexValidity("-", RegExp.MainWindow.nameRegex));
        }

        [TestMethod]
        public void TestCheckNameRegexValidity_OnlyOneSpace_Fails()
        {
            Assert.IsFalse(RegExp.MainWindow.CheckNameRegexValidity(" ", RegExp.MainWindow.nameRegex));
        }

        [TestMethod]
        public void TestCheckNameRegexValidity_MultipleSpaces_Fails()
        {
            Assert.IsFalse(RegExp.MainWindow.CheckNameRegexValidity("  ", RegExp.MainWindow.nameRegex));
        }

        [TestMethod]
        public void TestCheckNameRegexValidity_MultipleSingleCharacters_Fails()
        {
            Assert.IsFalse(RegExp.MainWindow.CheckNameRegexValidity("a a", RegExp.MainWindow.nameRegex));
            Assert.IsFalse(RegExp.MainWindow.CheckNameRegexValidity("a a a", RegExp.MainWindow.nameRegex));
            Assert.IsFalse(RegExp.MainWindow.CheckNameRegexValidity("- a", RegExp.MainWindow.nameRegex));
        }

        [TestMethod]
        public void TestCheckNameRegexValidity_AtLeastTwoWordsWithAtLeastTwoCharacters_Pass()
        {
            Assert.IsTrue(RegExp.MainWindow.CheckNameRegexValidity("ab ab", RegExp.MainWindow.nameRegex));
            Assert.IsTrue(RegExp.MainWindow.CheckNameRegexValidity("abc abc", RegExp.MainWindow.nameRegex));
        }

        [TestMethod]
        public void TestCheckNameRegexValidity_Max3WordsWithAtLeastTwoCharactersAndOrDash_Pass()
        {
            Assert.IsTrue(RegExp.MainWindow.CheckNameRegexValidity("ab ab ab", RegExp.MainWindow.nameRegex));
            Assert.IsTrue(RegExp.MainWindow.CheckNameRegexValidity("a-b ab ab", RegExp.MainWindow.nameRegex));
            Assert.IsTrue(RegExp.MainWindow.CheckNameRegexValidity("Nagy-Sándor József", RegExp.MainWindow.nameRegex));
            Assert.IsTrue(RegExp.MainWindow.CheckNameRegexValidity("báró Botsinkay Jónás", RegExp.MainWindow.nameRegex));
            Assert.IsTrue(RegExp.MainWindow.CheckNameRegexValidity("dr Bubó Bubó", RegExp.MainWindow.nameRegex));
            Assert.IsTrue(RegExp.MainWindow.CheckNameRegexValidity("dr. Bubó Bubó", RegExp.MainWindow.nameRegex));
            Assert.IsTrue(RegExp.MainWindow.CheckNameRegexValidity("Dr. Bubó Bubó", RegExp.MainWindow.nameRegex));
            Assert.IsTrue(RegExp.MainWindow.CheckNameRegexValidity("ifj. Apja Fia", RegExp.MainWindow.nameRegex));
        }

        [TestMethod]
        public void TestCheckNameRegexValidity_MoreThan3Words_Fails()
        {
            Assert.IsFalse(RegExp.MainWindow.CheckNameRegexValidity("ab ab ab ", RegExp.MainWindow.nameRegex));
            Assert.IsFalse(RegExp.MainWindow.CheckNameRegexValidity("ab ab ab ab", RegExp.MainWindow.nameRegex));
            Assert.IsFalse(RegExp.MainWindow.CheckNameRegexValidity("ab ab ab -", RegExp.MainWindow.nameRegex));
        }

        [TestMethod]
        public void TestCheckNameRegexValidity_WordsContainingNumbersOrDashNotInsideOrUnderscore_Fails()
        {
            Assert.IsFalse(RegExp.MainWindow.CheckNameRegexValidity("ab a-", RegExp.MainWindow.nameRegex));
            Assert.IsFalse(RegExp.MainWindow.CheckNameRegexValidity("ab ab-", RegExp.MainWindow.nameRegex));
            Assert.IsFalse(RegExp.MainWindow.CheckNameRegexValidity("ab -ab", RegExp.MainWindow.nameRegex));
        }
    }
}
