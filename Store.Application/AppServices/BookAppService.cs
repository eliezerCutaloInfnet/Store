using AutoMapper;
using Store.Application._shared;
using Store.Application.Dtos.Book.Requests;
using Store.Application.Dtos.Book.Responses;
using Store.Application.Interfaces;
using Store.Domain.Entities;
using Store.Domain.Interface;

namespace Store.Application.AppServices
{
    public class BookAppService : AppService, IBookAppService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public BookAppService(INotifier notifier,
            IMapper mapper,
            IBookRepository repository) : base(notifier)
        {
            _bookRepository = repository;
            _mapper = mapper;
        }

        public async Task<IAppServiceResponse> Create(CreateBookRequestDto request)
        {
            var newBook = new Book(request.Title, request.Genre, request.Summary, request.Isbn);

            if (newBook.IsValid())
            {
                await _bookRepository.AddAsync(newBook);
                return new AppServiceResponse<string>(newBook.Id.ToString(), "Book Created Successfully", true);
            }
            else
            {
                Notify(newBook.ValidationResult);
                return new AppServiceResponse<ICollection<Notification>>(GetAllNotifications(), "Error Creating book", false);
            }
        }

        public async Task<IAppServiceResponse> Delete(string isbn)
        {
            var book = await _bookRepository.GetByIsbnAsync(isbn);

            if (book == null)
            {
                Notify("ISBN", "Book not found");
                return new AppServiceResponse<ICollection<Notification>>(GetAllNotifications(), "Error Deleting book", false);
            }
            else
            {
                await _bookRepository.DeleteAsync(book);
                return new AppServiceResponse<string>(book.Id.ToString(), "Book has deleted", true);
            }

        }

        public async Task<IAppServiceResponse> GetAllAsync()
        {
            var books = await _bookRepository.GetAllAsync();

            var booksDto = books != null ? _mapper.Map<IEnumerable<BookResponseDto>>(books) : Enumerable.Empty<BookResponseDto>();

            return new AppServiceResponse<IEnumerable<BookResponseDto>>(booksDto, "book contents", true);
        }

        public async Task<IAppServiceResponse> GetByIsbnAsync(string isbn)
        {
            var book = await _bookRepository.GetByIsbnAsync(isbn);

            if (book == null)
            {
                Notify("ISBN", "Book not found");
                return new AppServiceResponse<ICollection<Notification>>(GetAllNotifications(), "Error Deleting book", false);
            }
            else
            {
                return new AppServiceResponse<BookResponseDto>(_mapper.Map<BookResponseDto>(book), "book", true);
            }
        }

        public async Task<IAppServiceResponse> Update(UpdateBookRequestDto request, string isbn)
        {
            var book = await _bookRepository.GetByIsbnAsync(isbn);

            if (book == null)
            {
                Notify("Id", "book not found");
                return new AppServiceResponse<ICollection<Notification>>(GetAllNotifications(), "Error Updating book", false);
            }

            book.Update(request.Title, request.Genre, request.Summary);

            if (book.IsValid())
            {
                await _bookRepository.Update(book);
                return new AppServiceResponse<string>(book.Id.ToString(), "book Updated Successfully", true);
            }
            else
            {
                return new AppServiceResponse<ICollection<Notification>>(GetAllNotifications(), "Error Updating book", false);
            }
        }
    }
}
