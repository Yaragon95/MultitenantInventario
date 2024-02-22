namespace EdynamicsLog.Prueba.Api.Models
{
    public class ResponseJwt
    {
        public string AccessToken { get; set; }
        public ICollection<object> Tenants { get; set; } = [];
    }
}
