using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWord.CustomExceptions
{
    public class DuplicateRecordException: Exception
    {
        public DuplicateRecordException(string Message): base(Message)
        {

        }
    }
}
