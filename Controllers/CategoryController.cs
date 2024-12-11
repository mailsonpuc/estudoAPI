using System.Collections.Generic;
using meuapp.Data;
using meuapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace meuapp.Controllers
{
    [ApiController]
    [Route("categories")]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Category>>> Get()
        {
            return new List<Category>();
        }



        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Category>> GetById(int id)
        {
            return new Category();
        }


        [HttpPost]
        [Route("")]
        public async Task<ActionResult<List<Category>>> Post(
            [FromBody] Category model,
            [FromServices] DataContext context
        )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            try
            {
                context.Categories.Add(model);
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (System.Exception)
            {

                return BadRequest(new { message = "nao foi possivel criar categoria" });
            }


        }


        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<List<Category>>> Put(
            int id, 
            [FromBody] Category model,
            [FromServices] DataContext context
            )
        {
            if (id != model.Id)
                return NotFound(new { message = "Categoria nao encontrada" });


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Entry<Category>(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (DbUpdateConcurrencyException)
            {

                return BadRequest(new { message = "Nao foi possivel atualizar a categoria"});
            }


        }


        [HttpDelete]
        [Route("id:int")]
        public async Task<ActionResult<List<Category>>> Delete(
            int id,
            [FromServices]DataContext context
        )
        {
            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if(category == null)
                return NotFound(new { message = "Categoria nao encontrada" });

            try
            {
                context.Categories.Remove(category);
                await context.SaveChangesAsync();
                return Ok(new { message = "Categoria removida com sucesso"});
            }
            catch (System.Exception)
            {
                
                return BadRequest(new { message = "Nao foi possivel remove a categoria"});
            }
           
        } 




    }
}