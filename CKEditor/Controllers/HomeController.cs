using CKEditor.Models;
using CKEditor.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CKEditor.Controllers
{
	public class HomeController : Controller
	{
		HomeService service = new HomeService();

		public ActionResult Articles()
		{
			return View();
		}

		public ActionResult Article(int? Id)
		{
			if (!Id.HasValue)
			{
				return View("Articles");
			}

			ViewBag.Id = Id;

			return View();
		}

		[HttpPost]
		public JsonResult GetList(int page, int pagesize)
		{
			var data = service.GetList(page, pagesize);

			return Json(new { list = data.Item1, pageinfo = data.Item2 });
		}

		[HttpPost]
		public JsonResult GetData(int Id)
		{
			var data = service.GetData(Id);

			return Json(data);
		}

		public ActionResult Create()
		{
			// 刪除使用者暫存資料夾
			var TempSavePath = Server.MapPath("/UploadImg/T_/");

			if (Directory.Exists(TempSavePath))
			{
				Directory.Delete(TempSavePath, true);
			}

			return View();
		}

		[HttpPost]
		public JsonResult Create(News data)
		{
			var result = service.Create(data);

			return Json(result);
		}

		[HttpPost]
		public ActionResult UploadPicture(HttpPostedFileBase upload, string CKEditorFuncNum)
		{
			string result = "";

			if (upload != null && upload.ContentLength > 0)
			{
				bool exist = Directory.Exists(Server.MapPath("/UploadImg/"));

				if (!exist)
				{
					Directory.CreateDirectory(Server.MapPath("/UploadImg/"));
				}

				var path = string.Format("~/UploadImg/{0}.png", Guid.NewGuid().ToString());

				upload.SaveAs(Server.MapPath(path));

				var imageUrl = Url.Content(path);

				var vMessage = string.Empty;

				result = @"<script>window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ", \"" + imageUrl + "\", \"" + vMessage + "\");</script>";
			}

			return Content(result);
		}

		[HttpPost]
		public ActionResult ImageUpload()
		{
			var file = System.Web.HttpContext.Current.Request.Files["HelpSectionImages"];

			if (file != null && file.ContentLength > 0)
			{
				var imgPath = service.CreateDirectory("/UploadImg/T_" + User.Identity.Name + "/") + file.FileName;

				var Path = Server.MapPath(imgPath);

				file.SaveAs(Path);
				return Content(imgPath);
			}

			return Content("");
		}
	}
}