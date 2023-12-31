﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TravelPal.Enums;
using TravelPal.Managers;
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
        public List<PackingListItem> PackingItems { get; set; } = new();

        public AddTravelWindow(IUser user)
        {
            InitializeComponent();
            _user = (User)user;

            UpdateUI();

            dtrStartTime.DisplayDateStart = DateTime.Now;
            dtrEndTime.DisplayDateStart = DateTime.Now;
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

                if (endDate < startDate)
                {
                    throw new ArgumentException("Invalid dates! End-date can't be earlier than start-date.");
                }

                selectedCountry = (Country)cbCountries.SelectedItem;


                bool UserCountryCheck = TravelManager.CheckCountryEurope(_user.Location); // Checks if user lives in a europan country,
                                                                                          // returns true if user lives in europa.
                bool selectedCountryCheck = TravelManager.CheckCountryEurope(selectedCountry); // Checks if user selected country to travel is european or not.

                if (typeOfTrip == "Vacation")
                {
                    if (cbxAllInclusive.IsChecked == true) // Set All inclusive to true for the travels
                    {
                        if (UserCountryCheck && !selectedCountryCheck) // If user lives in a european country and traveling to outside euro. Get user a required passport 
                        {
                            Travel = new Vacation(city, selectedCountry, int.Parse(amountOfTravellers), PackingItems, startDate, endDate, true);
                            Travel.PackingList.Add(new TravelDocument("Passport", true));
                        }
                        else if (UserCountryCheck && selectedCountryCheck) // If user lives in euro and traveling inside euro. Get user a passport that is not required.
                        {
                            Travel = new Vacation(city, selectedCountry, int.Parse(amountOfTravellers), PackingItems, startDate, endDate, true);
                            Travel.PackingList.Add(new TravelDocument("Passport", false));
                        }
                        else // If user lives outside EU, get user a passport, a required passport, no matter where he travels
                        {
                            Travel = new Vacation(city, selectedCountry, int.Parse(amountOfTravellers), PackingItems, startDate, endDate, true);
                            Travel.PackingList.Add(new TravelDocument("Passport", true));
                        }
                    }
                    else // Set all inclusive to false if its not checked. (Repeating code) Maybe implement method later?
                    {
                        if (UserCountryCheck && !selectedCountryCheck)
                        {
                            Travel = new Vacation(city, selectedCountry, int.Parse(amountOfTravellers), PackingItems, startDate, endDate, false);
                            Travel.PackingList.Add(new TravelDocument("Passport", true));
                        }
                        else if (UserCountryCheck && selectedCountryCheck)
                        {
                            Travel = new Vacation(city, selectedCountry, int.Parse(amountOfTravellers), PackingItems, startDate, endDate, false);
                            Travel.PackingList.Add(new TravelDocument("Passport", false));
                        }
                        else
                        {
                            Travel = new Vacation(city, selectedCountry, int.Parse(amountOfTravellers), PackingItems, startDate, endDate, false);
                            Travel.PackingList.Add(new TravelDocument("Passport", true));
                        }
                    }

                }
                else if (typeOfTrip == "Worktrip")
                {
                    string meetingDetails = txtMeetingDetails.Text;

                    if (string.IsNullOrWhiteSpace(meetingDetails.Trim()))
                    {
                        throw new ArgumentException("Please enter meeting details before proceeding!");
                    }
                    else
                    {
                        if (UserCountryCheck && !selectedCountryCheck)
                        {
                            Travel = new WorkTrip(city, selectedCountry, int.Parse(amountOfTravellers), PackingItems, startDate, endDate, meetingDetails);
                            Travel.PackingList.Add(new TravelDocument("Passport", true));
                        }
                        else if (UserCountryCheck && selectedCountryCheck)
                        {
                            Travel = new WorkTrip(city, selectedCountry, int.Parse(amountOfTravellers), PackingItems, startDate, endDate, meetingDetails);
                            Travel.PackingList.Add(new TravelDocument("Passport", false));
                        }
                        else
                        {
                            Travel = new WorkTrip(city, selectedCountry, int.Parse(amountOfTravellers), PackingItems, startDate, endDate, meetingDetails);
                            Travel.PackingList.Add(new TravelDocument("Passport", true));
                        }
                    }
                }

                TravelManager.AddTravel(Travel, _user);
                MessageBox.Show("Travel has been successfully booked!", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);

                UpdateUI();

            }

            catch (ArgumentException aex)
            {
                MessageBox.Show(aex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input format!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (NullReferenceException nex)
            {
                MessageBox.Show(nex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Travel Add Error!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string item = txtItem.Text;

                if (string.IsNullOrWhiteSpace(item.Trim()))
                {
                    throw new ArgumentException("You need to enter your desired item before proceeding!");
                }
                else
                {
                    if (cbxTravelDocument.IsChecked == true)
                    {

                        if (cbxRequired.IsChecked == true)
                        {
                            PackingItems.Add(new TravelDocument(item, true));
                        }
                        else
                        {
                            PackingItems.Add(new TravelDocument(item, false));
                        }
                    }
                    else
                    {
                        string quantity = txtQuantity.Text;
                        cbxRequired.Visibility = Visibility.Hidden;

                        if (string.IsNullOrWhiteSpace(quantity.Trim()))
                        {
                            throw new ArgumentException("Please fill in your desired amount!");
                        }
                        if (!int.TryParse(quantity, out int value))
                        {
                            throw new FormatException("Quantity was written in an invalid format!");
                        }

                        PackingItems.Add(new OtherItem(item, value));
                    }

                    MessageBox.Show("Item successfully added!", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);

                    txtItem.Clear();
                    txtQuantity.Clear();
                    cbxTravelDocument.IsChecked = false;
                    cbxRequired.IsChecked = false;
                    cbxRequired.Visibility = Visibility.Hidden;
                }
            }
            catch (ArgumentException ax)
            {
                MessageBox.Show(ax.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (FormatException fx)
            {
                MessageBox.Show(fx.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("Error!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
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

                cbxAllInclusive.Visibility = Visibility.Hidden;
            }
            else if (cbTravelTypes.SelectedIndex == 1)
            {
                cbxAllInclusive.Visibility = Visibility.Visible;

                lblMeetingDetails.Visibility = Visibility.Hidden;
                txtMeetingDetails.IsEnabled = false;
            }
        }

        private void cbxTravelDocument_Checked(object sender, RoutedEventArgs e)
        {
            cbxRequired.Visibility = Visibility.Visible;
            txtQuantity.IsEnabled = false;
        }
        private void cbxTravelDocument_UnChecked(object sender, RoutedEventArgs e)
        {
            cbxRequired.Visibility = Visibility.Hidden;
            txtQuantity.IsEnabled = true;
        }

    }
}
