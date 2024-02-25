using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{

	//Data Transfer Object
	//Readonly
	//Değişmez- Immutable
	//LİNQ
	//Ref Type
	//Ctor(DTO)
	public record BookDtoForUpdate(int Id, String Title, decimal Price);
	//{
	//       public int Id { get; init; } //set yerine init olmalı ki readonly olsun !!!!! 
	//       public String Title { get; init; }
	//       public decimal Price { get; init; }

	//   }
}
