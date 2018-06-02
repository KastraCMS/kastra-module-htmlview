using System;
using Kastra.Core.ViewComponents;

namespace Kastra.Module.HtmlView.Models
{
    public class HtmlModel : ModuleModelBinder
    {
        public HtmlModel(ModuleViewComponent moduleView) : base(moduleView)
        {
            
        }

        public String Content { get; set; }
    }
}