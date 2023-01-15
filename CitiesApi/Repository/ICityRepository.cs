using CitiesApi.Models;
using CitiesApi.Models.Repository;
using CitiesApi.Paging;

namespace CitiesApi.Repository
{
    public interface ICityRepository : IRepositoryBase<City>
    {
        Task<PagedList<City>> GetCities(PagingParameters pagingParameters);
        City GetCity(int id);

        void CreateCity(City city);
        void UpdateCity(City city);
        void DeleteCity(City city);

    }
}
