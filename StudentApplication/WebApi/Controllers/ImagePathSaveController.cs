using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Web;
using System.Drawing;

namespace WebApi.Controllers
{
    public class ImagePathSaveController : ApiController
    {
        [HttpPost]
     //   [Authorize]
        [AllowAnonymous]
        public IHttpActionResult ImageSavepath()
        {
            string FoldeCreate = System.Web.HttpContext.Current.Server.MapPath("~/Images");
            if (!Directory.Exists(FoldeCreate))
            {
                Directory.CreateDirectory(FoldeCreate);
            }
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var Fileuploard = System.Web.HttpContext.Current.Request.Files["Imagepathsave"];
                var savesimages = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Images"), Fileuploard.FileName);
                var ThumbnailPath = MakeimageThumbnail(300, 300, Fileuploard.InputStream,
                    Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/ThumbnailImage"), Fileuploard.FileName));
                Fileuploard.SaveAs(savesimages);
                var data = new
                {
                    Path = savesimages.ToString(),
                    thumbnailPath= ThumbnailPath.ToString()

                };
                
                return Ok(data);
            }
            return null;
        }
        public string MakeimageThumbnail(int Width, int Height, Stream streamImg, string saveFilePath)
        {
            Bitmap sourceImage = new Bitmap(streamImg);
            using (Bitmap objBitmap = new Bitmap(Width, Height))
            {
                objBitmap.SetResolution(sourceImage.HorizontalResolution, sourceImage.VerticalResolution);
                using (Graphics objGraphics = Graphics.FromImage(objBitmap))
                {
                    objGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    objGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    objGraphics.DrawImage(sourceImage, 0, 0, Width, Height);
                    objBitmap.Save(saveFilePath);
                    return saveFilePath;
                }
            }
        }
    }
}
