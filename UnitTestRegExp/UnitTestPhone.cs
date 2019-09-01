using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestRegExp
{
    [TestClass]
    public class UnitTestPhone
    {

        [TestMethod]
        public void TestCheckPhoneRegexValidity_EmptyString_Fails()
        {
            Assert.IsFalse(RegExp.MainWindow.CheckPhoneRegexValidity("", RegExp.MainWindow.phoneRegex));
        }

        [TestMethod]
        public void TestCheckPhoneRegexValidity_OptionalPlus1to5DigitsForwardSlash5to9Digits_Pass()
        {
            Assert.IsTrue(RegExp.MainWindow.CheckPhoneRegexValidity("+1/11111", RegExp.MainWindow.phoneRegex));
            Assert.IsTrue(RegExp.MainWindow.CheckPhoneRegexValidity("1/11111", RegExp.MainWindow.phoneRegex));
            Assert.IsTrue(RegExp.MainWindow.CheckPhoneRegexValidity("+11111/11111", RegExp.MainWindow.phoneRegex));
            Assert.IsTrue(RegExp.MainWindow.CheckPhoneRegexValidity("11111/11111", RegExp.MainWindow.phoneRegex));
            Assert.IsTrue(RegExp.MainWindow.CheckPhoneRegexValidity("+11111/111111111", RegExp.MainWindow.phoneRegex));
            Assert.IsTrue(RegExp.MainWindow.CheckPhoneRegexValidity("11111/111111111", RegExp.MainWindow.phoneRegex));
        }

        [TestMethod]
        public void TestCheckPhoneRegexValidity_NonDigits_Fails()
        {
            Assert.IsFalse(RegExp.MainWindow.CheckPhoneRegexValidity("+a/11111", RegExp.MainWindow.phoneRegex));
            Assert.IsFalse(RegExp.MainWindow.CheckPhoneRegexValidity("+a/.1111", RegExp.MainWindow.phoneRegex));
            Assert.IsFalse(RegExp.MainWindow.CheckPhoneRegexValidity("+a/:1111", RegExp.MainWindow.phoneRegex));
            Assert.IsFalse(RegExp.MainWindow.CheckPhoneRegexValidity("+a/,1111", RegExp.MainWindow.phoneRegex));
            Assert.IsFalse(RegExp.MainWindow.CheckPhoneRegexValidity("+a/;1111", RegExp.MainWindow.phoneRegex));
            Assert.IsFalse(RegExp.MainWindow.CheckPhoneRegexValidity("+a/?1111", RegExp.MainWindow.phoneRegex));
            Assert.IsFalse(RegExp.MainWindow.CheckPhoneRegexValidity("+a/!1111", RegExp.MainWindow.phoneRegex));
            Assert.IsFalse(RegExp.MainWindow.CheckPhoneRegexValidity("+a/_1111", RegExp.MainWindow.phoneRegex));
            Assert.IsFalse(RegExp.MainWindow.CheckPhoneRegexValidity("+a/-1111", RegExp.MainWindow.phoneRegex));
            Assert.IsFalse(RegExp.MainWindow.CheckPhoneRegexValidity("+a/+1111", RegExp.MainWindow.phoneRegex));
            Assert.IsFalse(RegExp.MainWindow.CheckPhoneRegexValidity("+a/ 1111", RegExp.MainWindow.phoneRegex));
            Assert.IsFalse(RegExp.MainWindow.CheckPhoneRegexValidity("+1/aaaaa", RegExp.MainWindow.phoneRegex));
        }

        [TestMethod]
        public void TestCheckPhoneRegexValidity_OverLimit_Fails()
        {
            Assert.IsFalse(RegExp.MainWindow.CheckPhoneRegexValidity("+111111/111111111", RegExp.MainWindow.phoneRegex));
            Assert.IsFalse(RegExp.MainWindow.CheckPhoneRegexValidity("+11111/1111111111", RegExp.MainWindow.phoneRegex));
            Assert.IsFalse(RegExp.MainWindow.CheckPhoneRegexValidity("+111111/1111111111", RegExp.MainWindow.phoneRegex));
        }

        [TestMethod]
        public void TestCheckPhoneRegexValidity_TrailingLeadingSpace_Fails()
        {
            Assert.IsFalse(RegExp.MainWindow.CheckPhoneRegexValidity("+1/11111 ", RegExp.MainWindow.phoneRegex));
            Assert.IsFalse(RegExp.MainWindow.CheckPhoneRegexValidity("+11111/111111111 ", RegExp.MainWindow.phoneRegex));
            Assert.IsFalse(RegExp.MainWindow.CheckPhoneRegexValidity(" +1/11111 ", RegExp.MainWindow.phoneRegex));
            Assert.IsFalse(RegExp.MainWindow.CheckPhoneRegexValidity(" +11111/111111111 ", RegExp.MainWindow.phoneRegex));
        }
    }
}