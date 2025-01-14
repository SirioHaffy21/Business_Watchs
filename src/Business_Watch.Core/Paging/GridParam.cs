﻿using Abp.Application.Services.Dto;
using Business_Watch.DynamicFilter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Watch.Paging
{
    public class GridParam : PagedResultRequestDto
    {
        public string Sort { get; set; }
        public SortDirection SortDirection { get; set; }
        /// <summary>
        /// This is property apply OR operator
        /// </summary>
        //public List<ExpressionFilter> SearchItems { get; set; } 

        /// <summary>
        /// This is property apply for AND operator
        /// </summary>
        public List<ExpressionFilter> FilterItems { get; set; }

        public string SearchText { get; set; }
    }

    public class SearchItem
    {
        public object SearchValue { get; set; }
        public string SearchProperty { get; set; }
        public ComparisonOperator Comparison { get; set; }
    }

    public enum SortDirection : byte
    {
        ASC = 0,
        DESC = 1
    }
}
