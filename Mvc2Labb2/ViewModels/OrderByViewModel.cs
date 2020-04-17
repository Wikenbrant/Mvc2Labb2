using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mvc2Labb2.Data;
using Mvc2Labb2.Models.Enums;

namespace Mvc2Labb2.ViewModels
{
    public class OrderByViewModel
    {
        public OrderByType OrderBy { get; set; }
        public string PropertyName { get; set; }
        public string CurrentPropertyName { get; set; }
    }
}
