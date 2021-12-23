using Contract;
using System;
using System.Collections.Generic;
using System.IO;

namespace Trim
{
    public class Trim :IRule
    {
        public string RuleName { get => "Trim"; }

        public ReturnApply ApplyRule (RuleContent renameContent)
        {
            try
            {
                foreach (FileInfo fileObject in renameContent.ListOriginalFiles)
                {
                    if (fileObject.Name.IndexOfAny(Path.GetInvalidFileNameChars()) != -1)
                    {
                        throw new Exception($"File name can not contain special characters");
                    }
                }

                int index = 0;

                List<FileInfo> newListFiles = new List<FileInfo>();

                foreach (FileInfo fileObject in renameContent.ListOriginalFiles)
                {
                    string rawName = Path.GetFileNameWithoutExtension(fileObject.Name);

                    string newPath = $"{fileObject.DirectoryName}\\{rawName.Trim()}{fileObject.Extension}";

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
