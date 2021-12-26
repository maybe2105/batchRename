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
using System.Text.Json;
using System.Text.Json.Serialization;
using Contract;
using Newtonsoft.Json;

using DataFormats = System.Windows.Forms.DataFormats;
using SaveFileDialog = System.Windows.Forms.SaveFileDialog;
using MessageBox = System.Windows.MessageBox;

namespace BatchRename
{
    public partial class MainWindow : Window
    {
        List<RuleInfo> selectedRule;
        List<FileItem> fileList;

        public MainWindow()
        {
            InitializeComponent();

            LibLoader.loadDll();
            selectedRule = new List<RuleInfo>();
            fileList = new List<FileItem>();

            lv_method.ItemsSource = LibLoader.Rules;
            lv_methodSelected.ItemsSource = selectedRule;
            lv_files.ItemsSource = fileList;
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
            fileList.ForEach(file =>
            {
                if (file.NewName != "")
                {
                    string path = file.FullPath;
                    file.file = new FileInfo(path);
                    file.Name = file.NewName;
                    file.NewName = "";
                    file.Error = "";
                }
            });
            fileList.ForEach(file => {
                RuleContent ruleContent = new RuleContent();
                ruleContent.getFilesDirectories(new FileInfo[] { file.file }, true);
                selectedRule.ForEach(rule => {
                    if (file.Error == "")
                    {
                        ruleContent.Data = rule.RuleContent.Data;
                        ruleContent.Replacer = rule.RuleContent.Replacer;
                        try
                        {
                            ReturnApply result = rule.Rule.ApplyRule(ruleContent); 
                            file.FullPath = result.Path;
                            file.NewName = result.Name;
                            lv_files.Items.Refresh();
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

        private void onClickClearFileButton(object sender, RoutedEventArgs e)
        {
            fileList.Clear();
            lv_files.Items.Refresh();
        }

        private void onClickUpPresetMethodMenuButton(object sender, RoutedEventArgs e)
        {
             Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog() { 
                 Filter = "Json files (*.json)|*.json",
             };
            var fileContent = string.Empty;
            var filePath = string.Empty;
            if(dlg.ShowDialog() == true)
            {
                if (File.Exists(dlg.FileName))
                {
                    filePath = dlg.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = dlg.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        string json = reader.ReadToEnd();
                        List<Preset> items = JsonConvert.DeserializeObject<List<Preset>>(json);

                        items.ForEach(preset =>
                        {

                            IRule rule = LibLoader.Rules.Find(plugin => plugin.RuleName == preset.RuleName);
                            string ruleName = preset.RuleName;
                            string Data = preset.Data;
                            string Replacer = preset.Replacer;
                            switch (ruleName)
                            {
                                case "ChangeExtension":
                                    {
                                        RuleInfo ruleInfo = new RuleInfo(rule);
                                        ruleInfo.RuleContent.Data = Data;

                                        selectedRule.Add(ruleInfo);

                                        break;
                                    }
                                case "Replace":
                                    {

                                        RuleInfo ruleInfo = new RuleInfo(rule);
                                        ruleInfo.RuleContent.Data = Data;
                                        ruleInfo.RuleContent.Replacer = Replacer;
                                        selectedRule.Add(ruleInfo);

                                    }

                                    break;
                                case "Suffix":
                                    {
                                        RuleInfo ruleInfo = new RuleInfo(rule);
                                        ruleInfo.RuleContent.Data = Data;

                                        selectedRule.Add(ruleInfo);
                                    }
                                    break;
                                case "Prefix":
                                    {
                                        RuleInfo ruleInfo = new RuleInfo(rule);
                                        ruleInfo.RuleContent.Data = Data;

                                        selectedRule.Add(ruleInfo);
                                    }
                                    break;
                                case "PascalCase":
                                    {
                                        RuleInfo ruleInfo = new RuleInfo(rule);
                                        ruleInfo.RuleContent.Data = Data;

                                        selectedRule.Add(ruleInfo);
                                    }
                                    break;
                                default:
                                    selectedRule.Add(new RuleInfo(rule));
                                    break;
                            }

                            lv_methodSelected.Items.Refresh();
                        });
                    };

                    
                }
            }
        }

        private void onClickSavePresetMethodMenuButton(object sender, RoutedEventArgs e)
        {
            List<Preset> _data = new List<Preset>();


            selectedRule.ForEach(rule =>
            {
                if(rule.Rule.RuleName == "Replacer")
                {
                    _data.Add(new Preset
                    {
                        RuleName = rule.Rule.RuleName,
                        Data = rule.RuleContent.Data,
                        Replacer = rule.RuleContent.Replacer,
                    });;
                  //  _data.Add(new Preset(rule.Rule.RuleName,rule.RuleContent.Data,rule.RuleContent.Replacer));
                }else if(rule.Rule.RuleName == "ChangeExtension" | rule.Rule.RuleName == "Prefix" | rule.Rule.RuleName == "Suffix" | rule.Rule.RuleName == "Pascal")
                {
                    _data.Add(new Preset
                    {
                        RuleName = rule.Rule.RuleName,
                        Data = rule.RuleContent.Data,
                    }); ;
                    //      _data.Add(new Preset(rule.Rule.RuleName, rule.RuleContent.Data));
                }
                else
                {
                    _data.Add(new Preset
                    {
                        RuleName = rule.Rule.RuleName,
                    }); ;
                 //   _data.Add(new Preset(rule.Rule.RuleName));
                }
            });

            string json = JsonConvert.SerializeObject(_data.ToArray());

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Json files (*.json)|*.json";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                try { 
                File.WriteAllText(saveFileDialog1.FileName, json);
                   MessageBox.Show("Preset Saved As Json File", "Save Success", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                catch (Exception error)
                {
                   MessageBox.Show("Unable to save file, try again.", "Save error", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }

        }
        private void fileDrop(object sender, System.Windows.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Note that you can have more than one file.
                string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string path in paths)
                {
                    fileList.Add(new FileItem(path));
                }
                lv_files.Items.Refresh();
            }
        }

        private void TabItem_PreviewDragOver(object sender, System.Windows.DragEventArgs e)
        {
            e.Handled = true;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
      
    }
}
