using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
	public class BookManager : IBookService
	{
		private readonly IRepositoryManager _manager;
		private readonly IMapper _mapper;
		private readonly ILoggerService _logger;

		public BookManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
		{
			_manager = manager;
			_logger = logger;
			_mapper = mapper;
		}

		public Book CreateOneBook(Book book)
		{


			_manager.Book.CreateOneBook(book);
			_manager.Save();
			return book;
		}

		public void DeleteOneBook(int id, bool trackChanges)
		{
			//check entitiy
			var entitiy = _manager.Book.GetOneBookById(id, trackChanges);
			if (entitiy is null)
				throw new BookNotFoundException(id);	

			_manager.Book.DeleteOneBook(entitiy);
			_manager.Save();

		}

		public IEnumerable<Book> GetAllBooks(bool trackChanges)
		{
			return _manager.Book.GetAllBooks(trackChanges);
		}

		public Book GetOneBookById(int id, bool trackChanges)
		{
			var book= _manager.Book.GetOneBookById(id, trackChanges);
			if (book is null)
				throw new BookNotFoundException(id);

			return book;
		}

		public void UpdateOneBook(int id,
			BookDtoForUpdate bookDto, 
			bool trackChanges)
		{
			//check entitiy
			var entity = _manager.Book.GetOneBookById(id, trackChanges);
			if (entity is null)
				throw new BookNotFoundException(id);

			//check params
			if (bookDto is null)
				throw new ArgumentNullException(nameof(bookDto));
			//mapping
			//entity.Title = book.Title;
			//entity.Price = book.Price;
			entity = _mapper.Map<Book>(bookDto);//mapper ile mapleme



			_manager.Book.Update(entity);
			_manager.Save();

		}
	}
}
