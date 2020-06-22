using PiratesBay.Data.IRepositories;
using System.Threading.Tasks;

namespace PiratesBay.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(DataContext db)
        {
            _Db = db;
            values = new ValuesRepository(db);
        }

        public IValuesRepository values { get; private set; }

        public DataContext _Db { get; }

        public void Dispose()
        {
            _Db.Dispose();
        }

        public async Task SaveAsyn()
        {
            await _Db.SaveChangesAsync();
        }
    }
}