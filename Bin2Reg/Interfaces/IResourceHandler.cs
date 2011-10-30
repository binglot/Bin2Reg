namespace Bin2Reg.Interfaces {
    internal interface IResourceHandler {
        bool SaveFile(byte[] file, string filePath);
        byte[] GetFile(string filePath);
    }
}