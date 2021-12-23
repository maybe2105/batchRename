using System;
using Contract;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace Extension
{
    public class Extension : IRule
    {
        public string RuleName { get => "ChangeExtension"; }
        public ReturnApply ApplyRule(RuleContent renameContent)
        {
            try
            {
                Regex regex = new Regex(@"^[0-9a-zA-Z]+$");
                foreach (FileInfo fileObject in renameContent.ListOriginalFiles)
                {

                    if (fileObject.Name.Length + renameContent.Data.Length - fileObject.Extension.Length > 255)
                    {
                        throw new Exception($"maximum length of the filename cannot exceed 255 characters");
                    }
                    if (!regex.IsMatch(renameContent.Data))
                    {
                        throw new Exception($"Extension name can not contain special character");
                    }
                }
                // if everything is okay
                int index = 0;
                List<FileInfo> newFiles = new List<FileInfo>();
                foreach (FileInfo fileObject in renameContent.ListOriginalFiles)
                {
                    string newPath = Path.ChangeExtension(fileObject.FullName, renameContent.Data);
                    File.Move(fileObject.FullName, newPath);
                    newFiles.Add(new FileInfo(newPath));
                    index++;
                }
                
                renameContent.ListOriginalFiles = newFiles;

                FileInfo returnFile = newFiles[0];
                return new ReturnApply(returnFile.Name, $"{returnFile.DirectoryName}\\{returnFile.Name}");
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }

        }
    }
}
