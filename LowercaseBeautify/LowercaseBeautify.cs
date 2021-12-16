using System;
using Contract;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace LowercaseBeautify
{
    public class LowercaseBeautify : IRule
    {
        public string RuleName { get => "LowerCaseAndNoSpace"; }

        public bool ApplyRule(RuleContent renameContent)
        {
            int index = 0;

            List<FileInfo> newFiles = new List<FileInfo>();

            foreach (FileInfo fileObject in renameContent.ListOriginalFiles)
            {
                string rawFileName = Path.GetFileNameWithoutExtension(fileObject.Name);

                string lowerCaseName = rawFileName.ToLower();

                string beautifiedName = Regex.Replace(lowerCaseName, @"\s+", "");

                string newPath = $"{fileObject.DirectoryName}\\{beautifiedName}{fileObject.Extension}";

                File.Move(fileObject.FullName, newPath);

                newFiles.Add(new FileInfo(newPath));

                index++;
            }
            renameContent.ListOriginalFiles = newFiles;

            return true;
        }
    }
}
