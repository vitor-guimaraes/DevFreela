namespace DevFreela.Application.ViewModels
{
    public class UsersViewModel
    {
        public UsersViewModel(string fullName, int id)
        {
            FullName = fullName;
            Id = id;
        }

        public string FullName { get; private set; }
        public int Id { get; private set; }
    }
}
