using SeaViewAppLibrary.Data;
using SeaViewAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SeaView.Desktop
{
    /// <summary>
    /// Interaction logic for CheckOutForm.xaml
    /// </summary>
    public partial class CheckOutForm : Window
    {
        private readonly IDatabaseData _db;
        private FullBookingModel _data = null;
        public CheckOutForm(IDatabaseData db)
        {
            InitializeComponent();
            _db = db;
        }

        private void checkOutUser_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        internal void PopulateCheckOutInfo(FullBookingModel data)
        {
            _data = data;
            firstNameText.Text = _data.FirstName;
            lastNameText.Text = _data.LastName;
            titleText.Text = _data.Title;
            roomNumberText.Text = _data.RoomNumber;
            var day = _data.EndDate - _data.StartDate;
            if (day.Days < 1)
            {
                day = new TimeSpan(1, 0, 0, 0, 0);
            }
            decimal cost = _data.TotalCost * day.Days;
            totalCostText.Text = String.Format(new CultureInfo("bn-BD"), "{0:C} x {1} = {2:C}", _data.TotalCost, day.Days, cost);
        }
    }
}
