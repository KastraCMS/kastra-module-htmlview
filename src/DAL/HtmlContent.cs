﻿using System;

namespace Kastra.Module.HtmlView.DAL
{
    public class HtmlContent
    {
        public int ContentId { get; set; }
        public int ModuleId { get; set; }
        public string Content { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public String CreatedBy { get; set; }
		public String UpdatedBy { get; set; }
    }
}
