using SeaViewAppLibrary.Data;
using SeaViewAppLibrary.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Extensions.DependencyInjection;

namespace SeaView.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IDatabaseData _db;
        private static bool checkIn;
        private static bool checkOut;
        
        public MainWindow(IDatabaseData db)
        {
            InitializeComponent();
            _db = db;
        }

        private void searchForGuest_Click(object sender, RoutedEventArgs e)
        {
            List<FullBookingModel> bookings = _db.SearchBookings(lastNameText.Text);
            List<FullBookingModel> checkInList = new List<FullBookingModel>();
            List<FullBookingModel> checkOutList = new List<FullBookingModel>();
            foreach (var item in bookings)
            {
                if (!item.CheckedIn)
                {
                    checkInList.Add(item);
                }
                else
                {
                    checkOutList.Add(item);
                }
            }
            if (checkIn)
            {
                resultsList.ItemsSource = checkInList;
            }
            if (checkOut)
            {
                resultsList.ItemsSource = checkOutList;
            }
        }

        private void CheckInButton_Click(object sender, RoutedEventArgs e)
        {
            var checkInForm = App.serviceProvider.GetService<CheckInForm>();
            var checkOutForm = App.serviceProvider.GetService<CheckOutForm>();
            var model = (FullBookingModel)((Button)e.Source).DataContext;

            if (checkIn)
            {
                checkInForm.PopulateCheckInInfo(model);
                checkInForm.Show();
            }
            if (checkOut)
            {
                checkOutForm.PopulateCheckOutInfo(model);
                checkOutForm.Show();
            }
            
        }

        private void RadioButtonChkIn_Checked(object sender, RoutedEventArgs e)
        {
            checkIn = true;
            resultsList.ItemsSource = null;
        }

        private void RadioButtonChkOut_Checked(object sender, RoutedEventArgs e)
        {
            checkOut = true;
            resultsList.ItemsSource = null;
        }

        private void RadioButtonChkIn_Unchecked(object sender, RoutedEventArgs e)
        {
            checkIn = false;
            resultsList.ItemsSource = null;
        }

        private void RadioButtonChkOut_Unchecked(object sender, RoutedEventArgs e)
        {
            checkOut = false;
            resultsList.ItemsSource = null;
        }
    }
}
 