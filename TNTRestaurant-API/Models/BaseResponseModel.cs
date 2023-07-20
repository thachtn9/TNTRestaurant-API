namespace TNTRestaurant_API.Models
{
    public class BaseResponseModel
    {
        public string Status { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }
}
