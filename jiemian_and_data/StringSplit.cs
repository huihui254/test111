using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace jiemian_and_data
{
    public abstract class StringSplit
    {
        public string Sepatator  //保存分隔符
        { set; get; }
        public bool Duplicates   //确定是否需要忽略重复分隔符
        { set; get; }
        public abstract string[] Splitting(string str);
    }

    public class StringSplitFun : StringSplit
    {
        public StringSplitFun()
            : this(",")
        {
            //this.Sepatator = ",";
            //this.Duplicates = false;
        }

        public StringSplitFun(string separator)
        {
            this.Sepatator = separator;
            this.Duplicates = false;
        }

        public override string[] Splitting(string str)
        {
            char[] cgap = Sepatator.ToCharArray();
            string[] strs = null;
            if (Duplicates)
                strs = str.Split(cgap, StringSplitOptions.None);
            else
                strs = str.Split(cgap, StringSplitOptions.RemoveEmptyEntries);
            return strs;
        }
    }

    public class StringSplitRegular : StringSplit
    {
        public StringSplitRegular() : this(",")
        {
        }

        public StringSplitRegular(string separator)
        {
            this.Sepatator = separator;
            this.Duplicates = false;
        }

        public override string[] Splitting(string str)
        {
            string[] strs = null;
            if (Duplicates)
                strs = Regex.Split(str, Sepatator, RegexOptions.IgnoreCase);
            else
                strs = Regex.Split(str, Sepatator, RegexOptions.None);
            return strs;
        }
    }

}