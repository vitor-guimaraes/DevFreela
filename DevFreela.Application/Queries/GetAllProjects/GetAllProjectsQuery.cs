using DevFreela.Application.ViewModels;
using DevFreela.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectsQuery : IRequest<List<ProjectViewModel>>
    {
        public GetAllProjectsQuery(string query)
        {
            Query = query;
        }
        public string Query { get; private set; }

        //public GetAllProjectsQuery(int id, string title, DateTime createdAt, ProjectStatusEnum status)
        //{
        //    Id = id;
        //    Title = title;
        //    CreatedAt = createdAt;
        //    Status = status;
        //}

        //public int Id { get; private set; }
        //public string Title { get; private set; }
        //public DateTime CreatedAt { get; private set; }
        //public ProjectStatusEnum Status { get; private set; }

    }
}
