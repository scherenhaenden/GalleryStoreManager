using System;
using System.Collections.Generic;
using ModelsRepo.Files;

namespace EnginesRepo.Engines.Duplicates
{
    public interface IDeleteDuplicates
    {
        IEnumerable<GenericFiles> DeleteDupliacteFilesByGenericListOfFilesOnListAndGetNewList(IEnumerable<GenericFiles> genericFiles);
    
    }
}
