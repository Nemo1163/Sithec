using sitech.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sitech.Services.IServices
{
    public interface IHumanServices
    {
        List<HumanModel> GetListHuman();

        Task<List<HumanModel>> GetDBListHuman();

        Task<HumanModel> GetDBHuman(int id);

        Task PostDBHuman(HumanModel humanModel);

        Task PutDBHuman(HumanModel humanModel);
    }
}
