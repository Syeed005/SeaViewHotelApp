using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeaViewAppLibrary.Data;
using SeaViewAppLibrary.Models;

namespace SeaView.Web.Pages
{
    public class RoomSearchModel : PageModel
    {
        private readonly IDatabaseData db;

        [DataType(DataType.Date)]
        [BindProperty(SupportsGet = true)]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        [BindProperty(SupportsGet = true)]
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);

        [BindProperty(SupportsGet = true)]
        public bool SearchEnabled { get; set; } = false;

        public List<RoomTypeModel> AvailableRoomType { get; set; }
        public RoomSearchModel(IDatabaseData db)
        {
            this.db = db;
        }

        public void OnGet()
        {
            if (SearchEnabled == true)
            {
                AvailableRoomType = db.GetAvailableRoomTypes(StartDate, EndDate);
            }          
        }

        public IActionResult OnPost()
        {
            return RedirectToPage(new { SearchEnabled = true, StartDate = StartDate.ToString("yyyy-MM-dd"), EndDate = EndDate.ToString("yyyy-MM-dd") });
        }
    }
}
