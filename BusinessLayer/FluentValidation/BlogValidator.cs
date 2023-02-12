using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
	public class BlogValidator : AbstractValidator<Blog>
	{
		public BlogValidator()
		{
			//Blog Başlığı Kuralları
			RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog Başlığını Boş Geçmeyiniz")
				.MinimumLength(5).WithMessage("En Az 5 Karakter Olacak Şekilde Blog Başlığı Giriniz")
				.MaximumLength(50).WithMessage("En Fazla 50 Karakter Olacak Şekilde Blog Başlığı Giriniz");



			//Blog Categori Kuralları
			RuleFor(x => x.CategoryID).NotEmpty().WithMessage("Kategori Seçmelisiniz");



			//Blog İçeriği Kuralları
			RuleFor(x => x.BlogContext).NotEmpty().WithMessage("Blog İçeriği Boş Geçilemez")
				.MinimumLength(30).WithMessage("Blog İçeriği En Az 50 Karakter Olmalıdır")
				.MaximumLength(5000).WithMessage("Blog İçeriği En Fazla 5000 Karakter Olmalıdır");
				
			
		}
	}
}
