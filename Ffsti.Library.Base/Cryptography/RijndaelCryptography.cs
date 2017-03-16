using System.Security.Cryptography;

namespace Ffsti.Library.Base.Cryptography
{
	public class RijndaelCryptography : BaseCryptography<RijndaelManaged>
	{
		public RijndaelCryptography(string secretKey)
			: base(secretKey) { }

		public RijndaelCryptography(byte[] secretKey)
			: base(secretKey) { }

		public RijndaelCryptography()
		{ }
	}
}
