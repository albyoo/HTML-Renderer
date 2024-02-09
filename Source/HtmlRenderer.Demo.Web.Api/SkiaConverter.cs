using HtmlRenderer.Demo.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheArtOfDev.HtmlRenderer.Demo.Common;
using TheArtOfDev.HtmlRenderer.SkiaSharp;

namespace HtmlRenderer.Demo.Web.Api
{
    public class SkiaConverter : SampleConverterBase, IStreamPdfGenerator
    {
        public async Task<Stream> GenerateSampleAsync(HtmlSample sample)
        {
            var margins = PdfGenerateConfig.MilimitersToUnits(18f, 15f);

            var config = new PdfGenerateConfig();
            config.PageSize = PageSize.A4;
            config.PageOrientation = PageOrientation.Portrait;
            config.MarginLeft = (int)margins.Width;
            config.MarginRight = (int)margins.Width;
            config.MarginTop = (int)margins.Height;
            config.MarginBottom = (int)margins.Height;

            var stream = new MemoryStream();
            await PdfGenerator.GeneratePdfAsync(sample.Html, stream, config, imageLoad: OnImageLoaded);
            stream.Seek(0, SeekOrigin.Begin);

            return stream;
        }
    }
}
