namespace Bin2Reg {
    internal interface IResourceHandler {
        bool SaveFile(byte[] file, string filePath);
        byte[] GetFile(string filePath);
    }
}