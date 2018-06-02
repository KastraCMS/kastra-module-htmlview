using Kastra.Business.Mappers;
using Kastra.Module.HtmlView.DAL;

namespace Kastra.Module.HtmlView.DTO.Mappers
{
    public static class HtmlContentMapper
    {
        public static HtmlContentInfo ToHtmlContentInfo(this HtmlContent htmlContent)
        {
            HtmlContentInfo htmlContentInfo = new HtmlContentInfo();
            htmlContentInfo.ContentId = htmlContent.ContentId;
            htmlContentInfo.Content = htmlContent.Content;
            htmlContentInfo.ModuleId = htmlContent.ModuleId;
            htmlContentInfo.CreatedAt = htmlContent.CreatedAt;
            htmlContentInfo.CreatedBy = htmlContent.CreatedBy;
            htmlContentInfo.UpdatedAt = htmlContent.UpdatedAt;
            htmlContentInfo.UpdatedBy = htmlContent.UpdatedBy;

            return htmlContentInfo;
        }

		public static HtmlContent ToHtmlContent(this HtmlContentInfo htmlContentInfo)
		{
			HtmlContent htmlContent = new HtmlContent();
			htmlContent.ContentId = htmlContentInfo.ContentId;
			htmlContent.Content = htmlContentInfo.Content;
			htmlContent.ModuleId = htmlContentInfo.ModuleId;
			htmlContent.CreatedAt = htmlContentInfo.CreatedAt;
			htmlContent.CreatedBy = htmlContentInfo.CreatedBy;
			htmlContent.UpdatedAt = htmlContentInfo.UpdatedAt;
			htmlContent.UpdatedBy = htmlContentInfo.UpdatedBy;

			return htmlContent;
		}
    }
}
