using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Contract
{
    public class RuleContent
    {
        public List<FileInfo> ListOriginalFiles { get; set; }
        public List<DirectoryInfo> ListOriginalFolders { get; set; }
        public string Data { get; set; }
        public string Replacer { get; set; }
       

        public void getFilesDirectories(FileInfo[] filesList, Boolean recursiveMode)
        {
            ListOriginalFiles = new List<FileInfo>();
            ListOriginalFolders = new List<DirectoryInfo>();
            foreach (FileInfo fileObject in filesList)
            {
                if (!File.Exists(fileObject.FullName) && !Directory.Exists(fileObject.FullName))
                {
                    continue;
                }
                if ((fileObject.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(fileObject.FullName);
                    if (!recursiveMode)
                    {
                        ListOriginalFolders.Add(directoryInfo);
                    }
                    else
                    {
                        FileInfo[] fileInfos = directoryInfo.GetFiles("*", SearchOption.AllDirectories);
                        DirectoryInfo[] directoryInfos = directoryInfo.GetDirectories("*", SearchOption.AllDirectories);
                        ListOriginalFiles.AddRange(fileInfos);
                        ListOriginalFolders.AddRange(directoryInfos);
                    }
                }
                else
                {
                    ListOriginalFiles.Add(fileObject);
                }
            }
        }
    }
}

