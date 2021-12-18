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
        List<IRule> selectedRule;
        List<FileItem> fileList;
        List<FolderItem> folderList;
        public MainWindow()
        {
            InitializeComponent();

            LibLoader.loadDll();
            selectedRule = new List<IRule>();
            fileList = new List<FileItem>();
            folderList = new List<FolderItem>();

            lv_method.ItemsSource = LibLoader.Rules;
            lv_methodSelected.ItemsSource = selectedRule;
            lv_files.ItemsSource = fileList;
            lv_folder.ItemsSource = folderList;
        }

        private void MenuMethod_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void onClickClearMethodMenuButton(object sender, RoutedEventArgs e)
        {

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

        private void onClickContextMenuItem(object sender, RoutedEventArgs e)
        {

        }

        private void onClickDeleteMethod(object sender, RoutedEventArgs e)
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

        private void onCLickTopFileMenuButton(object sender, RoutedEventArgs e)
        {

        }

        private void onClickUpFileMenuButton(object sender, RoutedEventArgs e)
        {

        }

        private void onClickDownFileMenuButton(object sender, RoutedEventArgs e)
        {

        }

        private void onClickBottomFileMenuButton(object sender, RoutedEventArgs e)
        {

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

        private void onCLickTopFolderMenuButton(object sender, RoutedEventArgs e)
        {

        }

        private void onClickUpFolderMenuButton(object sender, RoutedEventArgs e)
        {

        }

        private void onClickDownFolderMenuButton(object sender, RoutedEventArgs e)
        {

        }

        private void onClickBottomFolderMenuButton(object sender, RoutedEventArgs e)
        {

        }


        private void onClickRuleItem(object sender, MouseButtonEventArgs e)
        {
            var item = (FrameworkElement)e.OriginalSource;
            selectedRule.Add((Contract.IRule)item.DataContext);

            lv_methodSelected.Items.Refresh();
        }

        private void onClickRuleSelectedItem(object sender, MouseButtonEventArgs e)
        {

            var item = (FrameworkElement)e.OriginalSource;
            selectedRule.Remove((Contract.IRule)item.DataContext);
            lv_methodSelected.Items.Refresh();
        }
    }
}
