using System;
using System.IO;
using System.Reflection;
using System.Linq;
using FilesTooling.Find;

namespace GalleryStoreManager.Tests
{
    public class FirstTest
    {
        public void Run() 
        {
            var mainPath = GetPathForTests();

            var originPath = mainPath + "/Origin/";
            var targetPath = mainPath + "/Store/";

            var result = GetFilesInOrigin(originPath);

            Console.WriteLine(mainPath);

            foreach(var res in result) 
            {
                Console.WriteLine(res);
            }
        }


        public string[] GetFilesInOrigin(string path) 
        {
            ISeekFiles seekFiles = new SeekFiles();
            return seekFiles.GetFilePathsByTargetDirectory(path);
        }



        public string GetPathForTests() 
        {

            var currentPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var getPathForTests = Directory.GetDirectories(currentPath + "/../../");
            var testPath = getPathForTests.SingleOrDefault(x => x.ToLower().Contains("tests"));
            var dirs = Directory.GetDirectories(testPath);


            var originDirectory = dirs.SingleOrDefault(x => x.ToLower().Contains("origin"));
            var value = Directory.GetParent(originDirectory);

            return value.FullName;

        }



    }
}
