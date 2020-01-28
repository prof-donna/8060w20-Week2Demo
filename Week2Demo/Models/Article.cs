using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Week2Demo.Models
{
    public class Article
    {
        public long Id { get; set; }

        private string _key;
        public string Key
        {
            get
            {
                if (_key == null)
                {
                    _key = Regex.Replace(Title.ToLower(), "[^a-z0-9]", "-");
                }
                return _key;
            }
            set { _key = value; }
        }

        public string Title { get; set; }
        public string Author { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
    }
}
