using StatesNLgas.Models;
using System.Threading.Tasks;

namespace StatesNLgas.DataAccess
{
    public interface IReadJson
    {
        Task<T> GetAll<T>(string jsonFile);
        Task<StateLgas> GetStateLgas(string query, string jsonFile);
    }
}