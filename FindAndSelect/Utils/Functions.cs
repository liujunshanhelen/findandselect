using FindAndSelect.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FindAndSelect.Utils
{
    class Functions
    {
        public static Config ReadConfig(string config)
        {
            if (File.Exists(config))
            {
                try
                {
                    using var file = File.OpenRead(config);
                    var json = JsonSerializer.Deserialize<Config>(file);
                    if (json != null)
                    {
                        json.KeyWords ??= new();
                        return json;
                    }
                }
                catch { }
            }
            return new Config() { KeyWords = new() };
        }
        public static bool SaveConfig(Config config, string path)
        {
            try
            {
                var json = JsonSerializer.Serialize(config);
                if (json != null)
                {
                    File.WriteAllText(path, json);
                    return true;
                }
            }
            catch { }
            return false;
        }

        public static Paper ReadPaper(string name, string paperStr, List<string> keyWords)
        {
            Paper paper = new();
            paper.Name = name;
            paper.KeyWords = new();
            //string[] source = paperStr.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in keyWords)
            {
                //var repeat = CountRepeat(source, word);
                var repeat = System.Text.RegularExpressions.Regex.Matches(paperStr.ToLower(), word).Count;

                paper.KeyWords.Add(word,repeat);
            }
            return paper;
        }

        private static int CountRepeat(string[] source, string word)
        {
            // Create the query.  Use the InvariantCultureIgnoreCase comparision to match "data" and "Data"
            var matchQuery = from w in source
                             where w.Equals(word, StringComparison.InvariantCultureIgnoreCase)
                             select w;
            // Count the matches, which executes the query.  
            return matchQuery.Count();
        }

        public static string ContainKeyWords(Paper paper)
        {
            var res = "";
            foreach (var word in paper.KeyWords)
            {
                if (word.Value > 0)
                    res += word.Key + ",";
            }
            return res;
        }

        public static bool IsRepeat(string all, string word)
        {
            var words = all.Split(",", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            return words.Contains(word);
        }
        /*
        public static (string[], string[])? GetSearchKeyWords(string include, string exclude, List<string> keywords)
        {
            string[] inc = include.Trim().Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            string[] exc = exclude.Trim().Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            foreach(var item in exc)
            {
                if(inc.Contains(item))
                {
                    MessageBox.Show("请勿在包含和排除列表中添加同一关键字!");
                    return null;
                }
            }
            foreach(var item in inc)
            {
                if(!keywords.Contains(item))
                {
                    MessageBox.Show("请勿输入未添加的关键字!");
                    return null;
                }
            }
            foreach (var item in exc)
            {
                if (!keywords.Contains(item))
                {
                    MessageBox.Show("请勿输入未添加的关键字!");
                    return null;
                }
            }
            return (inc, exc);
        }*/

        public static (List<string[]>, List<string[]>)? GetSearchKeyWords(string include, string exclude, List<string> keywords)
        {
            string[] inc = include.Trim().Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            string[] exc = exclude.Trim().Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            List<string[]> resInc = new();
            List<string[]> resExc = new();
            foreach (var item in inc)
            {
                string[] tmp = item.Split('|', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                if (IsRepeat4Search(resInc, tmp))
                {
                    MessageBox.Show("请勿输入重复的关键字!");
                    return null;
                }
                resInc.Add(tmp);
            }
            foreach (var item in exc)
            {
                string[] tmp = item.Split('|', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                if (IsRepeat4Search(resExc, tmp) || IsRepeat4Search(resInc, tmp))
                {
                    MessageBox.Show("请勿输入重复的关键字!");
                    return null;
                }
                resExc.Add(tmp);
            }

            if(NotInKeys(resExc, keywords) || NotInKeys(resExc, keywords))
            {
                MessageBox.Show("请勿输入未添加的关键字!");
                return null;
            }
            return (resInc, resExc);
        }
        private static bool IsRepeat4Search(List<string[]> list, string[] words)
        {
            foreach (var item in list)
            {
                foreach(var word in words)
                {
                    if (item.Contains(word))
                        return true;
                }
            }
            return false;
        }
        private static bool NotInKeys(List<string[]> listSearchIn, List<string> listToFind)
        {
            foreach (var item in listSearchIn)
            {
                foreach(var key in item)
                {
                    if (!listToFind.Contains(key))
                        return true;
                }
            }
            return false;
        }

    }
}
