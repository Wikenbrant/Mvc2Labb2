using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mvc2Labb2.Data;

namespace Mvc2Labb2.ViewModels
{
    public class ListActorsViewModel
    {
        
        public IEnumerable<ActorViewModel> Items { get; set; }
        public OrderByViewModel OrderByViewModel { get; set; } = new OrderByViewModel();
        public PagingViewModel PagingViewModel { get; set; } = new PagingViewModel();
        public class ActorViewModel
        {
            public int ActorId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}
