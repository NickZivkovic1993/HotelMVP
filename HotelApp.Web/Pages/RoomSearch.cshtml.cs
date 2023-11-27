using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HotelAppLibrary.Data;
using HotelAppLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelApp.Web.Pages
{
    public class RoomSearchModel : PageModel
    {
        private readonly IDatabaseData _db;

        [DataType(DataType.Date)]
        [BindProperty(SupportsGet = true)]
         
        public DateTime StartDate { get; set; } = DateTime.Now.Date;
        
        [DataType(DataType.Date)]
        [BindProperty(SupportsGet = true)]
        public DateTime EndDate { get; set; } = DateTime.Now.Date.AddDays(1);

        [BindProperty(SupportsGet = true)]
        public bool SearchEnabled { get; set; }

        public List<RoomTypeModel> AvailableRoomTypes { get; set; }

        public RoomSearchModel(IDatabaseData db)
        {
            _db = db;
        }
        public void OnGet()
        {
            if(SearchEnabled == true)
            {
                AvailableRoomTypes = _db.GetAvailableRoomTypes(StartDate, EndDate);     
            }
        }

        public IActionResult OnPost()
        {
            return RedirectToPage(new 
                { 
                SearchEnabled = true ,
                StartDate = StartDate.ToString("yyyy-MM-dd"),
                EndDate = EndDate.ToString("yyyy-MM-dd")
            });
            //nothing to unit test...
        }
    }
}
