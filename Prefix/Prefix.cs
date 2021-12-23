using System;
using System.Collections.Generic;
using System.IO;
using Contract;

namespace Prefix
{
    public class Prefix : IRule
    {
        public string RuleName { get => "Prefix"; }
        public ReturnApply ApplyRule(RuleContent renameContent)
        {
            try
            {
             
                if (renameContent.Data.IndexOfAny(Path.GetInvalidFileNameChars()) != -1)
                {
                    throw new Exception($"Prefix can not contain invalid character");
                }

                foreach (FileInfo fileObject in renameContent.ListOriginalFiles)
                {
                    if (fileObject.Name.Length + renameContent.Data.Length > 255)
                    {
                        throw new Exception($"maximum length of the filename cannot exceed 255 characters");
                    }
                }

                int index = 0;

                List<FileInfo> newListFiles = new List<FileInfo>();

                foreach (FileInfo fileObject in renameContent.ListOriginalFiles)
                {
                    string rawName = Path.GetFileNameWithoutExtension(fileObject.Name);

                    string newPath = $"{fileObject.DirectoryName}\\{renameContent.Data}{rawName}{fileObject.Extension}";

                    File.Move(fileObject.FullName, newPath);

                    newListFiles.Add(new FileInfo(newPath));

                    index++;
                }
                renameContent.ListOriginalFiles = newListFiles;


                FileInfo returnFile = newListFiles[0];
                return new ReturnApply(returnFile.Name, $"{returnFile.DirectoryName}\\{returnFile.Name}");
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }
    }
}
