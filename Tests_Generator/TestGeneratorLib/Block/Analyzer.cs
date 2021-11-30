using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestGeneratorLib.Model;

namespace TestGeneratorLib.Block
{
    public static class Analyzer
    {
        public static FileData GetFileData(string code)
        {
            //Get file root
            CompilationUnitSyntax codeRoot = CSharpSyntaxTree.ParseText(code).GetCompilationUnitRoot();

            //Get all classes
            var classesData = new List<ClassData>();
            foreach (ClassDeclarationSyntax classData in codeRoot.DescendantNodes().OfType<ClassDeclarationSyntax>())
            {
                classesData.Add(GetClassData(classData));
            }

            //Format file data
            return new FileData(classesData);
        }

        private static ClassData GetClassData(ClassDeclarationSyntax classNode)
        {
            //Get constructors information
            var allConstructors = classNode.DescendantNodes().OfType<ConstructorDeclarationSyntax>()
                .Where((constructorData) => constructorData.Modifiers
                .Any((modifier) => modifier.IsKind(SyntaxKind.PublicKeyword)
                ));

            var constructorsData = new List<ConstructorData>();
            foreach(var constructorData in allConstructors)
            {
                constructorsData.Add(GetConstructorData(constructorData));
            }

            //Get methods information
            var allMethods = classNode.DescendantNodes().OfType<MethodDeclarationSyntax>()
                .Where((methodData) => methodData.Modifiers
                .Any((modifier) => modifier.IsKind(SyntaxKind.PublicKeyword)
                ));

            var methodsData = new List<MethodData>();
            foreach (var methodData in allMethods)
            {
                methodsData.Add(GetMethodData(methodData));
            }

            //Format class data
            return new ClassData(classNode.Identifier.ValueText, constructorsData, methodsData);
        }

        private static ConstructorData GetConstructorData(ConstructorDeclarationSyntax constructorNode)
        {
            //Get all parameters
            var parameters = new Dictionary<string, string>();
            foreach (var parameter in constructorNode.ParameterList.Parameters)
            {
                parameters.Add(parameter.Identifier.Text, parameter.Type.ToString());
            }

            //Format constructor info
            return new ConstructorData(constructorNode.Identifier.ValueText, parameters);
        }

        private static MethodData GetMethodData(MethodDeclarationSyntax methodNode)
        {
            //Get all parameters
            var parameters = new Dictionary<string, string>();
            foreach (var parameter in methodNode.ParameterList.Parameters)
            {
                parameters.Add(parameter.Identifier.Text, parameter.Type.ToString());
            }

            //Format method info
            return new MethodData(methodNode.Identifier.ValueText, parameters, methodNode.ReturnType.ToString());
        }
    }
}
