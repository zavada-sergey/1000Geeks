using System.Collections.Generic;

namespace BLL.ActualResults
{
    public class ActualResult<T> : ActualResult
    {
        public T Result { get; set; }

        public ActualResult() { }
        public ActualResult(string error) : base(error) { }
        public ActualResult(List<string> errors) : base(errors) { }
    }
}