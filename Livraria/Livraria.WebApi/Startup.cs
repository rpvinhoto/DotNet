using Livraria.Dados.Contexto;
using Livraria.Dados.Repositorios;
using Livraria.Dominio.Interfaces.Repositorios;
using Livraria.Dominio.Interfaces.Servicos;
using Livraria.Dominio.Servicos;
using Livraria.WebApi.AppServicos;
using Livraria.WebApi.DependencyInjector;
using Livraria.WebApi.Interfaces.AppServicos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Ninject;
using Ninject.Activation;
using Ninject.Infrastructure.Disposal;
using System;
using System.Threading;

namespace Livraria.WebApi
{
    public class Startup
    {
        private readonly AsyncLocal<Scope> _scopeProvider = new AsyncLocal<Scope>();

        public IConfiguration Configuration { get; }
        private IKernel Kernel { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(o =>
                {
                    var resolver = o.SerializerSettings.ContractResolver;
                    if (resolver != null)
                        (resolver as DefaultContractResolver).NamingStrategy = null;
                });

            services.AddDbContext<LivrariaContext>(o => o.UseSqlServer(Configuration.GetConnectionString("LivrariaConnection")));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddRequestScopingMiddleware(() => _scopeProvider.Value = new Scope());
            services.AddCustomControllerActivation(Resolve);
            services.AddCustomViewComponentActivation(Resolve);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            Kernel = RegisterApplicationComponents(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        private IKernel RegisterApplicationComponents(IApplicationBuilder app)
        {
            var kernel = new StandardKernel();

            // Register application services
            foreach (var ctrlType in app.GetControllerTypes())
            {
                kernel.Bind(ctrlType).ToSelf().InScope(RequestScope);
            }

            kernel.Bind(typeof(IAppServicoBase<>)).To(typeof(AppServicoBase<>)).InScope(RequestScope);
            kernel.Bind<ILivroAppServico>().To<LivroAppServico>().InScope(RequestScope);
            kernel.Bind<IEditoraAppServico>().To<EditoraAppServico>().InScope(RequestScope);
            kernel.Bind<ICategoriaAppServico>().To<CategoriaAppServico>().InScope(RequestScope);

            kernel.Bind(typeof(IServicoBase<>)).To(typeof(ServicoBase<>)).InScope(RequestScope);
            kernel.Bind<ILivroServico>().To<LivroServico>().InScope(RequestScope);
            kernel.Bind<IEditoraServico>().To<EditoraServico>().InScope(RequestScope);
            kernel.Bind<ICategoriaServico>().To<CategoriaServico>().InScope(RequestScope);

            kernel.Bind(typeof(IRepositorioBase<>)).To(typeof(RepositorioBase<>)).InScope(RequestScope);
            kernel.Bind<ILivroRepositorio>().To<LivroRepositorio>().InScope(RequestScope);
            kernel.Bind<IEditoraRepositorio>().To<EditoraRepositorio>().InScope(RequestScope);
            kernel.Bind<ICategoriaRepositorio>().To<CategoriaRepositorio>().InScope(RequestScope);

            // Cross-wire required framework services
            kernel.BindToMethod(app.GetRequestService<IViewBufferScope>);

            return kernel;
        }

        private object Resolve(Type type) => Kernel.Get(type);
        private object RequestScope(IContext context) => _scopeProvider.Value;

        private sealed class Scope : DisposableObject { }
    }
}