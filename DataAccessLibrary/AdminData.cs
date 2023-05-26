using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLibrary.Model;



namespace DataAccessLibrary
{
    public class AdminData : IAdminData
    {
        private readonly ISQLDataAccess _db;

        public AdminData(ISQLDataAccess db)
        {
            _db = db;
        }
        public List<AdminModel> LoadData()
        {
            string sqlQuery = "SELECT * from admin";
            return _db.Load<AdminModel, dynamic>(sqlQuery, new { });
        }


        public Task insert(AdminModel model)
        {
            string query = "INSERT INTO admin(user_name, name, email, phone_no, password, address, gender) VALUES(@User_name, @Name, @Email, @Phone_no, @Password, @Address, @Gender)";
            return _db.Save(query, model);
        }

        public Task Edit(AdminModel model)
        {
            string query = "UPDATE admin SET name=@Name, email=@Email, phone_no=@Phone_no WHERE user_id=@User_id";
            return _db.Save(query, model);
        }

        public Task Delete(AdminModel model)
        {
            string query = "DELETE admin WHERE user_id=@User_id";
            return _db.Save(query, model);
        }

    }

    public interface IAdminData
    {
        List<AdminModel> LoadData();
        Task insert(AdminModel model);
        Task Edit(AdminModel model);
        Task Delete(AdminModel model);
    }
}
