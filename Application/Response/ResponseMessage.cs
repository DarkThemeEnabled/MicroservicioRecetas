using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public class ResponseMessage
    {

        public int code { get; set; }
        public object result { get; set; }

         public ResponseMessage(int code, object result)
         {
            this.code = code;
            this.result = result;
         }
        
    }
}
