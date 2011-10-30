using System;
using System.Security.Cryptography;
using Bin2Reg.Interfaces;

namespace Bin2Reg.Encoders {
    public class DataCrypter : IEncoder {
        public DataCrypter() : this(DataProtectionScope.LocalMachine) { }

        public DataCrypter(DataProtectionScope scope) {
            ProtectionScope = scope;
        }

        public DataProtectionScope ProtectionScope { get; set; }

        public byte[] Encode(byte[] plain) {
            return Dpapi(ProtectedData.Protect, plain);
        }

        public byte[] Decode(byte[] cipher) {
            return Dpapi(ProtectedData.Unprotect, cipher);
        }

        private byte[] Dpapi(Func<byte[], byte[], DataProtectionScope, byte[]> transform, byte[] data) {
            return transform(data, null, ProtectionScope);
        }
    }
}
