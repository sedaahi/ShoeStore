using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class PaginationInfoViewModel
    {
        public int CurrentPage { get; set; }
        public int ItemsOnPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }
        public int Start => (CurrentPage - 1) * Constants.ITEMS_PER_PAGE + 1;    //pagination üstünde sayfadaki ürün aralığını gösterme için prop ekledik ama sadece set'i var get yok
        public int End => Start + ItemsOnPage - 1;

        public int[] PageNumbers => Pagination(CurrentPage, TotalPages);   //Property get ve seti yok aşağıdaki metodu çağırmak için yazdık
        private static int[] Pagination(int current, int last)         ////Paginationda  1...5 6 7....12 gibi göstermek için (Referanslara bak)
        {
            int delta = 2;
            int left = current - delta;
            int right = current + delta + 1;
            var range = new List<int>();
            var rangeWithDots = new List<int>();
            int? l = null;

            for (var i = 1; i <= last; i++)
            {
                if (i == 1 || i == last || i >= left && i < right)
                {
                    range.Add(i);
                }
            }

            foreach (var i in range)
            {
                if (l != null)
                {
                    if (i - l == 2)
                    {
                        rangeWithDots.Add(l.Value + 1);
                    }
                    else if (i - l != 1)
                    {
                        rangeWithDots.Add(-1);
                    }
                }
                rangeWithDots.Add(i);
                l = i;
            }

            return rangeWithDots.ToArray();
        }
    }
}
