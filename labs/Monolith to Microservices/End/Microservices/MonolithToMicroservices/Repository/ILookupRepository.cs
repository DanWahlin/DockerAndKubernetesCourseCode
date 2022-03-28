using System.Collections.Generic;
using System.Threading.Tasks;
using MonolithToMicroservices.Models;

namespace MonolithToMicroservices.Repository
{
    public interface ILookupRepository
    {
        Task<List<State>> GetStatesAsync();
    }
}