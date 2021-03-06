using System;
using System.Threading.Tasks;
using Kastra.Core.Attributes;
using Kastra.Core.Dto;
using Kastra.Core.Modules;
using Kastra.Core.Modules.ViewComponents;
using Kastra.Module.HtmlView.Business.Contracts;
using Kastra.Module.HtmlView.DAL;
using Kastra.Module.HtmlView.DTO;
using Kastra.Module.HtmlView.Models;
using Microsoft.AspNetCore.Identity;

namespace Kastra.Module.HtmlView
{
    [ViewComponentAuthorize(Claims = "GlobalSettingsEdition")]
    public class SettingsViewComponent : ModuleViewComponent
    {
        private readonly HtmlViewContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHtmlBusiness _htmlBusiness;

        public SettingsViewComponent(HtmlViewContext dbContext, IHtmlBusiness htmlBusiness, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _htmlBusiness = htmlBusiness;
            _userManager = userManager;
        }
        
        public override Task<ModuleViewComponentResult> OnViewComponentLoad()
        {
            SettingsModel model = new SettingsModel(this);
            model.PageId = Page.PageId;

            HtmlContentInfo htmlContent = _htmlBusiness.GetHtmlContent(Module.ModuleId);

            if (Request.Method == "POST")
            {
                string userId = _userManager.GetUserId(HttpContext.User);

                if (htmlContent == null)
                {
                    htmlContent = new HtmlContentInfo();
                    htmlContent.ModuleId = Module.ModuleId;
                    htmlContent.CreatedAt = DateTime.UtcNow;
                    htmlContent.CreatedBy = userId;
                }

                htmlContent.Content = model.Content;
                htmlContent.UpdatedAt = DateTime.UtcNow;
                htmlContent.UpdatedBy = userId;

                _htmlBusiness.SaveHtmlContent(htmlContent);
            }
            else
            {
                model.Content = htmlContent?.Content;
            }

            return Task.FromResult(ModuleView("Settings", model));
        }
    }
}