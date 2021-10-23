using CommonModel;
using System.Collections.Generic;

namespace ServiceProject
{
    public interface ICountryService
    {
        IEnumerable<CountryModel> GetCountries();
    }
}