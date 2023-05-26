using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Model
{
    public class TransactionModel
    {
        public string? Trans_id { get; set; }
        public string? User_name { get; set; }
        public string? Transfer_at { get; set; }
        public string? Debit_amt { get; set; }
        public string? Credit_amt { get; set; }
        public string? Trans_type { get; set; }
        public string? Type_id { get; set; }
    }
}
