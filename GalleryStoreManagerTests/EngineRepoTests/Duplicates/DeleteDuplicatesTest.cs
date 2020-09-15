using System;
using System.IO;
using EnginesRepo.Engines;
using EnginesRepo.Engines.Duplicates;
using FilesTooling.Find;
using FilesTooling.Hasher;
using GalleryStoreManagerTests.Constans;
using NUnit.Framework;

namespace GalleryStoreManagerTests.EngineRepoTests.Duplicates
{
    [TestFixture]
    public class DeleteDuplicatesTest
    {
        [Test]
        public void TestDeletion() 
        {
            var testsDirectory = PathForTests.GetPathForTests();
            var targetDirectory = testsDirectory + @"/DuplicateTests/";

            DirectoryInfo di = Directory.CreateDirectory(testsDirectory + @"/DuplicateTests/");

            var originDirectory = testsDirectory + @"/Origin/";

            string[] files = Directory.GetFiles(originDirectory);
            foreach (string s in files)
            {
                // Use static Path methods to extract only the file name from the path.
                var fileName = Path.GetFileName(s);
                FileInfo f1 = new FileInfo(fileName);
                var destFile = Path.Combine(targetDirectory, fileName);
                File.Copy(s, destFile, true);
                var newName = Path.GetFileNameWithoutExtension(fileName);
                var newNameResoluted = string.Format("{0}{1}{2}", targetDirectory + @"/", newName + "_copy", f1.Extension);
                //f1.CopyTo(string.Format("{0}{1}{2}", testsDirectory, newName + "_copy", f1.Extension));

                File.Copy(destFile, newNameResoluted, true);
            }

            IGetFilesAndInformation getFilesAndInformation = new GetFilesAndInformation(new SeekFiles());
            var info = getFilesAndInformation.GetGenericFilesByPath(targetDirectory);

            IFileHasher fileHasher = new MD5FileHasher();

            IDeleteDuplicates IDeleteDuplicates = new DeleteDuplicates(fileHasher);
            IDeleteDuplicates.DeleteDupliacteFilesByGenericListOfFilesOnListAndGetNewList(info);

            try 
            {
                Directory.Delete(targetDirectory, true);
            }catch(Exception e) 
            {
                var hh = e.Message; 
            }



        }
    }
}
