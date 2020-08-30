using System;
using System.IO;
using System.Linq;
using EnginesRepo.Engines;
using FilesTooling.Find;
using GalleryStoreManager.Tests;

namespace GalleryStoreManager
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            //new FirstTest().Run();
            var testsDirectory =GetPathForTests();

            IGetFilesAndInformation getFilesAndInformation = new GetFilesAndInformation( new SeekFiles() );

            var info = getFilesAndInformation.GetGenericFilesByPath(testsDirectory + @"/Origin/");


            Console.WriteLine("Hello World!");
        }


        public static string GetPathForTests()
        {
            var locationOfAssembly = typeof(MainClass).Assembly.Location;
            var currentPath = Path.GetDirectoryName(locationOfAssembly);

            var getPathForTests = Directory.GetDirectories(currentPath + "/../../");
            var testPath = getPathForTests.SingleOrDefault(x => x.ToLower().Contains("tests"));
            var dirs = Directory.GetDirectories(testPath);


            var originDirectory = dirs.SingleOrDefault(x => x.ToLower().Contains("origin"));
            var value = Directory.GetParent(originDirectory);

            return value.FullName;

        }
    }
}
