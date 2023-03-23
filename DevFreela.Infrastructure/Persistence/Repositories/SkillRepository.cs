﻿using DevFreela.Core.DTOs;
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
        public SkillRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SkillsDTO>> GetAllSkills()
        {
            //var skills = await _dbContext.Skills;

            //    var skillsViewModel = await skills
            //        .Select(s => new SkillViewModel(s.Id, s.Description))
            //        .ToListAsync();

            //    return skillsViewModel;
            return await _dbContext.SkillsDTO.ToListAsync();

            throw new NotImplementedException();
        }
    }
}
