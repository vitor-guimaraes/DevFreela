using DevFreela.Application.ViewModels;
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
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillViewModel>>
    {
        private readonly DevFreelaDbContext _dbContext;
        //private readonly string _connectionString;

        public GetAllSkillsQueryHandler(DevFreelaDbContext dbContext)//, IConfiguration configuration)
        {
            _dbContext = dbContext;
            //_connectionString = configuration.GetConnectionString("DevFreelaCs"); //SÓ PRA UTILIZAR O DAPPER
        }
        public async Task<List<SkillViewModel>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
                var skills = _dbContext.Skills;

                var skillsViewModel = await skills
                    .Select(s => new SkillViewModel(s.Id, s.Description))
                    .ToListAsync();

                _dbContext.SaveChanges();

                return skillsViewModel;

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
