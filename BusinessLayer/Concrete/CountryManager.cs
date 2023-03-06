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
	public class CountryManager : ICountryService
	{
		ICountryDal _countryDal;
		public CountryManager(ICountryDal countryDal)
		{
			_countryDal = countryDal;
		}

		public void TDelete(Country t)
		{
			throw new NotImplementedException();
		}

		public Country TGetById(int ID)
		{
			throw new NotImplementedException();
		}

        public int TGetCount(Expression<Func<Country, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Country> TGetList()
		{
			return _countryDal.GetList();
		}

		public List<Country> TGetList(Expression<Func<Country, bool>> filter)
		{
			return _countryDal.GetList(filter);
		}

		public void TInsert(Country t)
		{
			throw new NotImplementedException();
		}

		public void TUpdate(Country t)
		{
			throw new NotImplementedException();
		}
	}
}
