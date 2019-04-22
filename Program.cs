using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NLP_Assingmnet1_cs
{
    internal class Program
    {
        public static string en_tokens = @"D:\Doros\term 8\NLP\Assignment\NLP_Assingmnet1_cs\NLP_Assingmnet1_cs\app_data\en.tokens.en";
        public static string mergedTokens_en = @"D:\Doros\term 8\NLP\Assignment\NLP_Assingmnet1_cs\NLP_Assingmnet1_cs\app_data\mergedTokens.en";

        public static string fa_tokens = @"D:\Doros\term 8\NLP\Assignment\NLP_Assingmnet1_cs\NLP_Assingmnet1_cs\app_data\fa.words.txt";
        public static string mergedTokens_fa = @"D:\Doros\term 8\NLP\Assignment\NLP_Assingmnet1_cs\NLP_Assingmnet1_cs\app_data\mergedTokens.fa";

        //public static string RemoveDigits(string key)
        //{
        //    return Regex.Replace(key, @"\d", "");
        //}
        private static IEnumerable<string> Split(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
        }

        private static string SplitToken(string mergTok, int length)
        {
            string mergeToken = mergTok;

            //mergeToken = Split(mergTok, length);
            string[] lines_enTokens = File.ReadAllLines(fa_tokens);
            string result;
            result = mergTok + " => ";
            for (int i = 0; i <= mergTok.Length; i++)
            {
                length = mergTok.Length - i;
                mergeToken = mergTok.Substring(0, length);

                foreach (var line_enTok in lines_enTokens)
                {
                    if (mergeToken.Count() == length)
                    {
                        if (mergeToken.Equals(line_enTok))
                        {
                            result += " " + line_enTok;

                            mergTok = mergTok.Substring(mergTok.Length - i, i);
                            i = -1;
                        }
                    }
                    //if (line_enTok.LastIndexOf())
                    //{
                    //}
                }
            }

            return result;
        }

        private static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string response;
            string[] mergtok = File.ReadAllLines(mergedTokens_fa);
            int i = 1;
            //response = SplitToken("themagnetic", mergtok.Length);
            //if (response.Any())
            //{
            //    System.IO.File.AppendAllText(@"D:\Doros\term 8\NLP\Assignment\NLP_Assingmnet1_cs\NLP_Assingmnet1_cs\app_data\output\94463125_Assignment1_EN.txt", i + ") " + response + Environment.NewLine);
            //}
            foreach (var item in mergtok)
            {
                response = SplitToken(item, mergtok.Length);
                if (response.Any())
                {
                    System.IO.File.AppendAllText(@"D:\Doros\term 8\NLP\Assignment\NLP_Assingmnet1_cs\NLP_Assingmnet1_cs\app_data\output\94463125_Assignment1_FA.fa", i + ") " + response + Environment.NewLine);
                    i++;
                }
            }
        }
    }
}