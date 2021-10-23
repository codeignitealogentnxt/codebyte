using CommonModel;
using DataRepository;
using ProjectDB.DBModel;
using System.Collections.Generic;
using System.Linq;

namespace ServiceProject
{
    public class CountryService : ICountryService
    {
        private ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public IEnumerable<CountryModel> GetCountries()
        {
            return _countryRepository.GetAll().Select(MapToModel);
        }

        private CountryModel MapToModel(Country enity)
        {
            return new CountryModel
            {
                ID = enity.ID,
                Name = enity.Name
            };
        }
    }
}