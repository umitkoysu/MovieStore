namespace Project.MovieStore.Domain.Exceptions
{
    public class CustomException : Exception
    {
        public string Name { get; set; } = "UndefinedCustomException";
        public int StatusCode { get; set; } = 500;

        public CustomException(): base("Undefined Error Message")
        {
            
        }

        public CustomException(string message): base(message)
        {
            
        }

        public CustomException(string message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        public CustomException(string message, int statusCode, string name) : base(message)
        {
            Name = name;
            StatusCode = statusCode;
        }

        public CustomException(string message,  int statusCode , string name , int hResult) : base(message)
        {
            Name = name;
            StatusCode = statusCode;
            HResult = hResult;
        }
    }

    public class TechnicalCustomException : CustomException
    {

    }

    public class LogicalCustomException : CustomException
    {
    
    }

}
