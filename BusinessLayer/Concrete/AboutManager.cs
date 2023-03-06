using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _AboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _AboutDal = aboutDal;
        }

        public void TDelete(About t)
        {
            _AboutDal.Delete(t);
        }

        public About TGetById(int ID)
        {
            return _AboutDal.GetById(ID);
        }

        public int TGetCount(Expression<Func<About, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<About> TGetList()
        {
            return _AboutDal.GetList();
        }

		public List<About> TGetList(Expression<Func<About, bool>> filter)
		{
			return _AboutDal.GetList(filter);
		}

		public void TInsert(About t)
        {
            _AboutDal.Insert(t);
        }

        public void TUpdate(About t)
        {
            _AboutDal.Update(t);
        }
    }
}
