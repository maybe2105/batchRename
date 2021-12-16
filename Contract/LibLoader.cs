﻿using Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;


namespace Contract
{
    public class LibLoader
    {
        public static List<IRule> Rules { get; set; }
        public static void loadDll()
        {
            string exePath = Assembly.GetExecutingAssembly().Location;

            string folder = Path.GetDirectoryName(exePath);

            FileInfo[] fis = new DirectoryInfo(folder).GetFiles("*.dll");

            Rules = new List<IRule>();

            foreach (FileInfo fileInfo in fis)
            {
                var domain = AppDomain.CurrentDomain;

                Assembly assembly = Assembly.LoadFile(fileInfo.FullName);

                Type[] types = assembly.GetTypes();

                foreach (var type in types)
                {
                    if (type.IsClass && typeof(IRule).IsAssignableFrom(type))
                    {
                        Rules.Add(Activator.CreateInstance(type) as IRule);
                    }
                }
            }
        }
    }
}
