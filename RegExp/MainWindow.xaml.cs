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

        public static string nameRegex = @"^((\w{1,}-*\w{1,}\.*)\s{1}){1,2}\w{1,}-*\w{1,}$";
        public static string phoneRegex = @"^\+*\d{1,5}/{1}\d{5,9}$";
        public static string emailRegex = @"^\w{1,}\.*\w{1,}\@\w{1,}\.*\w{1,}\.[a-z]{2,3}$";

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public static bool CheckNameRegexValidity(string nameString, string regexString)
        {
            return Regex.IsMatch(nameString, regexString);
        }

        public static bool CheckPhoneRegexValidity(string nameString, string regexString)
        {
            return Regex.IsMatch(nameString, regexString);
        }

        public static bool CheckEmailRegexValidity(string nameString, string regexString)
        {
            return Regex.IsMatch(nameString, regexString);
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckNameRegexValidity(txtName.Text, nameRegex))
            {
                MessageBox.Show("Name doesn't match with its regular expression");
            }
            if (!CheckPhoneRegexValidity(txtPhone.Text, phoneRegex))
            {
                MessageBox.Show("Phone number doesn't match with its regular expression");
            }
            if (!CheckEmailRegexValidity(txtEmail.Text, emailRegex))
            {
                MessageBox.Show("E-mail address doesn't match with its regular expression");
            }
            else if (CheckNameRegexValidity(txtName.Text, nameRegex) 
                && CheckPhoneRegexValidity(txtPhone.Text, phoneRegex) 
                && CheckEmailRegexValidity(txtEmail.Text, emailRegex))
            {
                MessageBox.Show("Congratulation, all fields match");
            }
        }

        public static string phonePattern = @"^\(?(\d{3})\)?[\s\-]?(\d{3})\-?(\d{4})$";
        public static string phonePatternFix = @"^\((\d{3})\)[\s](\d{3})\-(\d{4})$";

        private void BtnReformat_Click(object sender, RoutedEventArgs e)
        {
            

            if (Regex.IsMatch(refPhone.Text, phonePatternFix))
            {
                resPhone.Text = "no reformatting needed";
            }
            else if (Regex.IsMatch(refPhone.Text, phonePattern))
            {
                string reformattedPhone = ReformatPhone(refPhone.Text);
                resPhone.Text = reformattedPhone;
            }
            else
            {
                resPhone.Text = "reformatting not possible";
            }
        }

        public string ReformatPhone(string phoneString)
        {
            return Regex.Replace(phoneString, phonePattern, phonePatternFix);
        }
    }
}
