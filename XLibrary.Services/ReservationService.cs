using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XLibrary.Core.Contracts;
using XLibrary.Core.Models;

namespace XLibrary.Services
{
    public class ReservationService : IReserveService
    {
        IRepository<Reservation> reservationContext;
        IRepository<Book> bookContext;
        public ReservationService(IRepository<Reservation> ReservationContext, IRepository<Book> BookContext)
        {
            this.reservationContext = ReservationContext;
            this.bookContext = BookContext;
        }

        public void CreateReservation(Reservation reservation)
        {
            reservationContext.Insert(reservation);
            reservationContext.Commit();
        }
    }
}
