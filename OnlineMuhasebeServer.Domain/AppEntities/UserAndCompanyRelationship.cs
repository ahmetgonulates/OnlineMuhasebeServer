using System.ComponentModel.DataAnnotations.Schema;
using OnlineMuhasebeServer.Domain.Abstractions;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;

namespace OnlineMuhasebeServer.Domain.AppEntities;

public class UserAndCompanyRelationship : Entity
{
    [ForeignKey("AppUser")]
    public string AppUserId { get; set; }
    public AppUser AppUser { get; set; }
    [ForeignKey("Company")]
    public string CompanyId { get; set; }
    public Company Company { get; set; }
}