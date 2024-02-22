using MultitenantInventario.Domain.Entities;

namespace MultitenantInventario.Application.Interfaces
{
    public interface IAuthenticationServices
    {
        string GenerateJwtToken(User user);
    }
}
