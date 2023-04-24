using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP10_employeesApp.Models;

namespace WP10_employeesApp.ViewModels
{
    public class MainViewModel : Screen
    {
        private Employees employee;

        public BindableCollection<Employees> ListEmployee { get; set; }    

        public int Idx
        {
            get => employee.idx;
            set
            {
                employee.idx = value;
                NotifyOfPropertyChange(nameof(Idx));
            }
        }
        public string FullName
        {
            get => employee.FullName;
            set
            {
                employee.FullName = value;
                NotifyOfPropertyChange(nameof(FullName));
            }
        }
        public int Salary
        {
            get => employee.Salary;
            set
            {
                employee.Salary = value;
                NotifyOfPropertyChange(nameof(Salary));
            }
        }
        public string DeptName
        {
            get => employee.DeptName;
            set
            {
                employee.DeptName = value;
                NotifyOfPropertyChange(nameof(DeptName));
            }
        }
        public string Address
        {
            get => employee.Address;
            set
            {
                employee.Address = value;
                NotifyOfPropertyChange(nameof(Address));
            }
        }

        public MainViewModel()
        {
            using (SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=pknu;Persist Security Info=True;User ID=sa;Password=12345"))
            {
                con.Open();

                string selQuery = @"SELECT [Idx]
                                         , [FullName]
                                         , [Salary]
                                         , [DeptName]
                                         , [Address]
                                      FROM [dbo].[Employees]";
                SqlCommand sqlCommand = new SqlCommand(selQuery, con);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                ListEmployee = new BindableCollection<Employees>();

                while (reader.Read())
                {
                    var emp = new Employees
                    {
                        idx = int.Parse(reader["Idx"].ToString()),
                        FullName = reader["FullName"].ToString(),
                        Salary = int.Parse(reader["Salary"].ToString()),
                        DeptName = reader["DeptName"].ToString(),
                        Address = reader["address"].ToString()
                    };

                    ListEmployee.Add(emp);
                }
                con.Close();
            }
        }
    }
}
