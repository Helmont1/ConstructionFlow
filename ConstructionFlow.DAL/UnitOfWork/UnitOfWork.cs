using ConstructionFlow.DAL.DatabaseContext;
using ConstructionFlow.Domain.Model;
using ConstructionFlow.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFlow.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ConstructionFlowDbContext _context;

        private IGenericRepository<Construction> _ConstructionRepository;
        private IGenericRepository<Activity> _ActivityRepository;
        private IGenericRepository<ConstructionPhoto> _ConstructionPhotoRepository;
        private IGenericRepository<Customer> _CustomerRepository;
        private IGenericRepository<DefaultActivity> _DefaultActivityRepository;
        private IGenericRepository<Status> _StatusRepository;
        private IGenericRepository<User> _UserRepository;


        public UnitOfWork(ConstructionFlowDbContext context)
        {
            _context = context;
        }
        public IGenericRepository<Construction> ConstructionRepository => _ConstructionRepository ??= new GenericRepository<Construction>(_context);

        public IGenericRepository<Activity> ActivityRepository => _ActivityRepository ??= new GenericRepository<Activity>(_context);
        public IGenericRepository<ConstructionPhoto> ConstructionPhotoRepository => _ConstructionPhotoRepository ??= new GenericRepository<ConstructionPhoto>(_context);
        public IGenericRepository<Customer> CustomerRepository => _CustomerRepository ??= new GenericRepository<Customer>(_context);
        public IGenericRepository<DefaultActivity> DefaultActivityRepository => _DefaultActivityRepository ??= new GenericRepository<DefaultActivity>(_context);
        public IGenericRepository<Status> StatusRepository => _StatusRepository ??= new GenericRepository<Status>(_context);
        public IGenericRepository<User> UserRepository => _UserRepository ??= new GenericRepository<User>(_context);

        public void Dispose()
        {
            _context.Dispose();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

