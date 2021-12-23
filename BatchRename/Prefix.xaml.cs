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

namespace BatchRename
{
    /// <summary>
    /// Interaction logic for Prefix.xaml
    /// </summary>
    public partial class Prefix : Window
    {
        public Prefix()
        {
            this.LoadViewFromUri("/BatchRename;component/prefix.xaml");
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        public string prefix
        {
            get { return txtAnswer.Text; }
        }

        private void btnDialogCancel_Click(object sender, RoutedEventArgs e)
        {

            this.DialogResult = false;
        }
    }
}
