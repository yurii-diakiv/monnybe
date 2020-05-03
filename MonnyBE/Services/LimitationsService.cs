using DataAccess.Repositories;
using DataAccess.Entities;
using AutoMapper;
using MonnyBE.DTOs;

namespace MonnyBE.Services
{
    public class LimitationsService
    {
        private readonly LimitationRepository repository;
        private readonly IMapper _mapper;

        public LimitationsService(LimitationRepository limitationRepository, IMapper mapper)
        {
            repository = limitationRepository;
            _mapper = mapper;
        }
        public LimitationDTO GetLimitationByUserId(int id)
        {
            Limitation limitation = repository.GetItemByUserId(id);
            LimitationDTO limitationDTO = _mapper.Map<LimitationDTO>(limitation);
            return limitationDTO;
        }
        public void Update(LimitationDTO item)
        {
            Limitation limitation = _mapper.Map<Limitation>(item);
            repository.Update(limitation);
        }
    }
}
