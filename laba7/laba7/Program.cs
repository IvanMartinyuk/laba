using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba7
{
    public class Program
    {
        static string outputPath = "output.txt";
        static string inputPath = "input.txt";
        public static void Main(string[] args)
        {
            CreateOutput();
            CreateInput();
        }

        private static void CreateInput()
        {
            File.Create(inputPath).Close();
            using (var sw = File.AppendText(inputPath))
            {
                var strings = File.ReadAllLines(outputPath).ToList();
                List<int> nums = new List<int>();
                foreach (var str in strings)
                {
                    nums.Add(Convert.ToInt32(str));
                    bool isWrite = true;
                    int last = nums[nums.Count - 1];
                    for (int i = 2; i < last; i++)
                        if (last % i == 0)
                            isWrite = false;
                    if(isWrite)
                        sw.WriteLine(str);
                }
            }
        }

        public static void CreateOutput()
        {
            if (!File.Exists(outputPath))
            {
                int maxnum = 1000;
                File.Create(outputPath).Close();
                using (var sw = File.AppendText(outputPath))
                {
                    for (int i = 0; i < maxnum + 1; i++)
                        sw.WriteLine(i.ToString());
                }
            }
        }
    }
}
