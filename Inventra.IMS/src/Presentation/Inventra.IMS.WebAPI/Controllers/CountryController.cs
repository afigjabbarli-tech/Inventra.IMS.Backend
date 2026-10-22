using Inventra.IMS.Application.Features.Commands.Country.CreateCountry;
using Inventra.IMS.Application.Features.Commands.Country.DeleteCountryByUid;
using Inventra.IMS.Application.Features.Queries.Country.GetAllCountries;
using Inventra.IMS.Application.Features.Queries.Country.GetCountryByUid;
using Inventra.IMS.Application.Features.Queries.Country.GetCountryOptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inventra.IMS.WebAPI.Controllers
{
    [Route("api/v1/countries")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CountryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("post", Name = "PostCountry")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Post(
            [FromForm] CreateCountryCommandRequest request,
            CancellationToken cancellationToken)
        {
            CreateCountryCommandResponse response =
                await _mediator.Send(request, cancellationToken);

            return CreatedAtRoute(
                routeName: "GetCountryByUid",
                routeValues: new
                {
                    uid = response.country_data.country.uid
                },
                value: response
            );
        }

        [HttpGet("get/{Uid:guid}", Name = "GetCountryByUid")]
        public async Task<IActionResult> GetByUid(
            [FromRoute] GetCountryByUidQueryRequest request,
            CancellationToken cancellationToken)
        {
            GetCountryByUidQueryResponse response =
                await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }

        [HttpGet("get", Name = "GetAllCountries")]
        public async Task<IActionResult> GetAll(
        CancellationToken cancellationToken)
        {
            GetAllCountriesQueryResponse response =
                await _mediator.Send(
                    new GetAllCountriesQueryRequest(),
                    cancellationToken);

            return Ok(response);
        }

        [HttpGet("options", Name = "GetCountryOptions")]
        public async Task<IActionResult> GetOptions(
            [FromQuery] GetCountryOptionsQueryRequest request,
            CancellationToken cancellationToken)
        {
            GetCountryOptionsQueryResponse response =
                await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }

        [HttpDelete("delete/{Uid:guid}", Name = "DeleteCountryByUid")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCountryByUidCommandRequest request,
            CancellationToken cancellationToken)
        {
            await _mediator.Send(request);

            return NoContent();
        }
    }
}
