using PiratesBay.Data.IRepositories;
using PiratesBay.Data.Repository;
using PiratesBay.Models;

namespace PiratesBay.Data.Repositories
{
    public class ValuesRepository : Repository<Value>, IValuesRepository
    {
        private readonly DataContext _db;
        public ValuesRepository(DataContext db) : base(db)
        {
            _db = db;
        }
    }
}