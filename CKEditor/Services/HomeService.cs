using CKEditor.Models;
using CKEditor.Toole;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace CKEditor.Services
{
	public class HomeService
	{
		DatabaseEntities db = new DatabaseEntities();

		public Tuple<object, PageInfo> GetList(int page, int pagesize)
		{
			Random rnd = new Random();

			string[] rndClass = { "normal", "small", "medium", "large" };

			var query = db.News
				.OrderByDescending(x => x.Date)
				.SkipAndTakeList(page, pagesize)
				.ContainSelect(x => new
				{
					x.Id,
					x.Title,
					x.ImgUrl,
					Class = rndClass[rnd.Next(0, 4)],
					Date = x.Date.ToString("yyyy-MM-dd")
				});

			return new Tuple<object, PageInfo>(query.DataList, query.Pageinfo);
		}

		public DataIndex GetData(int Id)
		{
			var current = db.News.Find(Id);
			var next = db.News.Where(x => x.Id > Id).FirstOrDefault();
			var pre = db.News.Where(x => x.Id < Id).OrderByDescending(y => y.Id).FirstOrDefault();

			DataIndex data = new DataIndex(current, next, pre);

			return data;
		}

		public bool Create(News data)
		{
			try
			{
				data.Content = HttpUtility.HtmlDecode(data.Content);

				if (!string.IsNullOrEmpty(data.ImgUrl))
				{

					var newPath = CreateDirectory("/UploadImg/ArticleImg/") + Guid.NewGuid().ToString() + ".png";

					File.Copy(HttpContext.Current.Server.MapPath(data.ImgUrl), HttpContext.Current.Server.MapPath(newPath), true);

					data.ImgUrl = newPath;
				}

				data.Date = DateTime.Now;

				db.Entry(data).State = EntityState.Added;

				db.SaveChanges();

				return true;
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public string CreateDirectory(string path = "")
		{
			var dic = path;

			bool result = Directory.Exists(HttpContext.Current.Server.MapPath(dic));

			if (!result)
			{
				Directory.CreateDirectory(HttpContext.Current.Server.MapPath(dic));
			}

			return dic;
		}
	}

	public class DataIndex
	{
		public object Current { get; set; }

		public object Previous { get; set; }

		public object Next { get; set; }

		public DataIndex(object current, object previous, object next)
		{
			this.Current = current;

			this.Previous = previous ?? current;

			this.Next = next ?? current;
		}
	}
}