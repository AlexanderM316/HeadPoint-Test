using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadPoint_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputStr = { "ток", "рост", "кот", "торс", "кто", "фывап", "рок" };
            Console.OutputEncoding = Encoding.UTF8;
            Group(inputStr);
            Console.ReadKey();

            
        }
        static void Group(string[] str)
        {
            Dictionary<String,
               List<int>> Hash = new Dictionary<String, List<int>>();

            int i = 0;
            foreach (string s in str)
            {
                String key = GetKey(s);

                if (Hash.ContainsKey(key))
                {
                    List<int> l = Hash[key];
                    l.Add(i);
                    Hash[key] = l;
                }
                else
                {
                    List<int> newL = new List<int>();
                    newL.Add(i);
                    Hash.Add(key, newL);
                }
                i++;
            }

            foreach (KeyValuePair<String, List<int>> it in Hash)
            {
                List<int> get = it.Value;
                Console.Write("[");
                foreach (int v in get)
                    Console.Write(str[v] + ",");

                Console.WriteLine("]");
            }

        }
        static String GetKey(String str)
        {
            bool[] visited = new bool[32]; //32 is the number of letters in russian alpahet 

          
            for (int j = 0; j < str.Length; j++)
                visited[str[j] - 'а'] = true;

            String key = "";

            for (int j = 0; j < 32; j++)
                if (visited[j])
                    key = key + (char)('а' + j);

            return key;
        }
    }
}
