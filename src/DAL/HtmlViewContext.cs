using Microsoft.EntityFrameworkCore;

namespace Kastra.Module.HtmlView.DAL
{
    public class HtmlViewContext : DbContext
    {
        public virtual DbSet<HtmlContent> HtmlContent { get; set; }

        public HtmlViewContext(DbContextOptions<HtmlViewContext> options)
            : base(options)
        {
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HtmlContent>(entity => 
            {
				entity.ToTable("Kastra_Html_Content");

                entity.HasKey(e => e.ContentId)
					.HasName("PK_Kastra_Html_Content");

				entity.Property(e => e.ContentId).HasColumnName("HtmlContentID");

				entity.Property(e => e.Content).HasColumnName("HtmlContent");

				entity.Property(e => e.ModuleId).HasColumnName("ModuleID");

				entity.Property(e => e.CreatedAt)
					.HasColumnType("datetime")
					.HasDefaultValueSql("getdate()");

				entity.Property(e => e.UpdatedAt)
					.HasColumnType("datetime")
					.HasDefaultValueSql("getdate()");

				entity.Property(e => e.UpdatedBy)
					.HasColumnName("UpdatedBy")
					.HasMaxLength(450);

				entity.Property(e => e.CreatedBy)
					.HasColumnName("CreatedBy")
					.HasMaxLength(450);
            });
        }
    }
}
