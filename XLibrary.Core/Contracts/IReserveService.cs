using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XLibrary.Core.Models;

namespace XLibrary.Core.Contracts
{
    public interface IReserveService
    {
        void CreateReservation(Reservation baseReservation);
    }
}
