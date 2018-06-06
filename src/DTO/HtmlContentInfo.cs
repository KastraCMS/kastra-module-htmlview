using System;
using Kastra.Core.Dto;

namespace Kastra.Module.HtmlView.DTO
{
    public class HtmlContentInfo
    {
		public int ContentId { get; set; }
		public int ModuleId { get; set; }
		public string Content { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public String CreatedBy { get; set; }
		public String UpdatedBy { get; set; }

		public virtual ModuleInfo Module { get; set; }
    }
}
