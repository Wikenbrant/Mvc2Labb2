using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc2Labb2.ViewModels
{
    public class LinkPartialViewModel
    {
        public OrderByViewModel OrderByViewModel { get; set; } = new OrderByViewModel();
        public PagingViewModel PagingViewModel { get; set; } = new PagingViewModel();
        public string DisplayName { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }
}
