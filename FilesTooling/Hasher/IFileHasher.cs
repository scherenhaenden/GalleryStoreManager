using System;
namespace FilesTooling.Hasher
{
    public interface IFileHasher
    {
        string GetHashByFilePath(string path);
    }
}
