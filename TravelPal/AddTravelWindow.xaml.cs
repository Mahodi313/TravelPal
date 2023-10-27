﻿using System;
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
using TravelPal.Models;
using TravelPal.User_Models;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for AddTravelWindow.xaml
    /// </summary>
    public partial class AddTravelWindow : Window
    {
        private User _user;

        public Travel Travel { get; set; }
        public AddTravelWindow(IUser user)
        {
            InitializeComponent();
            _user = (User)user;

            UpdateUI();
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            TravelWindow travelWindow = new(_user);
            travelWindow.Show();
            Close();
        }

        private void btnAddTravel_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                Country selectedCountry;
                string city = txtCity.Text;
                string amountOfTravellers = txtAmountOfTravellers.Text;
                string startTime = dtrStartTime.Text;
                string endTime = dtrEndTime.Text;
                string? typeOfTrip = cbTravelTypes.SelectedItem.ToString();

                if (cbCountries.SelectedIndex <= -1) 
                {
                    throw new NullReferenceException("Please select a country before proceeding!");
                }
                if (string.IsNullOrWhiteSpace(city.Trim()) || string.IsNullOrWhiteSpace(amountOfTravellers.Trim()) || string.IsNullOrEmpty(startTime) || string.IsNullOrEmpty(endTime))
                {
                    throw new ArgumentException("Please fill in all needed information!");
                }
                if (typeOfTrip == null) 
                {
                    throw new NullReferenceException("Please select the type of trip before proceeding!");
                }

                DateTime startDate = DateTime.Parse(startTime);
                DateTime endDate = DateTime.Parse(endTime);
                selectedCountry = (Country)cbCountries.SelectedItem;
            }

            catch (ArgumentException aex) 
            {
                MessageBox.Show(aex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(FormatException) 
            {
                MessageBox.Show("Invalid format for the travel dates!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("No country or travel type selected!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception) 
            {
                MessageBox.Show("Travel Add Error!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            
        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateUI() 
        {
            cbCountries.SelectedIndex = -1;

            foreach (Country country in Enum.GetValues(typeof(Country))) 
            {
                cbCountries.Items.Add(country);
            }

            cbTravelTypes.Items.Add("Worktrip");
            cbTravelTypes.Items.Add("Vacation");

            cbTravelTypes.SelectedIndex = -1;

            lblMeetingDetails.Visibility = Visibility.Hidden;
            txtMeetingDetails.IsEnabled = false;

            txtCity.Clear();
            txtAmountOfTravellers.Clear();
            txtItem.Clear();
            txtMeetingDetails.Clear();
            txtQuantity.Clear();

            dtrStartTime.Text = "";
            dtrEndTime.Text = "";

            cbxAllInclusive.IsChecked = false;
            cbxTravelDocument.IsChecked = false;
            cbxRequired.IsChecked = false;

            cbxAllInclusive.Visibility = Visibility.Hidden;
            cbxRequired.Visibility = Visibility.Hidden;

        }

        private void cbTravelTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            /* If travel type is selected to worktrip set meetingdetails to visible and allinclusive to invinsible
            and if vacation is selected set allinclusive box to visible and meetingdetails to invinsible*/

            if (cbTravelTypes.SelectedIndex == 0) 
            {
                lblMeetingDetails.Visibility = Visibility.Visible;
                txtMeetingDetails.IsEnabled = true;

                cbxAllInclusive.Visibility= Visibility.Hidden;
            }
            else if (cbTravelTypes.SelectedIndex == 1)
            {
                cbxAllInclusive.Visibility = Visibility.Visible;

                lblMeetingDetails.Visibility = Visibility.Hidden;
                txtMeetingDetails.IsEnabled = false;
            }
        }
    }
}
