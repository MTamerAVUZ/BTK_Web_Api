namespace Entities.Exceptions
{
	public sealed class BookNotFoundException : NotFoundException //sealed ile hiçbir şekilde bu class başka bir class a kalıtılamaz
	{
		public BookNotFoundException(int id) : base($"The book with id:{id} could not found.")
		{

		}
	}
}
