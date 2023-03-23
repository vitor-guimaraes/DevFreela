using DevFreela.Application.ViewModels;
using DevFreela.Core.DTOs;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using MediatR.Pipeline;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetAllSkills
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillsDTO>>
    {
        private readonly ISkillRepository _skillRepository;
        public GetAllSkillsQueryHandler(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        private readonly DevFreelaDbContext _dbContext;
        //private readonly string _connectionString;

        public GetAllSkillsQueryHandler(DevFreelaDbContext dbContext)//, IConfiguration configuration)
        {
            _dbContext = dbContext;
            //_connectionString = configuration.GetConnectionString("DevFreelaCs"); //SÓ PRA UTILIZAR O DAPPER
        }
        public async Task<List<SkillsDTO>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            var skills = await _skillRepository.GetAllSkills();

            var skillsDTO = skills
                .Select(s => new SkillsDTO(s.Id, s.Description))
                .ToList();

            return skillsDTO;

                //var skills = _dbContext.Skills;

                //var skillsViewModel = await skills
                //    .Select(s => new SkillDTO(s.Id, s.Description))
                //    .ToListAsync();

                //return skillsViewModel;

            //    //GET ALL DAPPER
            //    public List<SkillViewModel> GetAll()
            //    {
            //        using (var sqlConnection = new SqlConnection(_connectionString))
            //        {
            //            sqlConnection.Open();

            //            var script = "SELECT Id, Description FROM Skills";

            //            var skills = await sqlConnection.Query<SkillViewModel>(script);

            //            return skills.ToList();
            //        }

            throw new NotImplementedException();
        }
    }

}
