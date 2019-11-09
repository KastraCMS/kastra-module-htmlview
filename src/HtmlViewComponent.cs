using System.Threading.Tasks;
using Kastra.Core.Modules;
using Kastra.Core.Modules.ViewComponents;
using Kastra.Module.HtmlView.Business.Contracts;
using Kastra.Module.HtmlView.Models;

namespace Kastra.Module.HtmlView
{
    public class HtmlViewComponent : ModuleViewComponent
    {
        private readonly IHtmlBusiness _htmlBusiness;

        public HtmlViewComponent(IHtmlBusiness htmlBusiness)
        {
            _htmlBusiness = htmlBusiness;
        }
        
        public override Task<ModuleViewComponentResult> OnViewComponentLoad()
        {
            HtmlModel model = new HtmlModel(this);
            model.Content = _htmlBusiness.GetHtmlContent(Module.ModuleId)?.Content;

            return Task.FromResult(ModuleView("Index", model));
        }
    }
}
