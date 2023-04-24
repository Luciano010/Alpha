using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenDAL
{
    public class DrinksDao : BaseDao
    {
        public List<Drinks> GetAllDrinks()
        {
            string query = "SELECT * FROM [Drinks]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Drinks> ReadTables(DataTable dataTable)
        {
            List<Drinks> drinks = new List<Drinks>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Drinks drink = new Drinks()
                {
                    drinkId = (int)dr["drinkId"],
                    drinkName = dr["drinkName"].ToString(),
                    price = (int)dr["price"],
                    stock = (int)dr["stock"],
                    isAlcoholic = (bool)dr["isAlcoholic"]
                };
                drinks.Add(drink);
            }
            return drinks;
        }

        public void UpdateStock(Drinks drink)
        {
            string query = "UPDATE Drinks SET stock = @stock WHERE drinkName = @drinkName";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@stock", drink.stock);
            sqlParameters[1] = new SqlParameter("@drinkName", drink.drinkName);
            ExecuteEditQuery(query, sqlParameters);
        }
    }
}
