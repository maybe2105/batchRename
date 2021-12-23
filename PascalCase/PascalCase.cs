using System;
using Contract;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace PascalCase
{
    public class PascalCase : IRule
    {
        public string RuleName { get => "PascalCase"; }

        public ReturnApply ApplyRule (RuleContent renameContent)
        {
            int index = 0;

            List<FileInfo> newFiles = new List<FileInfo>();

            foreach (FileInfo fileObject in renameContent.ListOriginalFiles)
            {
                string rawName = Path.GetFileNameWithoutExtension(fileObject.Name);

                string lowerCaseName = rawName.ToLower().Replace(renameContent.Data, " ");

                TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

                string pascalCaseName = textInfo.ToTitleCase(lowerCaseName).Replace(" ", string.Empty);

                string newPath = $"{fileObject.DirectoryName}\\{pascalCaseName}{fileObject.Extension}";

                File.Move(fileObject.FullName, newPath);

                newFiles.Add(new FileInfo(newPath));

                index++;
            }
            renameContent.ListOriginalFiles = newFiles;


            FileInfo returnFile = newFiles[0];
            return new ReturnApply(returnFile.Name, $"{returnFile.DirectoryName}\\{returnFile.Name}");
        }
    }
}
