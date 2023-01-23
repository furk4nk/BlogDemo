using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Container
{
	public static class Extensions
	{
		public static void ContainerDependendies(this IServiceCollection services)
		{
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
		}
	}
}
