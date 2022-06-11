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

namespace TimeSheet
{
    /// <summary>
    /// Interaction logic for EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        public EmployeeWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int money=0, phone=0;
            if (txtName.Text != String.Empty && txtAddress.Text != String.Empty && txtEmail.Text != String.Empty && txtPhone.Text != String.Empty && txtPassword.Text != String.Empty && txtMoney.Text != String.Empty) 
            {
                if (Int32.TryParse(txtPhone.Text, out phone) && Int32.TryParse(txtMoney.Text, out money)) { 
                    
                }
            }
        }
    }
}
