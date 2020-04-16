using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraBookingTicketsApp.ViewModels.OrchestraModel
{
    public class AddOrchestraViewModel
    {
        
        public string Title { get; set; }        
        public DateTime Date { get; set; }        
        public int Price { get; set; }
    }
}
