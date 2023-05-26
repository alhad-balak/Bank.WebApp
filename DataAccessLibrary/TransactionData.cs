using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLibrary.Model;


namespace DataAccessLibrary
{
    public class TransactionData : ITransactionData
    {
        private readonly ISQLDataAccess _db;

        public TransactionData(ISQLDataAccess db)
        {
            _db = db;
        }
        public List<TransactionModel> LoadTransactionDetails()
        {
            string sqlQuery = "SELECT * from trans_details";
            return _db.Load<TransactionModel, dynamic>(sqlQuery, new { });
        }

        public List<BalanceModel> LoadBalance()
        {
            string sqlQuery = "SELECT user_name, SUM(CAST(credit_amt as INT))-SUM(CAST(debit_amt as INT)) AS Balance  FROM trans_details GROUP BY user_name;";
            return _db.Load<BalanceModel, dynamic>(sqlQuery, new { });
        }

        public List<BalanceModel> LoadTotalDebit()
        {
            string sqlQuery = "SELECT user_name, SUM(CAST(debit_amt as INT)) AS Balance  FROM trans_details GROUP BY user_name;";
            return _db.Load<BalanceModel, dynamic>(sqlQuery, new { });
        }

        public List<BalanceModel> LoadTotalCredit()
        {
            string sqlQuery = "SELECT user_name, SUM(CAST(credit_amt as INT)) AS Balance  FROM trans_details GROUP BY user_name;";
            return _db.Load<BalanceModel, dynamic>(sqlQuery, new { });
        }

        public Task Deposit(TransactionModel model)
        {
            string query = "INSERT INTO trans_details(user_name, credit_amt, trans_type, type_id) VALUES(@User_name, @Credit_amt, @Trans_type,@Type_id)";
            return _db.Save(query, model);
        }

        public Task Withdrawal(TransactionModel model)
        {
            string query = "INSERT INTO trans_details(user_name, debit_amt, trans_type, type_id) VALUES(@User_name, @Debit_amt, @Trans_type,@Type_id)";
            return _db.Save(query, model);
        }


    }

    public interface ITransactionData
    {
        List<TransactionModel> LoadTransactionDetails();
        Task Deposit(TransactionModel model);
        Task Withdrawal(TransactionModel model);
        List<BalanceModel> LoadBalance();
        List<BalanceModel> LoadTotalDebit();
        List<BalanceModel> LoadTotalCredit();

    }
}
