using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XLibrary.Core.Models
{
    public class Reservation : BaseEntity
    {
        public string ReservedBookId { get; set; }
        public string ReaderId { get; set; }
    }
}