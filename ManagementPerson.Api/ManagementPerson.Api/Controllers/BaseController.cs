using ManagementPerson.Api.Extensions;
using ManagementPerson.Api.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementPerson.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TDto, TCreateUpdate> : ControllerBase where TDto : class where TCreateUpdate : class
    {
        private readonly IBaseService<TDto, TCreateUpdate> _personService;

        public BaseController(IBaseService<TDto, TCreateUpdate> baseService)
        {
            _personService = baseService;
        }

        [HttpGet]
        [Route("get-list")]
        public virtual async Task<IActionResult> GetList([FromQuery] BaseSpecification spec, [FromQuery] PaginationParams pageParams)
        {
            try
            {
                var res = await _personService.GetAllAsync(spec, pageParams);

                if (res == null)
                {
                    return NotFound();
                }

                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var res = await _personService.GetById(id);

                if (res == null)
                {
                    return NotFound();
                }

                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var res = await _personService.DeleteAsync(id);

                if (res == null)
                {
                    return NotFound();
                }

                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> Update(int id, TCreateUpdate input)
        {
            try
            {
                var res = await _personService.UpdateAsync(input);

                if (res == 0)
                {
                    return BadRequest();
                }

                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(TCreateUpdate input)
        {
            try
            {
                var res = await _personService.CreateAsync(input);

                if (res == null)
                {
                    return BadRequest();
                }

                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
