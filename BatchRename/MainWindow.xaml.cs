using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

using Contract;

namespace BatchRename
{
    public partial class MainWindow : Window
    {
        List<RuleInfo> selectedRule;
        List<FileItem> fileList;
        List<FolderItem> folderList;
        public MainWindow()
        {
            InitializeComponent();

            LibLoader.loadDll();
            selectedRule = new List<RuleInfo>();
            fileList = new List<FileItem>();
            folderList = new List<FolderItem>();

            lv_method.ItemsSource = LibLoader.Rules;
            lv_methodSelected.ItemsSource = selectedRule;
            lv_files.ItemsSource = fileList;
            lv_folder.ItemsSource = folderList;
        }


        private void onClickClearMethodMenuButton(object sender, RoutedEventArgs e)
        {
            selectedRule.Clear();
            lv_methodSelected.Items.Refresh();
        }

        private void onCLickTopMethodMenuButton(object sender, RoutedEventArgs e)
        {

        }

        private void onClickUpMethodMenuButton(object sender, RoutedEventArgs e)
        {

        }

        private void onClickDownMethodMenuButton(object sender, RoutedEventArgs e)
        {

        }

        private void onClickBottomMethodMenuButton(object sender, RoutedEventArgs e)
        {

        }

        private void onTabSelection(object sender, SelectionChangedEventArgs e)
        {

        }

        private void onClickAddFileButton(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            if(dlg.ShowDialog() == true)
            {
                if (File.Exists(dlg.FileName))
                {
                    fileList.Add(new FileItem(dlg.FileName));
                }
                lv_files.Items.Refresh();
            }
            
        }

        private void onClickAddFolderButton(object sender, RoutedEventArgs e)
        {
            var folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            if (folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string folderPath = folderBrowser.SelectedPath;
                if (Directory.Exists(folderPath))
                {
                    folderList.Add(new FolderItem(folderPath));
                }
                lv_folder.Items.Refresh();
            }
        }

        private void onClickRuleItem(object sender, MouseButtonEventArgs e)
        {
            var item = (FrameworkElement)e.OriginalSource;
            IRule rule = (IRule)item.DataContext;
            string ruleName = rule.RuleName;
            switch (ruleName)
            {
                case "ChangeExtension":
                     ChangeExtension changeExtensionDialog = new ChangeExtension();
                     if (changeExtensionDialog.ShowDialog() == true)
                     {
                        RuleInfo ruleInfo = new RuleInfo(rule);
                        ruleInfo.RuleContent.Data = changeExtensionDialog.Extension;

                        selectedRule.Add(ruleInfo);
                     }
                     break;
                case "Replace":
                    Replace replaceDialog = new Replace();
                    if (replaceDialog.ShowDialog() == true)
                    {
                        RuleInfo ruleInfo = new RuleInfo(rule);
                        ruleInfo.RuleContent.Data = replaceDialog.Regex;
                        ruleInfo.RuleContent.Replacer = replaceDialog.NewName;

                        selectedRule.Add(ruleInfo);
                    }
                    break;
                case "Suffix":
                    Suffix suffixDialog = new Suffix();
                    if (suffixDialog.ShowDialog() == true)
                    {
                        RuleInfo ruleInfo = new RuleInfo(rule);
                        ruleInfo.RuleContent.Data = suffixDialog.suffix;

                        selectedRule.Add(ruleInfo);
                    }
                    break;
                case "Prefix":
                    Prefix prefixDialog = new Prefix();
                    if (prefixDialog.ShowDialog() == true)
                    {
                        RuleInfo ruleInfo = new RuleInfo(rule);
                        ruleInfo.RuleContent.Data = prefixDialog.prefix;

                        selectedRule.Add(ruleInfo);
                    }
                    break;
                case "PascalCase":
                    PascalCase pascalCaseDialog = new PascalCase();
                    if (pascalCaseDialog.ShowDialog() == true)
                    {
                        RuleInfo ruleInfo = new RuleInfo(rule);
                        ruleInfo.RuleContent.Data = pascalCaseDialog.Seperator;

                        selectedRule.Add(ruleInfo);
                    }
                    break;
                default:
                    selectedRule.Add(new RuleInfo(rule));
                    break;
            }

            lv_methodSelected.Items.Refresh();
        }

        private void onClickRuleSelectedItem(object sender, MouseButtonEventArgs e)
        {

            var item = (FrameworkElement)e.OriginalSource;
            selectedRule.Remove((RuleInfo)item.DataContext);
            lv_methodSelected.Items.Refresh();
        }

        private void onClickChangeFileButton(object sender, RoutedEventArgs e)
        {
            fileList.ForEach(file => {
                RuleContent ruleContent = new RuleContent();
                ruleContent.getFilesDirectories(new FileInfo[] { file.file }, false);
                selectedRule.ForEach(rule => {
                    if (file.Error == "")
                    {
                        ruleContent.Data = rule.RuleContent.Data;
                        ruleContent.Replacer = rule.RuleContent.Replacer;
                        try
                        {
                            Boolean result = rule.Rule.ApplyRule(ruleContent); // return true if success
                        }
                        catch (Exception error)
                        {
                            file.Error = error.Message;
                            lv_files.Items.Refresh();
                        }
                    }
                });
            });
        }

        private void onClickChangeFolderButton(object sender, RoutedEventArgs e)
        {
            folderList.ForEach(folder => {
                RuleContent ruleContent = new RuleContent();
                ruleContent.getFilesDirectories(new FileInfo[] { folder.folder }, false);
                selectedRule.ForEach(rule => {
                    if (folder.Error == "")
                    {
                        ruleContent.Data = rule.RuleContent.Data;
                        ruleContent.Replacer = rule.RuleContent.Replacer;
                        try
                        {
                            Boolean result = rule.Rule.ApplyRule(rule.RuleContent); // return true if success
                        }
                        catch (Exception error)
                        {
                            folder.Error = error.Message;
                            lv_files.Items.Refresh();
                        }
                    }
                });
            });
        }

        private void MenuMethod_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void onClickClearFileButton(object sender, RoutedEventArgs e)
        {
            fileList.Clear();
            lv_files.Items.Refresh();
        }
    }
}
