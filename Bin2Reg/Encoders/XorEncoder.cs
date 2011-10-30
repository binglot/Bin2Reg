using System.Text;
using Bin2Reg.Interfaces;

namespace Bin2Reg.Encoders {
    class XorEncoder : IEncoder {
        // Order alphabetically
        private const string Password = "Bart, Chris, Toby, Vicki";

        public XorEncoder() {
            Key = Encoding.ASCII.GetBytes(Password);
        }

        private byte[] Key { get; set; }

        public byte[] Encode(byte[] plain) {
            var keyLen = Key.Length;
            var plainLen = plain.Length;
            var cipher = new byte[plainLen];

            for (var i = 0; i < plainLen; i++) {
                var newValue = ByteXor(plain, keyLen, i);
                cipher[i] = (byte)(newValue);
            }

            return cipher;
        }

        private int ByteXor(byte[] plain, int keyLen, int counter) {
            return plain[counter] ^ Key[counter % keyLen];
        }

        public byte[] Decode(byte[] cipher) {
            return Encode(cipher);
        }
    }
}
