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
	public class CityManager : ICityService
	{
		ICityDal _cityDal;

		public CityManager(ICityDal cityDal)
		{
			_cityDal = cityDal;
		}

		public void TDelete(City t)
		{
			throw new NotImplementedException();
		}

		public City TGetById(int ID)
		{
			throw new NotImplementedException();
		}

        public int TGetCount(Expression<Func<City, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<City> TGetList()
		{
			return _cityDal.GetList();
		}

		public List<City> TGetList(Expression<Func<City, bool>> filter)
		{
			return _cityDal.GetList(filter);
		}

		public void TInsert(City t)
		{
			throw new NotImplementedException();
		}

		public void TUpdate(City t)
		{
			throw new NotImplementedException();
		}
	}
}
