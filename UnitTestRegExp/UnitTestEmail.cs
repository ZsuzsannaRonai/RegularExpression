using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestRegExp
{
    [TestClass]
    public class UnitTestEmail
    {

        [TestMethod]
        public void TestCheckEmailRegexValidity_EmptyString_Fails()
        {
            Assert.IsFalse(RegExp.MainWindow.CheckEmailRegexValidity("", RegExp.MainWindow.emailRegex));
        }

        [TestMethod]
        public void TestCheckEmailRegexValidity_MatchingPattern_Pass()
        {
            Assert.IsTrue(RegExp.MainWindow.CheckEmailRegexValidity("aa@aa.aa", RegExp.MainWindow.emailRegex));
            Assert.IsTrue(RegExp.MainWindow.CheckEmailRegexValidity("aa@aa.aaa", RegExp.MainWindow.emailRegex));
            Assert.IsTrue(RegExp.MainWindow.CheckEmailRegexValidity("aa@a.a.aa", RegExp.MainWindow.emailRegex));
            Assert.IsTrue(RegExp.MainWindow.CheckEmailRegexValidity("a.a@a.a.aa", RegExp.MainWindow.emailRegex));
            Assert.IsTrue(RegExp.MainWindow.CheckEmailRegexValidity("a_a@a.a.aa", RegExp.MainWindow.emailRegex));
            Assert.IsTrue(RegExp.MainWindow.CheckEmailRegexValidity("mentor_007@example.com", RegExp.MainWindow.emailRegex));
            Assert.IsTrue(RegExp.MainWindow.CheckEmailRegexValidity("BugsBunny@looney.toons.io", RegExp.MainWindow.emailRegex));
            Assert.IsTrue(RegExp.MainWindow.CheckEmailRegexValidity("duffy.duck@withperiod.com", RegExp.MainWindow.emailRegex));
            Assert.IsTrue(RegExp.MainWindow.CheckEmailRegexValidity("a_a@a.a.aa", RegExp.MainWindow.emailRegex));
        }

        [TestMethod]
        public void TestCheckEmailRegexValidity_InvalidPattern_Fails()
        {
            Assert.IsFalse(RegExp.MainWindow.CheckEmailRegexValidity("a:a@aa.aa", RegExp.MainWindow.emailRegex));
            Assert.IsFalse(RegExp.MainWindow.CheckEmailRegexValidity("a;a@aa.aa", RegExp.MainWindow.emailRegex));
            Assert.IsFalse(RegExp.MainWindow.CheckEmailRegexValidity("a-a@aa.aa", RegExp.MainWindow.emailRegex));
            Assert.IsFalse(RegExp.MainWindow.CheckEmailRegexValidity("a?a@aa.aa", RegExp.MainWindow.emailRegex));
            Assert.IsFalse(RegExp.MainWindow.CheckEmailRegexValidity("a!a@aa.aa", RegExp.MainWindow.emailRegex));
        }

        [TestMethod]
        public void TestCheckEmailRegexValidity_LongDomain_Fails()
        {
            Assert.IsFalse(RegExp.MainWindow.CheckEmailRegexValidity("aa@aa.aaaa", RegExp.MainWindow.emailRegex));
            Assert.IsFalse(RegExp.MainWindow.CheckEmailRegexValidity("elmer_fudd@long.domain", RegExp.MainWindow.emailRegex));
            
        }

        [TestMethod]
        public void TestCheckEmailRegexValidity_MissingAtSign_Fails()
        {
            Assert.IsFalse(RegExp.MainWindow.CheckEmailRegexValidity("aaaa.aa", RegExp.MainWindow.emailRegex));
            Assert.IsFalse(RegExp.MainWindow.CheckEmailRegexValidity("aaaa.aaa", RegExp.MainWindow.emailRegex));
            Assert.IsFalse(RegExp.MainWindow.CheckEmailRegexValidity("aaa.a.aa", RegExp.MainWindow.emailRegex));
            Assert.IsFalse(RegExp.MainWindow.CheckEmailRegexValidity("a.aa.a.aa", RegExp.MainWindow.emailRegex));
            Assert.IsFalse(RegExp.MainWindow.CheckEmailRegexValidity("a_aa.a.aa", RegExp.MainWindow.emailRegex));
        }

        [TestMethod]
        public void TestCheckEmailRegexValidity_TrailindLeadingSpace_Fails()
        {
            Assert.IsFalse(RegExp.MainWindow.CheckEmailRegexValidity(" aa@aa.aa", RegExp.MainWindow.emailRegex));
            Assert.IsFalse(RegExp.MainWindow.CheckEmailRegexValidity("aa@aa.aa ", RegExp.MainWindow.emailRegex));
        }

        [TestMethod]
        public void TestCheckEmailRegexValidity_InsideSpace_Fails()
        {
            Assert.IsFalse(RegExp.MainWindow.CheckEmailRegexValidity("a a@aa.aa", RegExp.MainWindow.emailRegex));
            Assert.IsFalse(RegExp.MainWindow.CheckEmailRegexValidity("aa@a a.aa", RegExp.MainWindow.emailRegex));
            Assert.IsFalse(RegExp.MainWindow.CheckEmailRegexValidity("aa@aa.a a", RegExp.MainWindow.emailRegex));
        }
    }
}
