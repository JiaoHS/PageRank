using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PageRank
{
    class Program
    {
        static void Main(string[] args)
        {
            var pageRank = new PageRank<string>(Map.Count);
            //计算30轮
            for (int i = 1; i <= 30; i++)
            {
                pageRank.NextCircle();
                foreach (var item in Map)
                {
                    pageRank.Calc(item.Value);
                }
                foreach (var item in Map)
                {
                    var cRank = pageRank.GetCurrentRank(item.Key);
                    item.Value.Rank = cRank;
                }
                var str = string.Join("\t", Map.Select(item => item.Value.Rank.ToString("N3")));
                Console.WriteLine("第{0}轮\t {1}", i, str);
            }
            Console.ReadLine();
        }

        static Dictionary<string, SparseMatrix<string>> Map = new Dictionary<string, SparseMatrix<string>> 
        {
            //{"http://mil.news.sina.com.cn", new SparseMatrix<string>("http://mil.news.sina.com.cn", 0.25){LinkedItems = new List<string>{ "http://i2.sinaimg.cn/jslib/css/base.1.0.gb2312.css", "http://mil.news.sina.com.cn/css/195/2013/0712/common.css","http://i2.sinaimg.cn/dy/sinatag/addfav_pop_bg.png","http://i1.sinaimg.cn/dy/sinatag/btns_addfav_spirite.png"}}},
            // //{"http://cul.news.sina.com.cn", new SparseMatrix<string>("http://mil.news.sina.com.cn", 0.25){LinkedItems = new List<string>{ "http://n3.sinaimg.cn/news/4803d74b/20171220/add_country_builders.css?20180109", "http://n3.sinaimg.cn/news/926f00e3/20171113/index.css", "http://i1.sinaimg.cn/home/sinaflash.js", "http://i.sso.sina.com.cn/js/ssologin.js"}}}
            {"B", new SparseMatrix<string>("B", 0.25){LinkedItems = new List<string>{"A","B","C","D","E","F","G","H","I","K","U","R"}}},
             {"C", new SparseMatrix<string>("C", 0.25){LinkedItems = new List<string>{"A","B","C","D","E"}}}
            //{'C', new SparseMatrix<char>('C', 0.25){LinkedItems = new List<char>{'C'}}},
            //{'D', new SparseMatrix<char>('D', 0.25){LinkedItems = new List<char>{'B', 'C'}}}
        };
    }
}
