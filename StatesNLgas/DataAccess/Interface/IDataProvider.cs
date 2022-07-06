using StatesNLgas.Models;
using System.Threading.Tasks;

namespace StatesNLgas.DataAccess
{
    public interface IDataProvider
    {
        Task<Response<string[]>> GetLgasAsync();
        Task<Response<StateLgas>> GetStateLgasAsync(string state);
        Task<Response<string[]>> GetStatesAsync();
    }
}