using System;
using Kastra.Core.ViewComponents;

namespace Kastra.Module.HtmlView.Models
{
    public class SettingsModel : ModuleModelBinder
    {
        public SettingsModel(ModuleViewComponent moduleView) : base(moduleView)
        {
        }

        public String Content { get; set; }

        public Int32 PageId { get; set; }
    }
}