using System;
using System.Collections.Generic;

namespace FilesTooling.FileTypes
{
    public class FileTypes: IFileTypes
    {
        public List<string> MediaImages()
        {
            var imagesExtensions = new List<string>();
            /*jpg*/
            imagesExtensions.AddRange(
                new List<string>() { "jpeg", "jpg", }
            );

            /*nef*/
            imagesExtensions.AddRange(
                new List<string>() { "nef", }
            );
        
            /*CR2*/
            imagesExtensions.AddRange(
                new List<string>() { ".cr2" }
            );

            return imagesExtensions;
        }
    }
}
