using System;
using System.IO;

namespace ModelsRepo.Files
{

    //TODO: Take a look onto this class and refactor it if needed
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

        private FileInfo generalFileInformation;

        public FileInfo GeneralFileInformation
        {
            get
            {
                if(generalFileInformation == null) 
                {

                    CheckValues();
                }


                return generalFileInformation;
            }

        }

        protected void CheckValues()
        {
            if (RawName != "")
            {
                //_FileName = Path.GetFileName(RawName);
                //_Path = Path.GetDirectoryName(RawName);
                CreateFileInfo();
            }
        }

        protected void CreateFileInfo()
        {
            FileInfo FInfo = new FileInfo(RawName);
            generalFileInformation = FInfo;

        }

        public string Name => Path.GetFileName(RawName);
        public string HashValue;
        public string Size;
        public string CurrentPath => Path.GetFileName(RawName);
    }
}
