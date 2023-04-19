using DevFreela.Core.DTOs;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DevFreelaDbContext _dbContext;
        //private readonly string _connectionString;

        public SkillRepository(DevFreelaDbContext dbContext)//, IConfiguration configuration)
        {
            _dbContext = dbContext;
            //_connectionString = configuration.GetConnectionString("DevFreelaCs"); //SÓ PRA UTILIZAR O DAPPER
        }
        public async Task<List<SkillDTO>> GetAllSkills()
        {
            var skills = _dbContext.Skills;

            var skillsViewModel = skills
                .Select(s => new SkillDTO(s.Id, s.Description))
                .ToList();

            _dbContext.SaveChanges();

            return skillsViewModel;
        }
    }
}
