using Contract;
using System;
using System.IO;

namespace TestContract
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load dlls
            LibLoader.loadDll();
            Console.WriteLine(LibLoader.Rules[0].RuleName);

            Console.WriteLine("Welcome to the playground");

            // Set up dummies
            FileInfo dummy = new FileInfo(@"D:\dummy.txt");
            FileInfo dummyFolder = new FileInfo(@"D:\dummyfolder");

            RuleContent renameInfo = new RuleContent();
            renameInfo.getFilesDirectories(new FileInfo[] { dummy, dummyFolder }, true); // if recursive mode is on it will scann through all files in folders

            // Change file extension
            
                IRule changeExtRule = LibLoader.Rules.Find(plugin => plugin.RuleName == "ChangeExtension");
                renameInfo.Data = "";
                try
                {
                    Boolean result = changeExtRule.ApplyRule(renameInfo); // return true if success
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }
            
            // Trim file name
                IRule trimRule = LibLoader.Rules.Find(plugin => plugin.RuleName == "Trim");
                try
                {
                    Boolean result = trimRule.ApplyRule(renameInfo); // return true if success
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }
                
            // Add suffix counter
            IRule counterRule = LibLoader.Rules.Find(plugin => plugin.RuleName == "Counter");
            //try
            //{
            //    Boolean result = counterRule.ApplyRule(renameInfo); // return true if success
            //}
            //catch (Exception error)
            //{
            //    Console.WriteLine(error.Message);
            //}

            // Replace by regex or string
            IRule replaceRule = LibLoader.Rules.Find(plugin => plugin.RuleName == "Replace");
            renameInfo.Data = "file";
            renameInfo.Replacer = "newfile";
            //try
            //{
            //    Boolean result = replaceRule.ApplyRule(renameInfo); // return true if success
            //}
            //catch (Exception error)
            //{
            //    Console.WriteLine(error.Message);
            //}

            // Add suffix
            IRule suffixRule = LibLoader.Rules.Find(plugin => plugin.RuleName == "Suffix");
            renameInfo.Data = "suffix";
            //try
            //{
            //    Boolean result = suffixRule.ApplyRule(renameInfo);
            //} catch (Exception error)
            //{
            //    Console.WriteLine(error.Message);
            //}

            // Add prefix
            IRule prefixRule = LibLoader.Rules.Find(plugin => plugin.RuleName == "Prefix");
            renameInfo.Data = "prefix";
            //try
            //{
            //    Boolean result = prefixRule.ApplyRule(renameInfo);
            //}
            //catch (Exception error)
            //{
            //    Console.WriteLine(error.Message);
            //}

            // Lowercase and nospace
            IRule lwnsRule = LibLoader.Rules.Find(plugin => plugin.RuleName == "LowerCaseAndNoSpace");
            //try
            //{
            //    Boolean result = lwnsRule.ApplyRule(renameInfo);
            //}
            //catch (Exception error)
            //{
            //    Console.WriteLine(error.Message);
            //}

            // Pascal case
            IRule pascalRule = LibLoader.Rules.Find(plugin => plugin.RuleName == "PascalCase");
            renameInfo.Data = "-";
            try
            {
                Boolean result = pascalRule.ApplyRule(renameInfo);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }
    }
}