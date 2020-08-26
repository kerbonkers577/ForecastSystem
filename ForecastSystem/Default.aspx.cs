using ForecastSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ForecastSystem
{
	public partial class _Default : Page
	{
		private ForecastContext db = new ForecastContext();
		
		protected void Page_Load(object sender, EventArgs e)
		{
			//Preload user sign on data
			GetAllUsers();

			var forecastQuery = from f in db.forecasts select f;
			IList<Forecast> forecasts = forecastQuery.ToList();
		}

		

		private void GetAllUsers()
		{
			try
			{
				//Using the context of our Database
				//We are then able to query it
				//and it fetches all the data we need
				

				//Formation of a query
				//Pass through form data to search for this value
				//Look to match passwords and usernames
				var userQuery = from u in db.users select u;
				//x is just the user model
				userQuery = userQuery.Where(x => x.Id == 4);
				IList<User> users = userQuery.ToList();

			}
			catch(SqlException e)
			{ }
		}

		protected void btnLogin_Click(object sender, EventArgs e)
		{
			//Login confirm
			//Get control info after user clicks login
			string username = txtUsername.Text;
			string password = txtPassword.Text;


			var userQuery = from u in db.users select u;

			//This is not the way to go about logins but this will do as a simple evaluation
			userQuery = userQuery.Where(x => x.UsrName.Equals(username) && x.Password.Equals(password));
			IList<User> users = userQuery.ToList();

			//If the credentials are found, redirect them
			if(users.Count == 1)
			{
				Session["UID"] = users[0].Id;
				Server.Transfer("Forecasts.aspx");
			}
		}
	}
}