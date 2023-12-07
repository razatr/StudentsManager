namespace StudentsManager.ViewModels
{
    public class DropdownViewModel
    {
        public IEnumerable<GroupElementViewModel> Groups { get; set; } = Enumerable.Empty<GroupElementViewModel>();

        public int GroupId { get; set; } = 0;
    
        public DropdownViewModel(IEnumerable<GroupElementViewModel> groups)
        {
            Groups = groups;
        }
    }
}
