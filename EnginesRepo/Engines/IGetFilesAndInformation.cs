using System.Collections.Generic;
using ModelsRepo.Files;

namespace EnginesRepo.Engines
{
    public interface IGetFilesAndInformation
    {
        IEnumerable<GenericFiles> GetGenericFilesByPath(string path);
     
    }
}
