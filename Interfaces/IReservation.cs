using GraphQLProject.Models;

namespace GraphQLProject.Interfaces
{
    public interface IReservation
    {
        public List<Reservation> GetReservations();
        public Reservation AddReservation(Reservation reservation);
    }
}
