using SeaViewAppLibrary.Databases;
using SeaViewAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeaViewAppLibrary.Data
{
    public class SqlData : IDatabaseData
    {
        private readonly ISqlDataAccess db;
        private const string connectionStringName = "SqlDb";

        public SqlData(ISqlDataAccess db)
        {
            this.db = db;
        }

        public List<RoomTypeModel> GetAvailableRoomTypes(DateTime startDate, DateTime endDate)
        {
            return db.LoadData<RoomTypeModel, dynamic>("[dbo].[spRoomTypes_GetAvailableTypes]", new { startDate, endDate }, connectionStringName, true);
        }

        public void BookGuest(string firstName, string lastName, DateTime startDate, DateTime endDate, int roomTypeId)
        {
            GuestModel guest = db.LoadData<GuestModel, dynamic>("dbo.spGuest_Insert", new { firstName, lastName }, connectionStringName, true).First();

            RoomTypeModel roomType = db.LoadData<RoomTypeModel, dynamic>("select * from dbo.RoomTypes", new { roomTypeId }, connectionStringName, false).First();

            TimeSpan daysStaying = endDate.Date.Subtract(startDate.Date);

            List<RoomModel> availableRooms = db.LoadData<RoomModel, dynamic>("dbo.spRooms_GetAvailableRooms", new { startDate, endDate, roomTypeId }, connectionStringName, true);

            db.SaveData("dbo.spBookings_Insert", new { roomId = availableRooms.First().Id, guestId = guest.Id, startDate = startDate, endDate = endDate, totalCost = daysStaying.Days * roomType.Price }, connectionStringName, true);
        }

        public List<FullBookingModel> SearchBookings(string lastName)
        {
            List<FullBookingModel> output;
            output = db.LoadData<FullBookingModel, dynamic>("dbo.spBookings_SearchBooking", new { lastName, startDate = DateTime.Now.Date }, connectionStringName, true);
            return output;
        }

        public void CheckIn(int bookingId)
        {
            db.SaveData("dbo.spBookings_CheckIn", new { bookingId }, connectionStringName, true);
        }

        public RoomTypeModel GetRoomById(int id)
        {
            return db.LoadData<RoomTypeModel, dynamic>("dbo.spRoomTypes_GetRoomById", new { id }, connectionStringName, true).First();
        }
    }
}
