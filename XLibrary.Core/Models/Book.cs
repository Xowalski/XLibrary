using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace XLibrary.Core.Models
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        [DisplayName ("Publication Year")]
        public int PublicationYear { get; set; }
        public string Description { get; set; }
        [DisplayName ("Availability")]
        public bool IsAvailable { get; set; }
        public string Image { get; set; }

        public Book()
        {
            this.IsAvailable = true;
        }
    }
}
