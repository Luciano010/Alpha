using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenService
{
    public class DrinksService
    {
        private DrinksDao drinksdb;

        public DrinksService()
        {
            drinksdb = new DrinksDao();
        }

        public List<Drinks> GetDrinks()
        {
            List<Drinks> drinks = drinksdb.GetAllDrinks();
            return drinks;
        }

        public void UpdateStock(Drinks drink)
        {
            drinksdb.UpdateStock(drink);
        }
    }
}
