using System;
using Kastra.Module.HtmlView.DTO;

namespace Kastra.Module.HtmlView.Business.Contracts
{
    public interface IHtmlBusiness
    {
        HtmlContentInfo GetHtmlContent(Int32 moduleId);
        void SaveHtmlContent(HtmlContentInfo htmlContentInfo);
        void DeleteHtmlContent(Int32 contentId);
    }
}
