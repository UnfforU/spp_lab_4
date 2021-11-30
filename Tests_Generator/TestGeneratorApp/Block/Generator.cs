using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using TestGeneratorLib.Block;

namespace TestGeneratorApp.Block
{
    public class Generator
    {
        public Task Generate(string sourcePath, string destPath, string[] fileNames, int maxGeneratorTasks)
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

            //Generate tests
            var generateTestsBlock = new TransformManyBlock<string, KeyValuePair<string, string>>
            (
                async sourceCode =>
                {
                    var fileInfo = await Task.Run(() => Analyzer.GetFileData(sourceCode));
                    return await Task.Run(() => CodeCreator.GenerateTests(fileInfo));
                },
                execOptions
            );

            // Write tests to files
            var writeFileBlock = new ActionBlock<KeyValuePair<string, string>>
                (
                async fileNameCodePair =>
                {
                    using (var writer = new StreamWriter(destPath + '\\' + fileNameCodePair.Key + ".cs")) { await writer.WriteAsync(fileNameCodePair.Value); }
                },
                execOptions
                );

            // Complete tasks (union blocks)
            downloadStringBlock.LinkTo(generateTestsBlock, linkOptions);
            generateTestsBlock.LinkTo(writeFileBlock, linkOptions);
            foreach (var fileName in fileNames)
            {
                downloadStringBlock.Post(sourcePath + @"\" + fileName);
            }

            downloadStringBlock.Complete();
            return writeFileBlock.Completion;
        }
    }
}
