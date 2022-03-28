using Lookup.API.Models;
using Lookup.API.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lookup.API
{
    //Can version API many ways (good discussion here: https://www.troyhunt.com/your-api-versioning-is-wrong-which-is/)
    //Going with version in route to keep it simple
    [ApiController]
    [Route("api/v1/lookup")]
    public class LookupApiController : ControllerBase
    {
        ILookupRepository _LookupRepository;
        ILogger _Logger;

        public LookupApiController(ILookupRepository statesRepo, ILoggerFactory loggerFactory)
        {
            _LookupRepository = statesRepo;
            _Logger = loggerFactory.CreateLogger(nameof(LookupApiController));
        }

        [HttpGet("states")]
        [ProducesResponseType(typeof(List<State>), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<ActionResult> States()
        {
            try
            {
                var states = await _LookupRepository.GetStatesAsync();
                return Ok(states);
            }
            catch (Exception exp)
            {
                _Logger.LogError(exp.Message);
                return BadRequest(new ApiResponse { Status = false });
            }
        }

    }
}
