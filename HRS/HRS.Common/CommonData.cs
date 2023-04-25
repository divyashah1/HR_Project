namespace HRS.Common
{
    public class CommonData<T>
    {
       
        public string Message { get; set; }
      //  public string Error_Message { get; set; }

        public bool Status { get; set; }

        public T Data { get; set; }

        public static CommonData<T> Success(T data)
        {
            return new CommonData<T> { Status = true, Data = data };
        }

        public static CommonData<T> Error(string Error_Message)
        {
            return new CommonData<T> { Status = false, Message = Error_Message };
        }
    }
}