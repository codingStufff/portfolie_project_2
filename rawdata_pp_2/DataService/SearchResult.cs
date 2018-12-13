using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace DomainModel
{
    public class SearchResult
    {
        public int postid { get; set; }
        public double? rank { get; set; }
        public string body { get; set; }
    }
}