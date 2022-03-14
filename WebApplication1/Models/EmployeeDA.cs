using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class EmployeeDA
    {
        string conString = "Data Source=SOHEL\\SOHEL;Initial Catalog=EmployeeDB;Integrated Security=true";
        SqlConnection con = null;
        public void save(Employee employee)
        {
           
            try
            {
                con = new SqlConnection(conString);
                con.Open();
                SqlCommand cmd = new SqlCommand("spEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", employee.Id);
                cmd.Parameters.AddWithValue("@EmpName", employee.EmpName);
                cmd.Parameters.AddWithValue("@isAllowOverTime", employee.isAllowOverTime);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Education", employee.Education);
                cmd.Parameters.AddWithValue("@BirthDate", employee.BirthDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Operation", 1);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
        }

        public Employee Get(int Id)
        {
            Employee employee = new Employee();
            try
            {
                con = new SqlConnection(conString);
                con.Open();
                SqlCommand cmd = new SqlCommand($"SELECT     * FROM     Employee WHERE Id={Id}", con);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read()) 
                {

                    employee.Id = (int)reader["Id"];
                    employee.EmpName = (string)reader["EmpName"];
                    employee.isAllowOverTime = (bool)reader["isAllowOverTime"];
                    employee.Gender = (string)reader["Gender"];
                    employee.Education = (string)reader["Education"];
                    employee.BirthDate = (DateTime)reader["BirthDate"];
                    reader.Close();
                }


            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
          
            return employee;
        }
    }
}