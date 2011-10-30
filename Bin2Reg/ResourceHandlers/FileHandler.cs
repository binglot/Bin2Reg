using System.IO;
using Bin2Reg.Interfaces;

namespace Bin2Reg.ResourceHandlers {
    internal class FileHandler : IResourceHandler {        
        public bool SaveFile(byte[] file, string filePath) {
            if (file == null)
                return false;

            return ByteArrayToFile(file, filePath);
        }
        
        public byte[] GetFile(string filePath) {
            if (!File.Exists(filePath))
                return null;

            return FileToByteArray(filePath);
        }

        private static byte[] FileToByteArray(string filePath) {
            byte[] buffer;

            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            using (var binaryReader = new BinaryReader(fileStream)) {
                var totalBytes = new FileInfo(filePath).Length;
                buffer = binaryReader.ReadBytes((int)totalBytes);
            }

            return buffer;
        }

        private bool ByteArrayToFile(byte[] file, string filePath) {
            using (var fileStream = new FileStream(filePath, FileMode.CreateNew, FileAccess.Write))
            using (var binaryWriter = new BinaryWriter(fileStream)) {
                binaryWriter.Write(file);
                return true;
            }

            // Why is this being an unreachable code?! If an exception was thrown then that's ok but otherwise...
            return false;
        }
    }
}