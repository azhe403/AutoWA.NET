using MongoFramework;

namespace AutoWA.AppHost.DbContexts;

public class UserDbContext : MongoDbContext
{
	public UserDbContext(IMongoDbConnection connection) : base(connection)
	{
	}

	public MongoDbSet<UserEntity> Users { get; set; }
}