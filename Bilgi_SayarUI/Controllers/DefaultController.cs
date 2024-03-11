using Bilgi_SayarUI.Models;
using BusinessLogic.Abstract;
using Entities.Concrete;
using Entities.Dtos.EntryDto;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;

namespace Bilgi_SayarUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IEntryService _entryService;
        private readonly IWriterService _writerService;
        public DefaultController(IEntryService entryService, IWriterService writerService)
        {
            _entryService = entryService;
            _writerService = writerService;
        }

        public IActionResult Index(EntryRequestParameters e)
        {
            var data = _entryService.GetActiveEntries(e);
            var paginations = new Pagination() { 
                CurrentPage = e.PageNumber, 
                ItemsPerPage = e.PageSize, 
                TotalItems = _entryService.GetActiveEntriesCount() };
            return View(new EntryListViewModel() { Entries = data, pagination = paginations });
        }


        public IActionResult GetByCategory(EntryRequestParameters e,int? categoryId, string? search)
        {


            var data = _entryService.GetByCategory( e,categoryId, search);
            var paginations = new Pagination()
            {
                CurrentPage = e.PageNumber,
                ItemsPerPage = e.PageSize,
                TotalItems = data.Count()
            };
            return View(new EntryListViewModel() { Entries = data, pagination = paginations });

        }
        public IActionResult GetDetail(int id)
        {
            var data = _entryService.Get(id);
            var entrydata = new EntryDto()
            {
                Entry = data,
                Writer = _writerService.Get(data.WriterId.Value)


            };
             
            


            return View(entrydata);

        }
    }
}
