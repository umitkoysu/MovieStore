using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MovieStore.Application.Results
{
    public class BaseServiceResult
    {

        public bool Success { get; protected set; } = true;

        public string Message { get; protected set; }

        public void Fail(string message)
        {
            this.Success = false;
            this.Message = message;
        }

        public void CheckSuccess(bool condition)
        {
            Success = condition;
        }

    }
}
