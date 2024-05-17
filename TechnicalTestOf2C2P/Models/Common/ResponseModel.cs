namespace TechnicalTestOf2C2P.Models.Common
{
    public class ResponseModel<T> where T : new()
    {
        public bool success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ResponseModel() { 
            this.success = true;
            this.Message = "Success";
        }

        public ResponseModel(string message) {
            this.success = false;
            this.Message = message;
        }
    }
}
