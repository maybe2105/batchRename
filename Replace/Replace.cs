using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Contract;


namespace Replace
{
    public class Replace : IRule
    {
        public string RuleName { get => "Replace"; }

        public bool ApplyRule(RuleContent renameContent)
        {
            foreach (FileInfo fileObject in renameContent.ListOriginalFiles)
            {
                string rawName = Path.GetFileNameWithoutExtension(fileObject.Name);

                string AfterReplaceName = Regex.Replace(rawName, renameContent.Data, renameContent.Replacer);

                if (AfterReplaceName.Length > 255)
                {
                    throw new Exception($"maximum length of the filename cannot exceed 255 characters");
                }
                if (AfterReplaceName.IndexOfAny(Path.GetInvalidFileNameChars()) != -1)
                {
                    throw new Exception($"File name can not contain special character");
                }
            }

            int index = 0;

            List<FileInfo> newListFiles = new List<FileInfo>();

            foreach (FileInfo fileObject in renameContent.ListOriginalFiles)
            {
                string RawName = Path.GetFileNameWithoutExtension(fileObject.Name);

                string AfterReplaceName = Regex.Replace(RawName, renameContent.Data, renameContent.Replacer);

                string newPath = $"{fileObject.DirectoryName}\\{AfterReplaceName}{fileObject.Extension}";

                File.Move(fileObject.FullName, newPath);

                newListFiles.Add(new FileInfo(newPath));

                index++;
            }
            renameContent.ListOriginalFiles = newListFiles;

            return true;
        }
    }
}
