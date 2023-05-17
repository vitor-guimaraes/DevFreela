namespace DevFreela.Application.ViewModels
{
    public class UsersViewModel
    {
        public UsersViewModel(string fullname, int id, bool active)
        {
            Fullname = fullname;
            Id = id;
            Active = active;
        }

        public string Fullname { get; private set; }
        public int Id { get; private set; }
        public bool Active { get; private set; }
    }
}
