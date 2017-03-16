using System.Security.Cryptography;
using Ffsti.Library.Base.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ffsti.Library.Tests.Base
{
    [TestClass]
    public class CryptographyTest
    {
        [TestMethod]
        public void Should_Pass_AesCrypto()
        {
            var crypto = new AesCryptography();

            const string originalString = "AES cryptography";
            var cryptoString = crypto.Encrypt(originalString);
            var decryptString = crypto.Decrypt(cryptoString);

            Assert.AreEqual(originalString, decryptString);
        }

        [TestMethod]
        public void Should_Pass_RijndaelCrypto()
        {
            var crypto = new RijndaelCryptography();

            const string originalString = "Rijndael cryptography";
            var cryptoString = crypto.Encrypt(originalString);
            var decryptString = crypto.Decrypt(cryptoString);

            Assert.AreEqual(originalString, decryptString);
        }

        [TestMethod]
        public void Should_Pass_BaseCrypto()
        {
            var crypto = new BaseCryptography<RijndaelManaged>();

            const string originalString = "Rijndael cryptography";
            var cryptoString = crypto.Encrypt(originalString);
            var decryptString = crypto.Decrypt(cryptoString);

            Assert.AreEqual(originalString, decryptString);
        }
    }
}
