﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace Ffsti.Library.Cryptography
{
	public class AesCryptography : BaseCryptography<AesManaged>
	{
		public AesCryptography(string secretKey)
			: base(secretKey) { }

		public AesCryptography(byte[] secretKey)
			: base(secretKey) { }

		public AesCryptography()
			: base() { }
	}
}
