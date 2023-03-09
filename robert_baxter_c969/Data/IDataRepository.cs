using System.Collections.Generic;
using System.Threading.Tasks;

namespace robert_baxter_c969.Data
{
    public interface IDataRepository
    {
        Task<TDataEntity> Insert<TDataEntity>(TDataEntity entity) where TDataEntity : DataEntity, new();
        Task<TDataEntity> Update<TDataEntity>(TDataEntity entity) where TDataEntity : DataEntity, new();
        Task<IEnumerable<TDataEntity>> Get<TDataEntity>(IDictionary<string, string> searchCriteria = null) 
            where TDataEntity : DataEntity, new();
        Task<TDataEntity> GetById<TDataEntity>(int id) where TDataEntity : DataEntity, new();
        Task Delete<TDataEntity>(TDataEntity entity) where TDataEntity : DataEntity, new();
    }
}
