using CitiesApi.Models;
using CitiesApi.Models.Repository;
using CitiesApi.Paging;

namespace CitiesApi.Repository
{
    public class CityRepository : RepositoryBase<City>,ICityRepository
    {
        public CityRepository(ApplicationDBContext applicationDBContext) : base(applicationDBContext)
        {

        }

        public void CreateCity(City city)
        {
            Create(city);
        }
        public void UpdateCity(City city)
        {
            Update(city);
        }

        public void DeleteCity(City city)
        {
           Delete(city);
        }

        public City GetCity(int id)
        {
            return FindbyCondition(x => x.Id == id).FirstOrDefault();
        }
        public Task<PagedList<City>> GetCities(PagingParameters pagingParameters)
        {
            return Task.FromResult(PagedList<City>.GetPagesList(FindAll().OrderBy(x=> x.Id ),pagingParameters.PageNumber,pagingParameters.PageSize));
        }



    }
}
