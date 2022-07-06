using StatesNLgas.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StatesNLgas.DataAccess
{
    public class DataProvider : IDataProvider
    {
        private readonly IReadJson _storage;

        public DataProvider(IReadJson storage)
        {
            _storage = storage;
        }

        public async Task<Response<string[]>> GetStatesAsync()
        {
            try
            {
                var states = await _storage.GetAll<string[]>("states.json");
                if (states.Any())
                {
                    Array.Sort(states);
                    return new Response<string[]>().Success(states, "List of all Nigerian states.", states.Length);
                }
                return new Response<string[]>().Fail("There was an error fetching the list of all Nigerian states!");
            }
            catch (Exception ex)
            {
                return new Response<string[]>().Fail(ex.Message);
            }
        }

        public async Task<Response<string[]>> GetLgasAsync()
        {
            try
            {
                var lgas = await _storage.GetAll<string[]>("lgas.json");
                if (lgas.Any())
                {
                    Array.Sort(lgas);
                    return new Response<string[]>().Success(lgas, "List of all Nigerian local government areas.", lgas.Length);
                }
                return new Response<string[]>().Fail("There was an error fetching the list of all Nigerian states!");
            }
            catch (Exception ex)
            {
                return new Response<string[]>().Fail(ex.Message);
            }
        }


        public async Task<Response<StateLgas>> GetStateLgasAsync(string state)
        {
            try
            {
                var stateNlgas = await _storage.GetStateLgas(state, "states_lgas.json");
                if (stateNlgas != null)
                {
                    return new Response<StateLgas>().Success(stateNlgas, $"List of all Lgas in {stateNlgas.State} state.", stateNlgas.Lgas.Count);
                }
                return new Response<StateLgas>().BadRequest($"{state} is not a valid Nigerian state!");
            }
            catch (Exception ex)
            {
                return new Response<StateLgas>().Fail(ex.Message);
            }
        }
    }
}
