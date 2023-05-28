using ClassLibrary.Models;

namespace Big_Bang__Assessment_1.Repository
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> GetReservations();
        Task<Reservation> GetReservation(int id);
        Task<int> CreateReservation(Reservation reservation);
        Task<int> UpdateReservation(int id, Reservation reservation);
        Task<int> DeleteReservation(int id);
    }
}
