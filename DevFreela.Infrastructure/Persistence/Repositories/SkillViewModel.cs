namespace DevFreela.Infrastructure.Persistence.Repositories
{
    internal class SkillViewModel
    {
        private int id;
        private string description;

        public SkillViewModel(int id, string description)
        {
            this.id = id;
            this.description = description;
        }
    }
}