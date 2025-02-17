using AutoMapper;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using OnlineMuhasebeServer.Domain;
using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Domain.Repositories.UCAFRepositories;
using OnlineMuhasebeServer.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Persistance.Services.CompanyServices
{
    public sealed class UCAFService : IUCAFService
    {
        private readonly IUCAFCommandRepository _ucafCommandRepository;
        private readonly IContextService _contextService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private CompanyDbContext _context;

        public UCAFService(IUCAFCommandRepository ucafCommandRepository, IContextService contextService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _ucafCommandRepository = ucafCommandRepository;
            _contextService = contextService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateUcafAsync(CreateUCAFCommand request)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
            _ucafCommandRepository.SetDbContextInstance(_context);
            _unitOfWork.SetDbContextInstance(_context);
            UniformChartOfAccount uniformChartOfAccount = _mapper.Map<UniformChartOfAccount>(request);
            uniformChartOfAccount.Id = Guid.CreateVersion7().ToString();
            await _ucafCommandRepository.AddAsync(uniformChartOfAccount);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
