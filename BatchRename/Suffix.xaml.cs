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
    /// Interaction logic for Suffix.xaml
    /// </summary>
    public partial class Suffix : Window
    {
        public Suffix()
        {
            this.LoadViewFromUri("/BatchRename;component/suffix.xaml");
        }
        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            string suffix = txtAnswer.Text;
            if (suffix != "")
                this.DialogResult = true;
            else
                MessageBox.Show("Suffix can not be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public string suffix
        {
            get { return txtAnswer.Text; }
        }

        private void btnDialogCancel_Click(object sender, RoutedEventArgs e)
        {

            this.DialogResult = false;
        }
    }
}
