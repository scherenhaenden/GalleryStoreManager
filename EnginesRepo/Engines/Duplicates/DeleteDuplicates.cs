using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FilesTooling.Hasher;
using ModelsRepo.Files;

namespace EnginesRepo.Engines.Duplicates
{
    public class DeleteDuplicates: IDeleteDuplicates
    {
        private readonly IFileHasher fileHasher;

        public DeleteDuplicates(IFileHasher fileHasher)
        {
            this.fileHasher = fileHasher;
        }

        public IEnumerable<GenericFiles> DeleteDupliacteFilesByGenericListOfFilesOnListAndGetNewList(IEnumerable<GenericFiles> genericFiles)
        {

            var groups = GetGroupsOfDupesByPropertyLenght(genericFiles);

            foreach(var group in groups) 
            {
                var resultGroupWithHash = EachGroupGetHash(group);
                var listOfFilesToDelete = GetDeletablleFiles(resultGroupWithHash);

                foreach(var fileToBeDeleted in listOfFilesToDelete) 
                {
                    File.Delete(fileToBeDeleted.RawName);
                    genericFiles.ToList().RemoveAll(x => x.RawName == fileToBeDeleted.RawName);

                }
            }

            return genericFiles;
        }


        public List<GenericFiles> EachGroupGetHash(IGrouping<long, GenericFiles> groupsOfDupes)
        {
            List<GenericFiles> Files = new List<GenericFiles>();
            foreach (var groupsOfDupe in groupsOfDupes)
            {
                groupsOfDupe.HashValue = fileHasher.GetHashByFilePath(groupsOfDupe.RawName);
                Files.Add(groupsOfDupe);
            }
            return Files;
        }


        private List<IGrouping<long, GenericFiles>> GetGroupsOfDupesByPropertyLenght(IEnumerable<GenericFiles> genericFiles) 
        {
            return genericFiles.GroupBy(x => x.GeneralFileInformation.Length).Where(x => x.Skip(1).Any()).ToList();
        }

        public List<GenericFiles> GetDeletablleFiles(List<GenericFiles> eachGroupGetHash)
        {
            string PivotValue = eachGroupGetHash[0].RawName;
            List<GenericFiles> Deletable = new List<GenericFiles>();

            var NotSame = eachGroupGetHash.Where(x => x.RawName != PivotValue).ToList();

            foreach (var file in NotSame)
            {
                if (file.RawName != PivotValue && file.HashValue == eachGroupGetHash[0].HashValue)
                {
                    Deletable.Add(file);
                }
            }
            return Deletable;
        }


    }
}
