using System.Collections.Generic;
using System.Threading.Tasks;
using Lookup.API.Models;

namespace Lookup.API.Repository
{
    public interface ILookupRepository
    {
        Task<List<State>> GetStatesAsync();
    }
}