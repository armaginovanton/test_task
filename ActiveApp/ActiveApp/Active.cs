using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveApp
{
    public class Active
    {
        public string Name { get; set; }
        private List<ParamActive> Params = new List<ParamActive>();

        public void Add(ParamActive paramActive)
        {
            Params.Add(paramActive);
        }

        public void Delete(ParamActive paramActive)
        {
            Params.Remove(paramActive);
        }

        public List<ParamActive> GetParams()
        {
            return Params;
        }

        public void SetParams(List<ParamActive> paramActives)
        {
            Params = paramActives;
        }
    }
}
