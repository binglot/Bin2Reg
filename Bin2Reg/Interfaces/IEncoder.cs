namespace Bin2Reg.Interfaces {
    internal interface IEncoder {
        byte[] Encode(byte[] plain);
        byte[] Decode(byte[] cipher);
    }
}