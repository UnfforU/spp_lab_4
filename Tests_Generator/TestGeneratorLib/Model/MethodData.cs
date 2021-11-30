using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGeneratorLib.Model
{
    public class MethodData
    {
        private string _name;
        private Dictionary<string, string> _parameters;
        private string _returnType;

        public string Name => _name;
        public Dictionary<string, string> Parameters => _parameters;
        public string ReturnType => _returnType;

        public MethodData(string name, Dictionary<string, string> parameters, string returnType)
        {
            _name = name;
            _parameters = parameters;
            _returnType = returnType;
        }
    }
}
