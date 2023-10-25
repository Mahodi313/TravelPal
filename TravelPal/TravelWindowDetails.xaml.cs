using System;
using System.Collections.Generic;
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
using TravelPal.Models;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for TravelWindowDetails.xaml
    /// </summary>
    public partial class TravelWindowDetails : Window
    {
        public Travel Travel { get; set; }

        public TravelWindowDetails(Travel travel)
        {
            InitializeComponent();

            Travel = travel;

            txtCountry.Text = travel.Country.ToString();
            txtCity.Text = travel.Destination;
            txtAmountTravellers.Text = travel.Travellers.ToString();

            txtLengthTrip.Text = travel.TravelDays.ToString();

            dprStartTime.Text = travel.StartDate.ToString();
            dprEndTime.Text = travel.EndDate.ToString();

            foreach(var item in travel.PackingList) 
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

        }
    }
}
