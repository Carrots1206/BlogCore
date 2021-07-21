using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCoreModel.Response
{
    public class ResponseModel
    {
        public int Code { get; set; }

        public string Result { get; set; }

        public dynamic Data { get; set; }
    }
}
