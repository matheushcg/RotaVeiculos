using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RotaVeiculos.Models;
using RotaVeiculos.Repositories.Interfaces;
using RotaVeiculos.Services.Interfaces;

namespace RotaVeiculos.Controllers
{
    [Route("api/cargo")]
    [ApiController]

    public class CargoController : ControllerBase
    {

        private readonly ICargoService _cargoService;

        public CargoController(ICargoService cargoService)
        {
            _cargoService = cargoService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<Cargo>>> BuscarTodosCargos()
        {
            List<Cargo> cargos = await _cargoService.BuscarTodosCargos();
            return Ok(cargos);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Cargo>> BuscarPorId(int id)
        {
            Cargo cargos = await _cargoService.BuscarPorId(id);
            return Ok(cargos);
        }
    }
}
