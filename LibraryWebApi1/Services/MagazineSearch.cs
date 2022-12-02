using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LibraryWebApi1.Data.Interfaces;
using LibraryWebApi1.Models.DTO;
using LibraryWebApi1.Services.Interfaces;

namespace LibraryWebApi1.Services
{
    public class MagazineSearch:ISearchByName<MagazineDto,IMagazineRepository>
    {
        
        private readonly IMapper _mapper;

        public MagazineSearch(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<List<MagazineDto>> SearchByName(string searchName, IMagazineRepository repository)
        {
            var magazines =await repository.GetAllMagazine();
            var foundMagazines = magazines
                .Where(s => s.Name.ToLower().Contains(searchName.ToLower()));
            return foundMagazines.Select(magazine => _mapper.Map<MagazineDto>(magazine)).ToList();
        }
        
        }
    }
