using HexMaster.Parcheesi.Common.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HexMaster.Parcheesi.NetworkService.Repositories
{
    public class MongoDataContext : MongoClient
    {

        public MongoDataContext(IOptions<MongoDbSettings> settings)
        : base (settings.Value.ConnectionString)
        {

        }

    }
}
