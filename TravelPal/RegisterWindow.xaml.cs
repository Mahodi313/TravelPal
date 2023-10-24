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
using TravelPal.Enums;
using TravelPal.Managers;
using TravelPal.Models;
using TravelPal.User_Models;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();

            foreach (Enum country in Enum.GetValues(typeof(Country))) 
            {
                cbCountry.Items.Add(country);
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                string firstname = txtFirstname.Text;
                string lastname = txtLastname.Text;
                string username = txtUsername.Text;
                string email = txtEmail.Text;
                string birthday = txtBirthday.Text;
                string password = txtPassword.Password;
                string confirmPassword = txtConfirmPassword.Password;
                Country selectedCountry;

                if (string.IsNullOrWhiteSpace(firstname.Trim()) || string.IsNullOrWhiteSpace(lastname.Trim()) || string.IsNullOrWhiteSpace(username.Trim()) || string.IsNullOrWhiteSpace(email.Trim()) || string.IsNullOrWhiteSpace(birthday.Trim()) || string.IsNullOrWhiteSpace(password.Trim()) || string.IsNullOrWhiteSpace(confirmPassword.Trim())) 
                {
                    throw new ArgumentException("Please enter all, needed information!");
                }
                else if (cbCountry.SelectedIndex <= -1) 
                {
                    throw new ArgumentException("Please enter country you live in!");
                }
                else if (password != confirmPassword) 
                {
                    throw new ArgumentException("The passwords doesn't match! Try again.");
                }
                else if (!email.Contains("@")) 
                {
                    throw new FormatException("Invalid email! It must contain '@'.");
                }
                else if (!DateTime.TryParse(birthday, out DateTime birthdate)) 
                {
                    throw new FormatException("Invalid birthday format! Please enter in the following format: (YYYY-MM-DD).");
                }

                selectedCountry = (Country)cbCountry.SelectedItem;
                DateTime birth = DateTime.Parse(birthday);

                User newUser = new(firstname, lastname, username, email, birth, password, selectedCountry, new List<Travel>());

                bool IsUserAdded = UserManager.AddUser(newUser);

                if (IsUserAdded) 
                {
                    UserManager.users.Add(newUser); 

                    MessageBox.Show("Your account has been successfully created!", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
                    MainWindow mainWindow = new();
                    mainWindow.Show();
                    Close();
                }
                else 
                {
                    if (newUser.Age < 16) 
                    {
                        throw new ArgumentException("You need to be over 16 years old or above to create an account!");
                    }

                    throw new ArgumentException ("The username or email already exists! Try again.");                  
                }              
            }
            catch (ArgumentException ex) 
            {
                MessageBox.Show(ex.Message,"Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(FormatException b) 
            {
                MessageBox.Show(b.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            
            MainWindow mainWindow = new();
            mainWindow.Show();
            Close();
        }
    }
}
