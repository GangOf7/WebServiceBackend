using System;
using System.Threading.Tasks;

namespace PiratesBay.Data.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IValuesRepository values { get; }
        Task SaveAsyn();
    }
}