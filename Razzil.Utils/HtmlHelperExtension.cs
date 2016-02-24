using Razzil.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Razzil.Utils
{
    public static class HtmlHelperExtension
    {
        public static MvcHtmlString DisplayForBinaryImage(this System.Web.Mvc.HtmlHelper html, byte[] image, int width, int height, string alt)
        {
            try
            {
                string imageSrc = "";
                if (image != null)
                {
                    string imageBase64 = Convert.ToBase64String(image);
                    imageSrc = string.Format("data:image/gif;base64,{0}", imageBase64);
                }
                // build the <img> tag
                var imgBuilder = new TagBuilder("img");
                imgBuilder.MergeAttribute("src", imageSrc);
                imgBuilder.MergeAttribute("alt", alt);
                string imgHtml = imgBuilder.ToString(TagRenderMode.SelfClosing);

                return MvcHtmlString.Create(imgHtml);
            }
            catch (Exception ex)
            {
                DebugHelper.Error(ex);
                return MvcHtmlString.Empty;
            }
            
        }
    }
}