using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClean.Application.Common.Helper.Pagination
{
    public class PagingOptions
    {
        [Range(1, 9999)] public int Page { get; set; } = 1;

        [Range(1, 100)] public int Limit { get; set; } = 10;

        public string Search { get; set; }
    }
}