using System;
using System.IO;

namespace ModelsRepo.Files
{
    public class GenericFiles
    {

        private string rawName;

        public string RawName 
        {
            get
            {
                return this.rawName;
            }
            set
            {
                this.rawName = value;
            }

        }

        public string Name => Path.GetFileName(RawName);
        public string HashValue;
        public string Size;
        public string CurrentPath
        {
            get
            {
                return Path.GetDirectoryName(rawName);
            }
        }

    }
}
