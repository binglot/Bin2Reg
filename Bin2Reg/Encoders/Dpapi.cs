using System;
using System.Security.Cryptography;
using Bin2Reg.Interfaces;

namespace Bin2Reg.Encoders {
    public class Dpapi : IEncoder {
        public Dpapi() : this(DataProtectionScope.LocalMachine) { }

        public Dpapi(DataProtectionScope scope) {
            ProtectionScope = scope;
        }

        public DataProtectionScope ProtectionScope { get; set; }

        public byte[] Encode(byte[] plain) {
            return Encryption(ProtectedData.Protect, plain);
        }

        public byte[] Decode(byte[] cipher) {
            return Encryption(ProtectedData.Unprotect, cipher);
        }

        private byte[] Encryption(Func<byte[], byte[], DataProtectionScope, byte[]> transform, byte[] data) {
            return transform(data, null, ProtectionScope);
        }
    }
}
