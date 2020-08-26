using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ForecastSystem.Models
{
	[Table("Users")]
	public class User
	{
		[Key]
		public int Id { get; set; }
		public string UsrName { get; set; }
		public string Password { get; set; }
	}
}