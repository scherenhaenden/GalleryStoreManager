using System;
using System.Collections.Generic;
using System.Linq;
using ModelsRepo.Files;

namespace EnginesRepo.Engines.Duplicates
{
    public class DeleteDuplicates: IDeleteDuplicates
    {
        public DeleteDuplicates()
        {
        }

        public IEnumerable<GenericFiles> DeleteDupliacteFilesByGenericListOfFilesOnListAndGetNewList(IEnumerable<GenericFiles> genericFiles)
        {

            var groups = GetGroupsOfDupesByPropertyLenght(genericFiles);


            throw new NotImplementedException();
        }


        public List<GenericFiles> EachGroupGetHash(IGrouping<long, GenericFiles> igr)
        {
            List<GenericFiles> Files = new List<GenericFiles>();
            foreach (var gr in igr)
            {
                gr.Hash = fileHasher.GetMD5ByFilePath(gr.FullPathOfFile);
                Files.Add(gr);
            }
            return Files;

        }


        private List<IGrouping<long, GenericFiles>> GetGroupsOfDupesByPropertyLenght(IEnumerable<GenericFiles> genericFiles) 
        {
            return genericFiles.GroupBy(x => x.GeneralFileInformation.Length).Where(x => x.Skip(1).Any()).ToList();
        }
    }
}
