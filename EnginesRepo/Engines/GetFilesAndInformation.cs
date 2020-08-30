using System;
using System.Collections.Generic;
using FilesTooling.Find;
using ModelsRepo.Files;
using System.Linq;

namespace EnginesRepo.Engines
{
    public class GetFilesAndInformation: IGetFilesAndInformation
    {
        private readonly ISeekFiles seekFiles;

        public GetFilesAndInformation(ISeekFiles seekFiles)
        {
            this.seekFiles = seekFiles;
        }

        public IEnumerable<GenericFiles> GetGenericFilesByPath(string path)
        {
            var files = seekFiles.GetFilePathsByTargetDirectory(path);

            List<GenericFiles> genericFiles = new List<GenericFiles>();

            foreach(var file in files) 
            {
                var value = new GenericFiles() { RawName = file };
                genericFiles.Add(value);
            }

            return genericFiles;
        }
    }
}
