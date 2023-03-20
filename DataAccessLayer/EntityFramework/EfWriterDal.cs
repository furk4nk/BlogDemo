using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfWriterDal : GenericRepository<Writer>, IWriterDal
    {
        //private readonly Context _context;
        public EfWriterDal(Context c) : base(c)
        {
            //this._context=c;
        }

        ///// <summary>
        ///// Gelen Writer İçin Password Proporties ini hash algoritması uygulayan function
        ///// </summary>
        ///// <param name="writer">Entity</param>
        //public override bool Insert(Writer writer)
        //{
        //    int ctrl = 0;
        //    if (writer !=null)
        //    {
        //        writer.WriterPassword = BCrypt.Net.BCrypt.HashPassword(writer.WriterPassword);
        //        _context.Add(writer);
        //        _context.SaveChanges();
        //    }
        //    return CtrlValue(ctrl);
        //}

        public bool IsWriterControl(string mail)
        {
            return _context.writers.Select(x => x.WriterMail).Contains(mail);
        }

        ///// <summary>
        ///// Gelen Yazar için Password properties i Hash Algoritmasına girerek İşlem yapılır
        ///// </summary>
        ///// <param name="writer">Entity</param>
        //public override bool Update(Writer writer)
        //{
        //    int ctrl=0;
        //    if (writer!=null)
        //    {
        //        writer.WriterPassword = BCrypt.Net.BCrypt.HashPassword(writer.WriterPassword);
        //        _context.Add(writer);
        //        ctrl =_context.SaveChanges();                
        //    }
        //    return CtrlValue(ctrl);
        //}
    }
}
