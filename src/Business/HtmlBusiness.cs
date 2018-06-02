using System;
using System.Linq;
using Kastra.Module.HtmlView.Business.Contracts;
using Kastra.Module.HtmlView.DAL;
using Kastra.Module.HtmlView.DTO;
using Kastra.Module.HtmlView.DTO.Mappers;

namespace Kastra.Module.HtmlView.Business
{
    public class HtmlBusiness : IHtmlBusiness
    {
        private readonly HtmlViewContext _dbContext;

        public HtmlBusiness(HtmlViewContext context)
        {
            _dbContext = context;
        }

        public HtmlContentInfo GetHtmlContent(Int32 moduleId)
        {
            return _dbContext.HtmlContent.SingleOrDefault(h => h.ModuleId == moduleId)?.ToHtmlContentInfo();
        }

        public void SaveHtmlContent(HtmlContentInfo htmlContentInfo)
        {
            HtmlContent htmlContent = null;

            // Get content if exists
            htmlContent = _dbContext.HtmlContent.SingleOrDefault(h => h.ModuleId == htmlContentInfo.ModuleId);

            if(htmlContent == null)
                htmlContent = new HtmlContent();

            htmlContent.ModuleId = htmlContentInfo.ModuleId;
            htmlContent.Content = htmlContentInfo.Content;
            htmlContent.CreatedAt = htmlContentInfo.CreatedAt;
            htmlContent.CreatedBy = htmlContentInfo.CreatedBy;
            htmlContent.UpdatedAt = htmlContentInfo.UpdatedAt;
            htmlContent.UpdatedBy = htmlContentInfo.UpdatedBy;

            if(htmlContent.ContentId == 0)
                _dbContext.HtmlContent.Add(htmlContent);

            _dbContext.SaveChanges();
        }

        public void DeleteHtmlContent(Int32 contentId)
        {
            HtmlContent htmlContent = _dbContext.HtmlContent.SingleOrDefault(a => a.ContentId == contentId);

            if (htmlContent != null)
			{
                _dbContext.HtmlContent.Remove(htmlContent);
				_dbContext.SaveChanges();
			}
		}
    }
}