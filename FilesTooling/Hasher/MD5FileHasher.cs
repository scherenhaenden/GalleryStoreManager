using System;
using System.IO;
using System.Security.Cryptography;

namespace FilesTooling.Hasher
{
    public class MD5FileHasher: IFileHasher 
    {
        public string GetHashByFilePath(string path)
        {
            var sFile = new BufferedStream(File.OpenRead(path), 1200000);
            var hashvalue = MD5.Create();
            string First = BitConverter.ToString(hashvalue.ComputeHash(sFile)).Replace("-", string.Empty);
            sFile.Flush();
            sFile.Close();
            return First;
        }
    }
}
