using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGeneratorLib.Model
{
    public class ClassData
    {
        private string _name;
        private List<ConstructorData> _constructorsData;
        private List<MethodData> _methodsData;

        public string Name => _name;
        public List<ConstructorData> ConstructorData => _constructorsData;
        public List<MethodData> MethodsData => _methodsData;

        public ClassData(string name, List<ConstructorData> constructorsData, List<MethodData> methodsData)
        {
            _name = name;
            _constructorsData = constructorsData;
            _methodsData = methodsData;
        }
    }
}
