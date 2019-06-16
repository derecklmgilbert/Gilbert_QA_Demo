using System;
using System.Collections.Generic;
using System.Text;

namespace AlignCareQA.Data
{
    class LandingPageItem
    {
        public string Name;
        public int Count;
        public bool IsParent;
        public List<LandingPageItem> Children = new List<LandingPageItem>();
    }
}
