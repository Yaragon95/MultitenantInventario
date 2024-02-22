using Microsoft.AspNetCore.Http;

namespace MultitenantInventario.Middleware
{
    public class TenantMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task Invoke(HttpContext context)
        {
            var pathSegments = context.Request.Path.Value.Split('/');
            var organizationId = pathSegments.Length > 1 ? pathSegments[1] : null;

            if (!string.IsNullOrEmpty(organizationId))
            {
                // Configurar la conexión de la base de datos para la organización
                // Puedes almacenar esta información en el contexto para su uso posterior
                context.Items["OrganizationId"] = organizationId;
            }

            await _next(context);
        }
    }
}
