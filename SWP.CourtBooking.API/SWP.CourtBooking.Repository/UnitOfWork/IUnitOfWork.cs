using SWP.CourtBooking.Repository.Models;
using SWP.CourtBooking.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP.CourtBooking.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        Task<int> SaveAsync();
        public GenericRepository<Booking> BookingRepository { get; }
        public GenericRepository<BookingDetail> BookingDetailRepository { get; }
        public GenericRepository<Court> CourtRepository { get; }
        public GenericRepository<CourtCluster> CourtClusterRepository {  get; }
        public GenericRepository<Customer> CustomerRepository { get; }
        public GenericRepository<Deposit> DepositRepository { get; }
        public GenericRepository<Slot> SlotRepository { get; }
        public GenericRepository<Transaction> TransactionRepository { get; }
        public GenericRepository<User> UserRepository { get; }
        public GenericRepository<Wallet> WalletRepository { get; }
        
    }
}
