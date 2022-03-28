using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MonolithToMicroservices.Infrastructure;
using MonolithToMicroservices.Models;
using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonolithToMicroservices.Repository
{
    public class LookupRepository : ILookupRepository
    {
        IHttpClient _HttpClient;
        IApiSettings _ApiSettings;
        ILogger _Logger;

        public LookupRepository(IHttpClient httpClient,
            IOptions<ApiSettings> settings,
            ILoggerFactory loggerFactory)
        {
            _HttpClient = httpClient;
            _ApiSettings = settings.Value;
            _Logger = loggerFactory.CreateLogger(nameof(LookupRepository));
        }

        public async Task<List<State>> GetStatesAsync()
        {
            List<State> states = null;
            try
            {
                var dataString = await _HttpClient.GetStringAsync(_ApiSettings.LookupUri + "/states");
                states = JsonSerializer.Deserialize<List<State>>(dataString);
            }
            catch (Exception exp)
            {
                //Now what? Would need a more robust way to handle issues
                //We'll simply log the error here
                _Logger.LogError(new EventId(10), exp, exp.Message);
            }
            return states;
        }
    }
}

