using Kastra.Core.ViewComponents;
using Kastra.Module.HtmlView.Business.Contracts;
using Kastra.Module.HtmlView.DAL;
using Kastra.Module.HtmlView.Models;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Kastra.Module.HtmlView
{
    public class HtmlViewComponent : ModuleViewComponent
    {
        private readonly HtmlViewContext _dbContext = null;
        private readonly IHtmlBusiness _htmlBusiness = null;

        public HtmlViewComponent(HtmlViewContext dbContext, IHtmlBusiness htmlBusiness)
        {
            _dbContext = dbContext;
            _htmlBusiness = htmlBusiness;
        }
        
        public override ViewViewComponentResult OnViewComponentLoad()
        {
            HtmlModel model = new HtmlModel(this);
            model.Content = _htmlBusiness.GetHtmlContent(Module.ModuleId)?.Content;

            return ModuleView("Index", model);
        }
    }
}
