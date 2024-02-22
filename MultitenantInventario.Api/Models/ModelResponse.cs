namespace EdynamicsLog.Prueba.Api.Models
{
    public class ModelResponse<T> where T : class
    {
        public int Status { get; set; }
        public string StatusText { get; set; } = string.Empty;
        public T Data { get; set; }
    }
}
