using RotaVeiculos.Models;

namespace RotaVeiculos.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(Usuario usuario);
    }
}
