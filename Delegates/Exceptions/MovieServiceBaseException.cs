using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnings.Exceptions
{
    public class MovieServiceBaseException : Exception
    {
        public  string Reason { get; }
        public MovieServiceBaseException() { }
        public MovieServiceBaseException(string message) : base(message) { }
        protected MovieServiceBaseException(string message, Exception inner) : base(message, inner) { }
        protected MovieServiceBaseException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
