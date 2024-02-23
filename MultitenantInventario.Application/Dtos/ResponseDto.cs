namespace MultitenantInventario.Application.Dtos
{
    public class ResponseDto<T> where T : class
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
