using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGeneratorLib.Model
{
    public class ConstructorData
    {
        private string _name;
        private Dictionary<string, string> _parameters;

        public string Name => _name;
        public Dictionary<string, string> Parameters => _parameters;
        
        public ConstructorData(string name,  Dictionary<string, string> parameters)
        {
            _name = name;
            _parameters = parameters;
        }
    }
}
