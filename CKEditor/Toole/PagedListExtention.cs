using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace CKEditor.Toole
{
	public static class PagedListExtention
	{
		public static PageList<T> SkipAndTakeList<T>(this IQueryable<T> datalist, int NowPage, int PageSize)
		{
			var Itemlist = new PageList<T>(NowPage, PageSize, datalist);

			return Itemlist;
		}

		public static PageList<TResult> ContainSelect<T, TResult>(this I_PageList<T> source, Expression<Func<T, TResult>> exprs)
		{
			var datalist = source.ToList().Select(exprs.Compile()).AsQueryable();

			PageList<TResult> NewSource = new PageList<TResult>(source.Pageinfo, datalist);

			return NewSource;
		}
	}
}