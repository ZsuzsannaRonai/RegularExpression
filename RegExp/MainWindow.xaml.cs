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

        private string nameRegex = @"^((\w{1,}-*\w{1,})\s{1}){1,2}(\w{1,}-*\w{1,})$";
        private string phoneRegex = @"";
        private string emailRegex = @"";

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private bool CheckNameRegexValidity()
        {
            name = txtName.Text;
            return Regex.IsMatch(name, nameRegex);
        }

        private bool CheckPhoneRegexValidity()
        {
            phone = txtPhone.Text;
            return Regex.IsMatch(phone, phoneRegex);
        }

        private bool CheckEmailRegexValidity()
        {
            email = txtEmail.Text;
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
