using BusinessLayer.Abstract;
using BusinessLayer.Abstract.UnitOfWork;
using BusinessLayer.ActionFilters;
using BusinessLayer.Concrete;
using BusinessLayer.Concrete.UnitOfWork;
using BusinessLayer.FluentValidation;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repositories;
using DataAccessLayer.UnitOfWork;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer.Container
{
	public static class Extensions
	{
		public static void ContainerDependendies(this IServiceCollection services)
		{
            #region Repositories
            services.AddTransient(typeof(IGenericDal<>), typeof(GenericRepository<>));
			services.AddTransient(typeof(IAsyncGenericDal<>), typeof(AsyncGenericRepository<>));

            services.AddScoped<IBlogService, BlogManager>();
			services.AddScoped<IBlogDal, EfBlogDal>();

			services.AddScoped<ICommentService,CommentManager>();
			services.AddScoped<ICommentDal,EfCommentDal>();

			services.AddScoped<ICategoryService,CategoryManager>();
			services.AddScoped<ICategoryDal,EfCategoryDal>();

			services.AddScoped<IWriterService, WriterManager>();
			services.AddScoped<IWriterDal, EfWriterDal>();

			services.AddScoped<IValidator<Writer>, WriterValitator>();

			services.AddScoped<INewsLetterService, NewsLetterManager>();
			services.AddScoped<INewsLetterDal, EfNewsLetterDal>();

			services.AddScoped<IAboutService,AboutManager>();
			services.AddScoped<IAboutDal,EfAboutDal>();

			services.AddScoped<IContactService, ContactManager>();
			services.AddScoped<IContactDal, EfContactDal>();		

			services.AddScoped<INotificationService, NotificationManager>();
			services.AddScoped<INotificationDal,EfNotificationDal>();

			services.AddScoped<IMessageService, MessageManager>();
			services.AddScoped<IMessageDal,EfMessageDal>();

			services.AddScoped<IMessage2Service,Message2Manager>();
			services.AddScoped<IMessage2Dal,EfMessage2Dal>();

            services.AddTransient<IUnitOfWorkDal,UnitOfWorkDal>();
            services.AddTransient<IUnitOfWorkService,UnitOfWorkManager>();
            #endregion

            #region Filter attiribute
            services.AddControllers(config =>
            {
                config.Filters.Add(new CustomActionFilterAttribute());
            });
			services.AddScoped<CustomActionFilterAttribute>();
            #endregion
        }
    }
}
