using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ForecastSystem.Models
{
	[Table("Forecast")]
	public class Forecast
	{
		[Key]
		public int Fore_Id { get; set; }
		public string City { get; set; }
		public string Temperature { get; set; }
	}
}