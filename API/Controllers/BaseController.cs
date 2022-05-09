using System.Collections.Generic;
using System.Threading.Tasks;
using Core;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using API.Helper;
using System;
using Core.Specifications;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController<entity, dto> : Controller where entity : BaseEntity
    {

        protected readonly IUOW _uow;

        public BaseController(IUOW uow)
        {
            this._uow = uow;
        }
        [HttpGet()]
        public virtual async Task<ActionResult<List<dto>>> Get()
        {

            var result = await _uow.Repository<entity>().GetAllAsync(null);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result.EvaluateModelToDto<List<entity>, List<dto>>());
        }




        [HttpGet("{id}")]
        public virtual async Task<dto> Get(Guid id, ISpecifications<entity> spec)
        {
            entity result = null;
            if (spec == null)
                result = await _uow.Repository<entity>().GetAsync(id);


            return result.EvaluateModelToDto<entity, dto>();
        }

        [HttpPost]
        public async Task<IActionResult> Post(dto entity)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var modelToDb = entity.EvaluateModelToDto<dto, entity>();
            modelToDb.CreatedDate = DateTimeOffset.Now;
            await _uow.Repository<entity>()
            .Add(entity.EvaluateModelToDto<dto, entity>());
            await _uow.Complete();
            return Ok();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, dto entity)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _uow.Repository<entity>()
           .Update(entity.EvaluateModelToDto<dto, entity>());
            await _uow.Complete();
            return Ok();


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var entity = await _uow.Repository<entity>().GetAsync(id);
            if (entity == null)
            {
                return BadRequest();
            }
            _uow.Repository<entity>().Remove(entity);
            await _uow.Complete();
            return Ok();
        }

    
    }
}