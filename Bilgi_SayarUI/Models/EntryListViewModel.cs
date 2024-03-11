using Entities.Concrete;

namespace Bilgi_SayarUI.Models
{
    public class EntryListViewModel
    {
        public List<Entry> Entries { get; set; }
        public Pagination pagination { get; set; } = new();
        public int TotalCount => Entries.Count();
    }
}
