using System;
using System.IO;
using System.Linq;

namespace GalleryStoreManagerTests.Constans
{
    public static class PathForTests
    {
        public static string GetPathForTests()
        {
            var locationOfAssembly = typeof(Tests).Assembly.Location;
            var currentPath = Path.GetDirectoryName(locationOfAssembly);

            var getPathForTests = Directory.GetDirectories(currentPath + "/../../");
            var testPath = getPathForTests.SingleOrDefault(x => x.ToLower().Contains("testfiles"));
            var dirs = Directory.GetDirectories(testPath);


            var originDirectory = dirs.SingleOrDefault(x => x.ToLower().Contains("origin"));
            var value = Directory.GetParent(originDirectory);

            return value.FullName;

        }
    }
}
