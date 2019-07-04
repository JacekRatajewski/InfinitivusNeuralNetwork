using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace InfinitivusNeuralNetwork
{
    public class Dictionary
    {
        private static readonly List<string> wordList = new List<string>();
        private static List<string> tempMem = new List<string>();
        public static List<string> Query()
        {
            foreach (var line in File.ReadAllLines(@"../../../InfinitivusNeuralNetwork/Dictionary.txt"))
            {
                var word = line;
                wordList.Add(word);
            }
            return wordList;
        }

        public static string TranslateText(string text, string fromCulture, string toCulture)
        {
            fromCulture = fromCulture.ToLower();
            toCulture = toCulture.ToLower();
            string[] tokens = fromCulture.Split('-');
            if (tokens.Length > 1)
                fromCulture = tokens[0];
            tokens = toCulture.Split('-');
            if (tokens.Length > 1)
                toCulture = tokens[0];
            string url = string.Format(@"https://www.bing.com/translator/t?client=j&text={0}&hl=en&sl={1}&tl={2}",
                                       HttpUtility.UrlEncode(text), fromCulture, toCulture);
            var web = new WebClient();
            web.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0");
            web.Headers.Add(HttpRequestHeader.AcceptCharset, "UTF-8");
            web.Encoding = Encoding.UTF8;
            string html = web.DownloadString(url);
            string result = html.Trim(new char[] { '/', '"' });
            return result;
        }

        public static void SaveToTempMem(List<string> value)
        {
            tempMem = value;
        }

        public static List<string> GetFromTempMem()
        {
            return tempMem;
        }

        public enum Pluralization
        {
            IsSingular = 0,
            IsPlural = 1
        }
    }
}
