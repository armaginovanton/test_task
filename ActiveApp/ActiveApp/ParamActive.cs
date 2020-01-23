using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveApp
{
    public class ParamActive
    {
        public string ParamName { get; set; }
        public string ParamContent { get; set; }

        public ParamActive(string paramName, string paramContent)
        {
            ParamName = paramName;
            ParamContent = paramContent;
        }

        public void Edit(string paramName, string paramContent)
        {
            ParamName = paramName;
            ParamContent = paramContent;
        }
    }
}
