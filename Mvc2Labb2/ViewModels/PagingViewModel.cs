using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc2Labb2.ViewModels
{
    public class PagingViewModel
    {
        public int LastPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NextPage { get; set; }
    }
}
