using sitech.Data;
using sitech.Data.DB.DBInterface;
using sitech.Models;
using sitech.Services.IServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sitech.Services
{
    public class HumanServices : IHumanServices
    {
        private readonly HumanData instHuman;
        private readonly IConnectionServices _connectionServices;

        public HumanServices(IConnectionServices connectionServices)
        {
            this.instHuman = new HumanData();
            this._connectionServices = connectionServices;
        }

        public List<HumanModel> GetListHuman()
        {
            return instHuman.ListHuman();
        }

        public async Task<List<HumanModel>> GetDBListHuman()
        {
                string query = "SELECT Id, [Name], [Sex], [Years], [Height], [Weight] FROM dbo.TableHuman";
                return await _connectionServices.InitializeQuery(query).GetResult<HumanModel>();
        }

        public async Task<HumanModel> GetDBHuman(int id)
        {
            string query = $"SELECT Id, [Name], [Sex], [Years], [Height], [Weight] FROM dbo.TableHuman WHERE Id = {id}";
            return (await _connectionServices.InitializeQuery(query).GetResult<HumanModel>()).FirstOrDefault();
        }

        public async Task PostDBHuman(HumanModel humanModel)
        {
            string query = $"INSERT INTO [dbo].[TableHuman] ([Name], [Sex], [Years], [Height], [Weight]) VALUES ('{humanModel.Name}','{humanModel.Sex}',{humanModel.Years},{humanModel.Height},{humanModel.Weight})";
            await _connectionServices.InitializeQuery(query).NonResult();
        }

        public async Task PutDBHuman(HumanModel humanModel)
        {
            string query = $"UPDATE [dbo].[TableHuman] SET [Name] ='{humanModel.Name}', [Sex] = '{humanModel.Sex}', [Years] = {humanModel.Years}, [Height] = {humanModel.Height}, [Weight] = {humanModel.Weight} WHERE [Id] = {humanModel.Id} ";
            await _connectionServices.InitializeQuery(query).NonResult();
        }


    }
}
