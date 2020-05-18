using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FilesTooling.Find
{
    public class SeekFiles: ISeekFiles
    {
        public string[] GetFilePathsByTargetDirectory(string path)
        {
            var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            return files;
        }

        public IEnumerable<string> GetFilePathsByTargetDirectoryFindByExtensions(string path, string[] seekedExtensions)
        {
            IEnumerable<string> result = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Where(file => seekedExtensions.Any(file.EndsWith));
            return result;
        }
    }
}
