using Contract;
using System;
using System.Collections.Generic;
using System.IO;


namespace Suffix
{
    public class Suffix : IRule
    {
        public string RuleName { get => "Suffix"; }

        public bool ApplyRule(RuleContent renameContent)
        {
            try
            {
                if (renameContent.Suffix.IndexOfAny(Path.GetInvalidFileNameChars()) != -1)
                {
                    throw new Exception($"Prefix can not contain invalid character");
                }
                foreach (FileInfo fileObject in renameContent.ListOriginalFiles)
                {
                    if (fileObject.Name.Length + renameContent.Suffix.Length > 255)
                    {
                        throw new Exception($"maximum length of the filename cannot exceed 255 characters");
                    }
                }
               
                int index = 0;

                List<FileInfo> newListFiles = new List<FileInfo>();

                foreach (FileInfo fileObject in renameContent.ListOriginalFiles)
                {
                    string rawName = Path.GetFileNameWithoutExtension(fileObject.Name);


                    string newPath = $"{fileObject.DirectoryName}\\{rawName}{renameContent.Suffix}{fileObject.Extension}";

                    File.Move(fileObject.FullName, newPath);

                    newListFiles.Add(new FileInfo(newPath));

                    index++;
                }
                renameContent.ListOriginalFiles = newListFiles;

                return true;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }
    }
}
