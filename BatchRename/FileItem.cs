﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BatchRename
{
    internal class FileItem
    {
        public string Name { get; set; }
        public string FullPath { get; set; }
        public string NewName { get; set; }
        public string Error { get; set; }
        public FileItem(string path)
        {
            FullPath = path;
            Name = Path.GetFileNameWithoutExtension(path);
            NewName = "";
            Error = "";
        }
    }
}
