using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            // Rules CategoryName
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori İsmi Boş Olamaz")
                .MinimumLength(5).WithMessage("Kategori İsmi En Az 5 Karakter Olmalıdır")
                .MaximumLength(50).WithMessage("Kategori İsmi En Fazla 50 Karakter Olmalıdır");


            // Rules CategoryDescription
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklama Alanı Boş Olmamalı")
                .MinimumLength(8).WithMessage("Açıklama En Az 8 Karakter Olmalıdır")
                .MaximumLength(200).WithMessage("Açıklama En Fazla 200 Karakter Olmalıdır");
        }
    }
}
