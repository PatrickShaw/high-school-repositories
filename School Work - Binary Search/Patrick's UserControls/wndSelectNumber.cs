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

namespace MyChem_Program
{
    /// <summary>
    /// Interaction logic for ChangeEmpiricalPercentage.xaml
    /// </summary>
    public partial class wndSelectNumber : Window
    {
        int amount;
        public void CheckIsNumeric(TextBox sender, TextCompositionEventArgs e)
        {
            decimal result;
            if (!(Decimal.TryParse(e.Text, out result)))
            {
                e.Handled = true;
            }
        }
        public wndSelectNumber(int indexT, int originalPercentageT)
        {
            amount = originalPercentageT;
            ElementPane paneTemp = new ElementPane(TableMode.display, indexT);
            paneTemp.Margin = new Thickness(10, 10, 0, 0);
            InitializeComponent();
            grid.Children.Add(paneTemp);
            Grid.SetColumn(paneTemp, 0);
            txtPercentage.Focus();
        }

        public void btnOkay_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public int GetPercentage()
        {
            try
            {
                return Convert.ToInt32(txtPercentage.Text);
            }
            catch { return 0; }
        }

        public void txtPercentage_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            CheckIsNumeric((TextBox)sender, e);
        }

        public void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            txtPercentage.Text = amount.ToString();
            Close();
        }
    }
}
