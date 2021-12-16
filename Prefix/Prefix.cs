using System;
using System.Collections.Generic;
using System.IO;
using Contract;

namespace Prefix
{
    public class Prefix : IRule
    {
        public string RuleName { get => "Prefix"; }
        public bool ApplyRule(RuleContent renameContent)
        {
            try
            {
             
                if (renameContent.Prefix.IndexOfAny(Path.GetInvalidFileNameChars()) != -1)
                {
                    throw new Exception($"Prefix can not contain invalid character");
                }

                foreach (FileInfo fileObject in renameContent.ListOriginalFiles)
                {
                    if (fileObject.Name.Length + renameContent.Prefix.Length > 255)
                    {
                        throw new Exception($"maximum length of the filename cannot exceed 255 characters");
                    }
                }

                int index = 0;

                List<FileInfo> newListFiles = new List<FileInfo>();

                foreach (FileInfo fileObject in renameContent.ListOriginalFiles)
                {
                    string rawName = Path.GetFileNameWithoutExtension(fileObject.Name);

                    string newPath = $"{fileObject.DirectoryName}\\{renameContent.Prefix}{rawName}{fileObject.Extension}";

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
