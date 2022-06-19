using Microsoft.EntityFrameworkCore;

namespace sitech.Data.Context
{
    public class DBContext: DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
    }
}
