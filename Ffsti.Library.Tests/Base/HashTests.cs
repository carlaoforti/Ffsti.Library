using Ffsti.Library.Base.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ffsti.Library.Tests.Base
{
    [TestClass]
    public class HashTests
    {
        [TestMethod]
        public void Should_Pass_Md5Hash()
        {
            var compare = "eb67ac9650e6da8b57e2b79687038c73".ToUpper();
            var hash = "This is a MD5 test".Md5Hash();

            Assert.AreEqual(compare, hash);
        }

        [TestMethod]
        public void Should_Not_Pass_Md5Hash()
        {
            var compare = "eb67ac9650e6da8b57e2b79687038c73".ToUpper();
            var hash = "This is a failed MD5 test".Md5Hash();

            Assert.AreNotEqual(compare, hash);
        }

        [TestMethod]
        public void Should_Pass_Sha1Hash()
        {
            var compare = "96dfef3628a845bdffbd639a182ffc10477427af".ToUpper();
            var hash = "This is a SHA-1 Test".Sha1Hash();

            Assert.AreEqual(compare, hash);
        }

        [TestMethod]
        public void Should_Not_Pass_Sha1Hash()
        {
            var compare = "96dfef3628a845bdffbd639a182ffc10477427af".ToUpper();
            var hash = "This is a failed SHA-1 Test".Sha1Hash();

            Assert.AreNotEqual(compare, hash);
        }

        [TestMethod]
        public void Should_Pass_Sha256Hash()
        {
            var compare = "0d5c57b936cc678a0e9e076e1ec6b06d8eb7ac372630e1b27200a0e57a0bcd09".ToUpper();
            var hash = "This is a SHA256 test".Sha256Hash();

            Assert.AreEqual(compare, hash);
        }

        [TestMethod]
        public void Should_Not_Pass_Sha256Hash()
        {
            var compare = "0d5c57b936cc678a0e9e076e1ec6b06d8eb7ac372630e1b27200a0e57a0bcd09".ToUpper();
            var hash = "This is a failed SHA256 test".Sha256Hash();

            Assert.AreNotEqual(compare, hash);
        }
    }
}
