using Application.Features.Models.Models;
using Application.Features.Models.Queries.GetListModel;
using Application.Features.Models.Queries.GetListModelByDynamic;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListModelQuery getListModelQuery = new GetListModelQuery { PageRequest = pageRequest };
            ModelListModel result = await Mediator.Send(getListModelQuery);
            return Ok(result);
        }

        //        {
        //  "sort": [
        //    {
        //      "field": "name",
        //      "dir": "asc"
        //    }
        //  ],
        //  "filter": {
        //    "field": "name",
        //    "operator": "eq",
        //    "value": "Series 4",
        //    "logic": "or",
        //    "filters": [
        //     {
        //          "field": "dailyPrice",
        //          "operator": "lte",
        //          "value": "1100"
        //     }

        //    ]
        //  }
        //}
        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListModelByDynamicQuery getListByDynamicModelQuery = new GetListModelByDynamicQuery { PageRequest = pageRequest, Dynamic = dynamic };
            ModelListModel result = await Mediator.Send(getListByDynamicModelQuery);
            return Ok(result);
        }
    }
}
