using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XLibrary.Core.Models;

namespace XLibrary.Core.ViewModels
{
    public class ShowHistoryViewModel
    {
        public string BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public IEnumerable<Reservation> Reservations { get; set; }
    }
}
