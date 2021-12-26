using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Reflection;
using System.IO.Packaging;
using System.Windows.Markup;



namespace BatchRename
{
    /// <summary>
    /// Interaction logic for ChangeExtension.xaml
    /// </summary>
    public partial class ChangeExtension : Window
    {
        public ChangeExtension()
        {
            //    InitializeComponent();\
            this.LoadViewFromUri("/BatchRename;component/changeextension.xaml");

        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            string extension = txtAnswer.Text;
            if(extension != "")
                this.DialogResult = true;
            else
                MessageBox.Show("Extension can not be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public string Extension
        {
            get { return txtAnswer.Text; }
        }

        private void btnDialogCancel_Click(object sender, RoutedEventArgs e)
        {

            this.DialogResult = false;
        }
       
    }
    static class Extension
    {
        public static void LoadViewFromUri(this Window window, string baseUri)
        {
            try
            {
                var resourceLocater = new Uri(baseUri, UriKind.Relative);
                var exprCa = (PackagePart)typeof(Application).GetMethod("GetResourceOrContentPart", BindingFlags.NonPublic | BindingFlags.Static).Invoke(null, new object[] { resourceLocater });
                var stream = exprCa.GetStream();
                var uri = new Uri((Uri)typeof(BaseUriHelper).GetProperty("PackAppBaseUri", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null, null), resourceLocater);
                var parserContext = new ParserContext
                {
                    BaseUri = uri
                };
                typeof(XamlReader).GetMethod("LoadBaml", BindingFlags.NonPublic | BindingFlags.Static).Invoke(null, new object[] { stream, parserContext, window, true });

            }
            catch (Exception)
            {
                //log
            }
        }
    }
}
