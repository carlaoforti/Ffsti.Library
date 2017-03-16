using System.Security.Cryptography;

namespace Ffsti.Library.Base.Cryptography
{
    public class AesCryptography : BaseCryptography<AesManaged>
    {
        public AesCryptography(string secretKey)
            : base(secretKey) { }

        public AesCryptography(byte[] secretKey)
            : base(secretKey) { }

        public AesCryptography()
        { }
    }
}
