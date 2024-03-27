using ConstructionFlow.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFlow.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        IGenericRepository<Construction> ConstructionRepository { get; }
        IGenericRepository<Activity> ActivityRepository { get; }
        IGenericRepository<ConstructionPhoto> ConstructionPhotoRepository { get; }
        IGenericRepository<Customer> CustomerRepository { get; }
        IGenericRepository<DefaultActivity> DefaultActivityRepository { get; }
        IGenericRepository<Status> StatusRepository { get; }
        IGenericRepository<User> UserRepository { get; }

        void Save();
        Task SaveAsync();
    }
}
