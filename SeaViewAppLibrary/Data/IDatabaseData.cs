using SeaViewAppLibrary.Models;
using System;
using System.Collections.Generic;

namespace SeaViewAppLibrary.Data
{
    public interface IDatabaseData
    {
        void BookGuest(string firstName, string lastName, DateTime startDate, DateTime endDate, int roomTypeId);
        void CheckIn(int bookingId);
        List<RoomTypeModel> GetAvailableRoomTypes(DateTime startDate, DateTime endDate);
        List<FullBookingModel> SearchBookings(string lastName);
        RoomTypeModel GetRoomById(int id);
    }
}