using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;

namespace ForecastSystem.Models
{
	//Inherit from context
	//Context manages fetching, storing and updating class instances in the database
	public class ForecastContext : DbContext
	{

		private const string ConnString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Tristan\\source\\repos\\ForecastSystem\\ForecastSystem\\App_Data\\WeatherForecastApp.mdf;Integrated Security=True";

		public ForecastContext() : base(ConnString)
		{

		}

		public DbSet<User> users { get; set; }
		public DbSet<Forecast> forecasts { get; set; }
	}
}