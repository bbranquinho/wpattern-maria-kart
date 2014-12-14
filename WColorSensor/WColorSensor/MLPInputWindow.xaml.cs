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

namespace WColorSensor
{
    /// <summary>
    /// Interaction logic for MLPInputWindow.xaml
    /// </summary>
    public partial class MLPInputWindow : Window
    {
        private bool Cancel { get; set; }

        public MLPInputWindow()
        {
            InitializeComponent();
        }

        public new double[] ShowDialog()
        {
            Cancel = true;

            base.ShowDialog();

            try
            {
                if (!Cancel)
                {
                    return new double[]
                               {Int32.Parse(TextBoxR.Text), Int32.Parse(TextBoxG.Text), Int32.Parse(TextBoxB.Text)};
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            Cancel = false;
            base.Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Cancel = true;
            base.Close();
        }
    }
}
