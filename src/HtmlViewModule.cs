using Kastra.Core;
using Kastra.Module.HtmlView.Business;
using Kastra.Module.HtmlView.Business.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Kastra.Module.HtmlView.DAL;
using System;
using Kastra.Core.Business;

namespace Kastra.Module.HtmlView
{
    public class DependencyRegister : ModuleBase
    {
        public override void SetDependencyInjections(IServiceCollection services, IConfiguration configuration)
        {
			services.AddDbContext<HtmlViewContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IHtmlBusiness, HtmlBusiness>();
        }

        public override void Install(IServiceProvider serviceProvider, IViewManager viewManager)
        {
            base.Install(serviceProvider, viewManager);

            HtmlViewContext dbContext = serviceProvider.GetService<HtmlViewContext>();

            if(dbContext == null)
                throw new Exception("Unable to install HtmlView tables");

            dbContext.Database.Migrate();
        }
    }
}
