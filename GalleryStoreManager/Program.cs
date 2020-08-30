using System;
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

            IGetFilesAndInformation getFilesAndInformation = new GetFilesAndInformation( new SeekFiles() );

            var info = getFilesAndInformation.GetGenericFilesByPath(@"/home/edward/Swap/zzzzzzzzzzzz/130ND750/");


            Console.WriteLine("Hello World!");
        }
    }
}
