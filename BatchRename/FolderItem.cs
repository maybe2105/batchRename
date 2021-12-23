using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BatchRename
{
    internal class FolderItem
    {
        public FileInfo folder { get; set; }
        public string Name { get; set; }
        public string FullPath { get; set; }
        public string NewName { get; set; }
        public string Error { get; set; }
        public FolderItem(string path)
        {
            folder = new FileInfo(path);
            FullPath = path;
            Name = Path.GetFileName(path);
            NewName = "";
            Error = "";
        }
    }
}
