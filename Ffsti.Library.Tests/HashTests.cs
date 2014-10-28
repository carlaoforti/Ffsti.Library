﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ffsti.Library.Tests
{
	[TestClass]
	public class HashTests
	{
		[TestMethod]
		public void TestMD5Hash()
		{
			var compare = "eb67ac9650e6da8b57e2b79687038c73".ToUpper();
			var hash = "This is a MD5 test".MD5Hash();

			var db = new Ffsti.Library.Database.Db("", "");
			

			Assert.AreEqual(compare, hash);
		}

		[TestMethod]
		public void TestSHA1Hash()
		{
			var compare = "96dfef3628a845bdffbd639a182ffc10477427af".ToUpper();
			var hash = "This is a SHA-1 Test".SHA1Hash();

			Assert.AreEqual(compare, hash);
		}

		[TestMethod]
		public void TestSHA256Hash()
		{
			var compare = "0d5c57b936cc678a0e9e076e1ec6b06d8eb7ac372630e1b27200a0e57a0bcd09".ToUpper();
			var hash = "This is a SHA256 test".SHA256Hash();

			Assert.AreEqual(compare, hash);
		}
	}
}
