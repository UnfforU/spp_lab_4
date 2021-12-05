using NUnit.Framework;
using TestGeneratorLib.Block;
using TestGeneratorLib.Model;

namespace TestGeneratorTests
{
    public class GenetatorTest
    {
        private string Code = @"using System.Collections.Generic;

            public class T3
            {
                public IEnumerable<int> Interface { get; private set; }

                public T3(IEnumerable<int> a){}
    
                public void Function1(int b, string c){}

                public void Function2(){}
            }";

        private FileData Data;

        [SetUp]
        public void Setup()
        {
            Data = Analyzer.GetFileData(Code);
        }

        [Test]
        public void TestFileData()
        {
            Assert.IsNotNull(Data);
            Assert.AreEqual(1, Data.ClassesData.Count);
        }
        
        [Test]
        public void TestClassesData()
        {
            Assert.IsNotNull(Data.ClassesData[0]);
            Assert.AreEqual("T3", Data.ClassesData[0].Name);
            Assert.AreEqual(1, Data.ClassesData[0].ConstructorData.Count);
            Assert.AreEqual(2, Data.ClassesData[0].MethodsData.Count);
        }

        [Test]
        public void TestConstructorsData()
        {
            Assert.IsNotNull(Data.ClassesData[0].ConstructorData[0]);
            Assert.AreEqual("T3", Data.ClassesData[0].ConstructorData[0].Name);
            Assert.AreEqual(1, Data.ClassesData[0].ConstructorData[0].Parameters.Count);
        }

        [Test]
        public void TestMethodsData()
        {
            Assert.IsNotNull(Data.ClassesData[0].MethodsData[0]);
            Assert.AreEqual("Function1", Data.ClassesData[0].MethodsData[0].Name);
            Assert.AreEqual(2, Data.ClassesData[0].MethodsData[0].Parameters.Count);
            Assert.AreEqual("void", Data.ClassesData[0].MethodsData[0].ReturnType);

            Assert.IsNotNull(Data.ClassesData[0].MethodsData[1]);
            Assert.AreEqual("Function2", Data.ClassesData[0].MethodsData[1].Name);
            Assert.AreEqual(0, Data.ClassesData[0].MethodsData[1].Parameters.Count);
            Assert.AreEqual("void", Data.ClassesData[0].MethodsData[1].ReturnType);
        }
    }
}