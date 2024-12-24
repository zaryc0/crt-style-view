using FNVCG.COMMON.Events;
using FNVCG.MODEL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Reflection;

namespace FNVCG.MODEL
{
    internal class CodeGenerator : ICodeGenerator
    {
        private Random _random;
        List<string> _words = [];
        public CodeGenerator(int seed = 0)
        {
            if (seed == 0)
            {
                _random = new Random(GenerateSeed());
            }
            else
            {
                _random = new Random(seed);
            }
        }

        public int GenerateCode(out string code)
        {
            int index = _random.Next(0, 20);
            code = _words[index];
            return 0;
        }

        public int GenerateWordList(int length, out List<string> words)
        {
            List<int> indexes = []; 
            List<string> wordList = ReadEmbeddedResource($"{length}_char_list.txt");
            for (int i = 0; i < 20; i++)
            {
                int index;
                do
                {
                    index = _random.Next(0,wordList.Count);
                }
                while (indexes.Contains(index));
                indexes.Add(index);
                _words.Add(wordList[index].ToUpper());
            }
            words = _words;
            return 0;
        }

        private static List<string> ReadEmbeddedResource(string resourceName)
        {
            var lines = new List<string>();
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream(assembly.GetName().Name + ".resources." + resourceName))
            {
                if (stream == null)
                {
                    throw new InvalidOperationException($"Resource {resourceName} not found.");
                }

                using (var reader = new StreamReader(stream))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lines.Add(line);  // Add each line to the list
                    }
                }
            }

            return lines;
        }
        private static Int32 GenerateSeed()
        {
            long seed = DateTime.Now.Ticks;
            while (seed > Int32.MaxValue)
            {
                seed /= 2;
            }
            return (int)seed;
        }

        public void ResetCache()
        {
            int length = _random.Next(4,12);
            _= GenerateWordList(length, out _words);
        }

        public List<string> GetWordList()
        {
            return _words;
        }
    }
}
