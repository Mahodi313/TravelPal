using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
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
using TravelPal.Managers;
using TravelPal.Models;
using TravelPal.User_Models;

namespace TravelPal;

/// <summary>
/// Interaction logic for TravelWindowDetails.xaml
/// </summary>
public partial class TravelWindowDetails : Window
{
    public Travel Travel { get; set; }

    private IUser _user;


    public TravelWindowDetails(Travel travel, IUser user)
    {
        InitializeComponent();

        Travel = travel;
        _user = user;

        UpdateUI();
    }

    private void btnGoBack_Click(object sender, RoutedEventArgs e)
    {
        TravelWindow travelWindow = new(_user);
        travelWindow.Show();
        Close();
    }


    public void UpdateUI() 
    {
        //Initializes traveldetails UI

        txtCountry.Text = Travel.Country.ToString();
        txtCity.Text = Travel.Destination;
        txtAmountTravellers.Text = Travel.Travellers.ToString();

        txtLengthTrip.Text = Travel.TravelDays.ToString() + " days";

        dprStartTime.Text = Travel.StartDate.ToString();
        dprEndTime.Text = Travel.EndDate.ToString();

        foreach (var item in Travel.PackingList)
        {
            if (item is OtherItem otherItem)
            {
                ListViewItem otherItemView = new ListViewItem();
                otherItemView.Content = otherItem.GetInfo();
                otherItemView.Tag = otherItem;

                lstItems.Items.Add(otherItemView);
            }
            else if (item is TravelDocument document)
            {
                ListViewItem documentItem = new ListViewItem();
                documentItem.Content = document.GetInfo();
                documentItem.Tag = document;

                lstTextDocuments.Items.Add(documentItem);
            }
        }

        if (Travel is Vacation vacation)
        {
            txtTripInfo.Text = vacation.GetVacationInfo();
        }
        else if (Travel is WorkTrip workTrip)
        {
            txtTripInfo.Text = workTrip.GetWorkTripInfo();
        }
    }


}
