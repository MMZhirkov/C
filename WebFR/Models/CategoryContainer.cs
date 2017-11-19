using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFR.Models
{
    public class CategoryContainer
    {
        public string Title { get; set; }
        public string FullPath { get; set; }
        public string Extension { get; set; }
    public CategoryContainer Parent { get; set; }
        public int Index { get; set; }

    }
}