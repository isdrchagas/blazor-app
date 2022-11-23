using BlazorWasm.Compartilhado.Entidades;
using BlazorWasmServer.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorWasm.BackEnd.Controllers
{
        [ApiController]

        [Route("api/[controller]")]
        public class CarroController : ControllerBase
        {
            private readonly ApplicationDbContext context;
            public CarroController(ApplicationDbContext context)
            {
                this.context = context;
            }

            [HttpGet]
            public async Task<ActionResult<List<Carro>>> Get()
            {
                return await context.Carros.ToListAsync();
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Carro>> Get(int id)
            {
                var resp = await context.Carros.FirstOrDefaultAsync(x => x.Id == id);
                if (resp == null) { return NotFound(); }
                return resp;
            }

            [HttpPost]
            public async Task<ActionResult<int>> Post(Carro carro)
            {
                context.Carros.Add(carro);
                await context.SaveChangesAsync();
                return carro.Id;
            }

            [HttpPut]
            public async Task<ActionResult> Put(Carro carro)
            {
                context.Attach(carro).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<ActionResult> Delete(int id)
            {
                var carro = await context.Carros.FirstOrDefaultAsync(x => x.Id == id);
                if (carro == null)
                {
                    return NotFound();
                }

                context.Remove(carro);
                await context.SaveChangesAsync();
                return NoContent();
            }
        }
    }
