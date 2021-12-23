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
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.Reflection;
using System.IO.Packaging;
using System.Windows.Markup;

namespace BatchRename
{
    /// <summary>
    /// Interaction logic for Replace.xaml
    /// </summary>
    public partial class Replace : Window
    {
        public Replace()
        {
            this.LoadViewFromUri("/BatchRename;component/replace.xaml");
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void btnDialogCancel_Click(object sender, RoutedEventArgs e)
        {

            this.DialogResult = false;
        }
        public string Regex
        {
            get { return regex.Text; }
        }
        public string NewName
        {
            get { return newName.Text; }
        }
    }

}
