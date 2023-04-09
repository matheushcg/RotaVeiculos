using Microsoft.AspNetCore.Mvc;

namespace RotaVeiculos.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<ActionResult<dynamic>> Login(string email, string senha);
    }
}
