using ManagementPerson.Api.Extensions;
using ManagementPerson.Api.Interfaces;
using ManagementPerson.Api.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TranVanAnh_QuizzApp.Infrastructure.Services;

namespace ManagementPerson.Api.Controllers
{
    public class PeopleController : BaseController<PersonViewModel, PersonCreateViewModel>
    {
        private readonly IPersonService _personService;

        public PeopleController(IPersonService personService) : base(personService)
        {
            _personService = personService;
        }

        public override async Task<IActionResult> GetList([FromQuery] BaseSpecification spec, [FromQuery] PaginationParams pageParams)
        {
            try
            {
                if (pageParams.PageNumber == 0) pageParams.PageNumber = 1;

                var res = await _personService.GetAllAsync(spec, pageParams, new[] { "Address" });

                if (res == null)
                {
                    return NotFound();
                }

                return Ok(new PaginationSet(pageParams.PageNumber, pageParams.PageSize, res.TotalCount, res.TotalPage, res));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
