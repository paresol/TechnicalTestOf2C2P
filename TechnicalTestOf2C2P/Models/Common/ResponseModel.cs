namespace TechnicalTestOf2C2P.Models.Common
{
    public class ResponseModel<T> where T : new()
    //public class ResponseModel()
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
