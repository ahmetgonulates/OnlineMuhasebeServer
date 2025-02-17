using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Persistance.Contexts;

namespace OnlineMuhasebeServer.Persistance.Services.AppServices;

public class CompanyService : ICompanyService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CompanyService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task CreateCompany(CreateCompanyCommand request)
    {
        Company company = _mapper.Map<Company>(request);
        company.Id = Guid.CreateVersion7().ToString();
        await _context.Set<Company>().AddAsync(company);
        await _context.SaveChangesAsync();
    }

    public async Task<Company?> GetCompanyByName(string name)
    {
        return await _context.Set<Company>().FirstOrDefaultAsync(x => x.Name.Equals(name));
    }

    public async Task MigrateCompanyDatabases()
    {
        var companies = await _context.Set<Company>().ToListAsync();
        foreach(var company in companies)
        {
            var db = new CompanyDbContext(company);
            db.Database.Migrate();
        }
    }
}