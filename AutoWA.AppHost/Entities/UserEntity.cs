using System.ComponentModel.DataAnnotations.Schema;

namespace AutoWA.AppHost.Entities;

[Table("User")]
public class UserEntity
{
	public string Id { get; set; }
	public string Name { get; set; }
	public string ApiToken { get; set; }
}