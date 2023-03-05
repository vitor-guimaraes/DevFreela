using DevFreela.Core.Enums;
using System;

namespace DevFreela.Application.ViewModels
{
    public class ProjectDetailsViewModel
    {
        public ProjectDetailsViewModel(int id, string title, 
                                        string description, decimal totalCost, 
                                        DateTime? startedAt, DateTime? finishedAt, 
                                        ProjectStatusEnum status,string clientFullname, 
                                        string freelancerFullname)
        {
            Id = id;
            Title = title;
            Description = description;
            TotalCost = totalCost;
            Status = status;
            StartedAt = startedAt;
            FinishedAt = finishedAt;
            ClientFullname = clientFullname;
            FreelancerFullname = freelancerFullname;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal TotalCost { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
        public ProjectStatusEnum Status { get; private set; }
        public string ClientFullname { get; private set; }
        public string FreelancerFullname { get; private set; }
    }
}
