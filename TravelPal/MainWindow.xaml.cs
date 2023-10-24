using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TravelPal.Managers;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {

            try 
            {
                string username = txtUsername.Text;
                string password = txtPassword.Password;

                bool isSignedIn = UserManager.SignInUser(username, password);

                if (string.IsNullOrWhiteSpace(username.Trim()) || string.IsNullOrWhiteSpace(password.Trim())) 
                {
                    throw new ArgumentException("Please enter username or password before proceeding!");
                }

                if (isSignedIn)
                {
                    Close();
                }
                else
                {
                    throw new ArgumentException ("Invalid username or password! Try again.");
                }
            }
            catch (ArgumentException ex) 
            {
                
                MessageBox.Show(ex.Message, "Warning!",MessageBoxButton.OK, MessageBoxImage.Error);    
            }

        }

        private void tbkRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new();
            registerWindow.Show();
            Close();
        }
    }
}
