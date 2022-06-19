using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using sitech.Data.Context;
using sitech.Data.DB.DBInterface;

namespace sitech.Data.DB
{
    public class ConnectionServices : IConnectionServices
    {
        private static SqlConnection connection;
        private SqlCommand dbCommand;
        private DBContext _dbContext;
        public ConnectionServices(DBContext dbContext) 
        {
            this._dbContext = dbContext;
        }
        public ConnectionServices InitializeQuery(string query)
        {
            string context = _dbContext.Database.GetDbConnection().ConnectionString;
            connection = new SqlConnection(context);
            dbCommand = new SqlCommand(query, connection);

            dbCommand.CommandType = System.Data.CommandType.Text;
            return this;
        }

        public async Task NonResult(bool isTransaction = false)
        {
            ValidateConnectionState();
            await dbCommand.ExecuteNonQueryAsync();
            if (!isTransaction)
                dbCommand.Connection.Close();
        }

        public async Task<List<T>> GetResult<T>(bool isTransaction = false)
        {
            List<T> oList = new List<T>();
            Extensions _mapper = new Extensions();
            ValidateConnectionState();
            using (var reader = await dbCommand.ExecuteReaderAsync())
            {
                oList = await _mapper.MapToListBase<T>(reader);
            }

            if (!isTransaction)
                dbCommand.Connection.Close();

            return oList;
        }

        private void ValidateConnectionState()
        {
            if (dbCommand.Connection.State == System.Data.ConnectionState.Closed)
                dbCommand.Connection.Open();
        }
    }
}
