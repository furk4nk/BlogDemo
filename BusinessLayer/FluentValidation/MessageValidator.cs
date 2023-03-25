using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using FluentValidation;
using System.Linq;

namespace BusinessLayer.FluentValidation
{
    public class MessageValidator : AbstractValidator<Message2>
    {
        public MessageValidator(IWriterService writerManager)   
        {
            // Rules ReceiverUser.WriterName
            RuleFor(x => x.ReceiverUser.WriterMail).Custom((mail, context) =>
            {
                    var result = writerManager.TGetList(x => x.WriterMail==mail).FirstOrDefault();
                    if (result == null)
                    {
                        context.AddFailure("ReceiverUser.WriterMail", "Yazar Epostası sistemde kayıtlı değil Lütfen sisteme Kayıtlı olan yazar epostasını giriniz");
                    }                
            });

            // Rules Subject 
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Başlığı Giriniz")
                .MinimumLength(5).WithMessage("En Az 5 Karakter Giriniz")
                .MaximumLength(80).WithMessage("En Fazla 80 Karakter Giriniz");



            // Rules Context
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj İçeriği Boş Geçilemez")
                .MinimumLength(10).WithMessage("En Az 10 Karakter Girişi Yapınız")
                .MaximumLength(5000).WithMessage("En Fazla 5000 Karakter Girişi Yapılır");
        }
    }
}
