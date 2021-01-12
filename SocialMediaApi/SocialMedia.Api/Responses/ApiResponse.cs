namespace SocialMedia.Api.Responses
{
    public class ApiResponse<T>
    {
        #region Attribute
        public T Data { get; set; }
        #endregion

        public ApiResponse(T data)
        {
            this.Data = data;
        }


    }
}
