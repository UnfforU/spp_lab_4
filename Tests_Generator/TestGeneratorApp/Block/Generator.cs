using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace TestGeneratorApp.Block
{
    public class Generator
    {
        public Task Generate(string sourcePath, string[] fileNames, string destPath, int maxGeneratorTasks)
        {
            Directory.CreateDirectory(destPath);

            var linkOptions = new DataflowLinkOptions { PropagateCompletion = true };
            var execOptions = new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = maxGeneratorTasks };

            //Read files data
            var downloadStringBlock = new TransformBlock<string, string>
                (
                async path =>
                {
                    using (var reader = new StreamReader(path)) { return await reader.ReadToEndAsync(); }
                }, 
                execOptions
                );

            return downloadStringBlock.Completion;
        }
    }
}
