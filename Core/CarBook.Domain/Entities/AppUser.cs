using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
	public class AppUser : IdentityUser<Guid>
	{
		public string? Name { get; set; }
		public string? Surname { get; set; }
	}
}
