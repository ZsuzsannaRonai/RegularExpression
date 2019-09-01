using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace RegExp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string name;
        private string phone;
        private string email;

        private string nameRegex = @"";
        private string phoneRegex = @"";
        private string emailRegex = @"";

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            name = txtName.Text;
            phone = txtPhone.Text;
            email = txtEmail.Text;
        }

        private bool CheckNameRegexValidity()
        {
            return Regex.IsMatch(name, nameRegex);
        }

        private bool CheckPhoneRegexValidity()
        {
            return Regex.IsMatch(phone, phoneRegex);
        }

        private bool CheckEmailRegexValidity()
        {
            return Regex.IsMatch(email, emailRegex);
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckNameRegexValidity())
            {
                MessageBox.Show("Name doesn't match with its regular expression");
            }
            if (!CheckPhoneRegexValidity())
            {
                MessageBox.Show("Phone number doesn't match with its regular expression");
            }
            if (!CheckEmailRegexValidity())
            {
                MessageBox.Show("E-mail address doesn't match with its regular expression");
            }
            else if (CheckNameRegexValidity() && CheckPhoneRegexValidity() && CheckEmailRegexValidity())
            {
                MessageBox.Show("Congratulation, all fields match");
            }
        }
    }
}
