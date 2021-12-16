using System;
using Contract;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;


namespace Counter
{
    public class Counter : IRule
    {
        public string RuleName { get => "Counter"; }

        public Boolean ApplyRule(RuleContent renameContent)
        {
            try
            {
                foreach (FileInfo fileObject in renameContent.ListOriginalFiles)
                {
                    
                    if (fileObject.Name.Length + 1 > 253)
                    {
                        throw new Exception($"maximum length of the filename cannot exceed 255 characters");
                    }
                }

                int counter = 1;

                int index = 0;

                List<FileInfo> newFiles = new List<FileInfo>();
                foreach (FileInfo fileObject in renameContent.ListOriginalFiles)
                {
                    string sCounter = counter.ToString();
                    if (counter < 10)
                    {
                        // add 0 to 1 digit number 01 02 03
                        sCounter = "0" + sCounter;
                    }
                    string rawName = Path.GetFileNameWithoutExtension(fileObject.Name);
                    string newPath = $"{fileObject.DirectoryName}\\{rawName}_{sCounter}{fileObject.Extension}";
                    File.Move(fileObject.FullName, newPath);
                    newFiles.Add(new FileInfo(newPath));
                    counter++;
                    index++;
                }
                renameContent.ListOriginalFiles = newFiles;
                return true;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }
    }
}
