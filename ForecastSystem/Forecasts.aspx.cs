using ForecastSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ForecastSystem
{
	public partial class Contact : Page
	{
		private ForecastContext db = new ForecastContext();
		private int UID;
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				UID = int.Parse(Session["UID"] + "");

				//When you send data to the server to be processed
				//you initiate a post back
				//so in a button click or a form with a post method
				//this will reload the page
				//hence the if below
				//it ensures that the populate functions only load when the page is first requested
				//and not everytime a post is called
				//otherwise the controls such as the drop down will always defualt to the first value
				//despite what the user has selected

				if (!Page.IsPostBack)
				{
					//This is to bind the table (GridView)
					//LoadAndBindUserData();

					//This is to bind the drop down with users to select for update and delete
					//LoadAndBindUsersForUpdate();
					UpdateControls();

				}
			}
			catch(FormatException ex)
			{
				//Log errror
			}
			
			

		}

		//------------------------------------------
		//This is all to update controls and dispaly
		//------------------------------------------

		

		//Add new controls that would need to be updated with data change here
		private void UpdateControls()
		{
			LoadAndBindUserData();
			LoadAndBindUsersForDelete();
			LoadAndBindUsersForUpdate();
		}

		private void LoadAndBindUsersForUpdate()
		{
			//This is just to make sure that the drop down doesn't duplicate all of its data
			ddUserUpdate.Items.Clear();
			//Populate Drop down
			var userQuery = from u in db.users select u.UsrName;
			IList<string> users = userQuery.ToList();

			//This is a bit weird but a drop down needs a value specified for every
			//item in it's list, so I had to do this item adding for data binding
			//an alternative might be to make a map object and specifiy the difference
			//of value and text based on the maps value and text equvilant
			//this is more of a hotfix

			for (int i = 0; i < users.Count; i++)
			{
				ddUserUpdate.Items.Add(new ListItem(users[i], users[i]));
			}

			
		}

		private void LoadAndBindUsersForDelete()
		{
			//This is just to make sure that the drop down doesn't duplicate all of its data
			ddDelteUser.Items.Clear();
			//Populate Drop down
			var userQuery = from u in db.users select u.UsrName;
			IList<string> users = userQuery.ToList();

			//This is a bit weird but a drop down needs a value specified for every
			//item in it's list, so I had to do this item adding for data binding
			//an alternative might be to make a map object and specifiy the difference
			//of value and text based on the maps value and text equvilant
			//this is more of a hotfix

			for (int i = 0; i < users.Count; i++)
			{
				ddDelteUser.Items.Add(new ListItem(users[i], users[i]));
			}


		}


		//------------------------------------------
		//READ
		//------------------------------------------
		private void LoadAndBindUserData()
		{
			var userQuery = from u in db.users select u;
			//Login example
			//Session example
			userQuery = userQuery.Where(u => u.Id.Equals(UID));
			IList<User> users = userQuery.ToList();
			Forecasts.DataSource = users;
			Forecasts.DataBind();
		}


		//------------------------------------------
		//Search
		//------------------------------------------
		public void FilterUsers(object sender, EventArgs e)
		{
			var userQuery = from u in db.users select u;
			userQuery = userQuery.Where(u => u.UsrName.Contains(txtSearch.Text));
			IList<User> users = userQuery.ToList();
			Forecasts.DataSource = users;
			Forecasts.DataBind();
		}

		//------------------------------------------
		//ADD
		//------------------------------------------
		public void AddUser(object sender, EventArgs e)
		{
			try
			{
				db.users.Add(new Models.User { UsrName = txtNewUsername.Text, Password = txtNewPassword.Text });
				db.SaveChanges();
				UpdateControls();
			}
			catch(SqlException ex)
			{
				//Possibly use logging for Exception handling
			}
			

		}

		//------------------------------------------
		//UPDATE
		//------------------------------------------
		public void UpdateUser(object sender, EventArgs e)
		{
			try
			{
				//Make sure that drop down has a selected value
				//Drop down is always populated with data source so this shouldn't trigger
				var userQuery = from u in db.users select u;
				string selectedItem = ddUserUpdate.SelectedValue;
				var user = userQuery.Where(u => u.UsrName.Equals(ddUserUpdate.SelectedValue));
				IList<User> SelectedUser = user.ToList();


				//SelectedUser is a user object set to the target that you want to update
				//We change its details and then save it back to the database
				if (!String.Equals(txtUpdateUsername.Text, ""))
				{
					SelectedUser[0].UsrName = txtUpdateUsername.Text;
				}

				if (!String.Equals(txtUpdatePassword.Text, ""))
				{
					SelectedUser[0].Password = txtUpdatePassword.Text;
				}

				db.SaveChanges();

				//This can be called to refresh data on the page
				UpdateControls();
			}
			catch (SqlException ex)
			{
				//Possibly use logging for Exception handling
			}
			
		}

		//------------------------------------------
		//DELETE
		//------------------------------------------
		public void DeleteUser(object sender, EventArgs e)
		{
			var userQuery = from u in db.users select u;
			string selectedItem = ddDelteUser.SelectedValue;
			var user = userQuery.Where(u => u.UsrName.Equals(ddDelteUser.SelectedValue));
			IList<User> SelectedUser = user.ToList();

			//Perform Delete Query
			db.users.Remove(SelectedUser[0]);
			db.SaveChanges();
			UpdateControls();

		}

	}
}