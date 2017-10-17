using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordsApi.Queries
{
    public class GetWordnikBaseUrlQuery : IGetWordnikBaseUrlQuery
    {
        public string Query()
        {
            return "http://api.wordnik.com";
        }
    }
}
