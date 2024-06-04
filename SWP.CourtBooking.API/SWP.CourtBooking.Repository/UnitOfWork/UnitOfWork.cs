using Microsoft.EntityFrameworkCore;
using SWP.CourtBooking.Repository.Repository;
using SWP.CourtBooking.Repository.Models;
using SWP.CourtBooking.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP.CourtBooking.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private CourtBookingDbContext _context;
        private GenericRepository<Booking> _bookingRepo;
        private GenericRepository<BookingDetail> _bookingDetailRepo;
        private GenericRepository<Court> _courtRepo;
        private GenericRepository<CourtCluster> _courtClusterRepo;
        private GenericRepository<Customer> _customerRepo;
        private GenericRepository<Deposit> _depositRepo;
        private GenericRepository<Slot> _slotRepo;
        private GenericRepository<Transaction> _transactionRepo;
        private GenericRepository<User> _userRepo;
        private GenericRepository<Wallet> _walletRepo;
        

        public UnitOfWork(CourtBookingDbContext context)
        {
            _context = context;
        }




        public void Save()
        {
            _context.SaveChanges();
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        GenericRepository<Booking> IUnitOfWork.BookingRepository
        {
            get
            {
                if (_bookingRepo == null)
                {
                    this._bookingRepo = new GenericRepository<Booking>(_context);
                }
                return _bookingRepo;
            }
        }

        GenericRepository<BookingDetail> IUnitOfWork.BookingDetailRepository
        {
            get
            {
                if(_bookingDetailRepo == null)
                {
                    this._bookingDetailRepo = new GenericRepository<BookingDetail>(_context);
                }
                return _bookingDetailRepo;
            }
        }

        GenericRepository<Court> IUnitOfWork.CourtRepository
        {
            get
            {
                if(this._courtRepo == null)
                {
                    this._courtRepo = new GenericRepository<Court>(_context);
                }
                return _courtRepo;
            }
        }

        GenericRepository<CourtCluster> IUnitOfWork.CourtClusterRepository
        {
            get
            {
                if(this._courtClusterRepo == null)
                {
                    this._courtClusterRepo = new GenericRepository<CourtCluster>(_context);
                }
                return this._courtClusterRepo;
            }
        }

        GenericRepository<Customer> IUnitOfWork.CustomerRepository
        {
            get
            {
                if(this._customerRepo == null)
                {
                    this._customerRepo = new GenericRepository<Customer>(_context);
                }
                return this._customerRepo;
            }
        }

        GenericRepository<Deposit> IUnitOfWork.DepositRepository
        {
            get
            {
                if(this._depositRepo == null)
                {
                    this._depositRepo = new GenericRepository<Deposit>(_context);
                }
                return this._depositRepo;
            }
        }

        GenericRepository<Slot> IUnitOfWork.SlotRepository
        {
            get
            {
                if(this._slotRepo == null)
                {
                    this._slotRepo = new GenericRepository<Slot>(_context);
                }
                return this._slotRepo;
            }
        }

        GenericRepository<Transaction> IUnitOfWork.TransactionRepository
        {
            get
            {
                if(this._transactionRepo == null)
                {
                    this._transactionRepo = new GenericRepository<Transaction>(_context);
                }
                return this._transactionRepo;
            }
        }
        
        GenericRepository<User> IUnitOfWork.UserRepository
        {
            get
            {
                if(this._userRepo == null)
                {
                    this._userRepo = new GenericRepository<User>(_context);
                }
                return this._userRepo;
            }
        }

        GenericRepository<Wallet> IUnitOfWork.WalletRepository
        {
            get
            {
                if(this._walletRepo == null)
                {
                    this._walletRepo = new GenericRepository<Wallet>(_context);
                }
                return this._walletRepo;
            }
        }

    }
}
