namespace DevFreela.Application.ViewModels
{
    public class UsersViewModel
    {
        public UsersViewModel(string fullName, int id, bool active)
        {
            FullName = fullName;
            Id = id;
            Active = active;
        }

        public string FullName { get; private set; }
        public int Id { get; private set; }
        public bool Active { get; private set; }
    }
}
