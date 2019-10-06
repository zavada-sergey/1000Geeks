using System.Collections.Generic;

namespace BLL.ActualResults
{
    public class ActualResult
    {
        public List<string> ErrorsList { get; set; }
        public bool IsValid { get; set; }

        public ActualResult()
        {
            IsValid = true;
            ErrorsList = new List<string>();
        }

        public ActualResult(string error)
        {
            IsValid = false;
            ErrorsList = new List<string> { error };
        }

        public ActualResult(List<string> errors)
        {
            IsValid = false;
            ErrorsList = errors;
        }
    }
}