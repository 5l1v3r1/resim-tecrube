using System;
using System.IO;
using System.Threading.Tasks;
using ImageMagick;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HayratYardimLink.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet("Isim")]
        public async Task<IActionResult> Isim(string adSoyad = "")
        {
            var layoutImage = Path.Combine(Directory.GetCurrentDirectory(), "arkaplan.jpeg");
            var newImage = Path.Combine(Directory.GetCurrentDirectory(), "newImage.jpeg");
            var fontPath = Path.Combine(Directory.GetCurrentDirectory(), "Helvetica.ttf");
            
            var layoutImg = new MagickImage(layoutImage);
            
            var readSettings = new MagickReadSettings()
            {
                Font = fontPath, 
                FontFamily = "Helvetica",
                FillColor = new MagickColor("#532547"),
                TextGravity = Gravity.Center,
                BackgroundColor = MagickColors.Transparent,
                Height = 30, // height of text box
                Width = layoutImg.Width 
            };
            
            using (var image = new MagickImage(layoutImg))
            {
                using (var caption = new MagickImage($"label:{"Sayın Abdulsamet İleri"}", readSettings))
                {
                    image.Composite(caption, 0, 35, CompositeOperator.Over);
                    image.Write(newImage);
                }
            }

            //return Redirect(newImage);
            var mm = new MemoryStream(System.IO.File.ReadAllBytes(newImage));
            return Ok(mm);
        }

        [HttpGet("Resim")]
        public async Task<ActionResult> Resim(Guid guid)
        {
            // amazondaki resminin urlnini döndür.
            return Ok();
        }
    }
}