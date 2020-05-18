using System;
using System.Collections.Generic;
using System.IO;

namespace FilesTooling.Find
{
    public interface ISeekFiles
    {
        string[] GetFilePathsByTargetDirectory(string path);

        IEnumerable<string> GetFilePathsByTargetDirectoryFindByExtensions(string path, string[] seekedExtensions);
    }
}
