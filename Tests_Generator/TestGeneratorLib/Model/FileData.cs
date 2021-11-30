using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGeneratorLib.Model
{
    public class FileData
    {
        private List<ClassData> _classesData;

        public List<ClassData> ClassesData => _classesData;

        public FileData(List<ClassData> classesData)
        {
            _classesData = classesData;
        }
    }
}
