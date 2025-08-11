using Microsoft.Data.SqlClient;
using System;

namespace Assignment1
{
    internal class Program
    {
        static string cs = "server=LAPTOP-HLBR261P;database=Emp;integrated security=true;Encrypt=True;TrustServerCertificate=True";

        static void Main(string[] args)
        {
            int addedCount = 0;

            while (true)
            {
                Console.WriteLine("\n--- Employee Management ---");
                Console.WriteLine("1. Add Contract Employee");
                Console.WriteLine("2. Add Payroll Employee");
                Console.WriteLine("3. Display All Employees");
                Console.WriteLine("4. Exit");
                Console.Write("Enter choice: ");
                if (!int.TryParse(Console.ReadLine(), out int ch))
                {
                    Console.WriteLine("Invalid input, enter a number.");
                    continue;
                }

                switch (ch)
                {
                    case 1:
                        AddContractEmployee();
                        addedCount++;
                        break;
                    case 2:
                        AddPayrollEmployee();
                        addedCount++;
                        break;
                    case 3:
                        DisplayAllEmployees();
                        break;
                    case 4:
                        int totalEmployeesInDb = GetTotalEmployeeCount();
                        Console.WriteLine("\nTotal Employees added in this session: " + addedCount);
                        Console.WriteLine("Total Employees in database: " + totalEmployeesInDb);
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        static void AddContractEmployee()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Manager: ");
            string manager = Console.ReadLine();

            Console.Write("Enter Contract Date (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime contractDate))
            {
                Console.WriteLine("Invalid date format.");
                return;
            }

            Console.Write("Enter Duration (months): ");
            if (!int.TryParse(Console.ReadLine(), out int duration))
            {
                Console.WriteLine("Invalid duration input.");
                return;
            }

            Console.Write("Enter Charges: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal charges))
            {
                Console.WriteLine("Invalid charges input.");
                return;
            }

            using (SqlConnection con = new SqlConnection(cs))
            {
                string q = @"INSERT INTO Employee 
                             (name, manager, employeeType, contractDate, duration, charges) 
                             VALUES (@n, @m, 'Contract', @cd, @dur, @chg)";

                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@n", name);
                cmd.Parameters.AddWithValue("@m", manager);
                cmd.Parameters.AddWithValue("@cd", contractDate);
                cmd.Parameters.AddWithValue("@dur", duration);
                cmd.Parameters.AddWithValue("@chg", charges);

                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("\nContract Employee added successfully.\n");
            }
        }

        static void AddPayrollEmployee()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Manager: ");
            string manager = Console.ReadLine();

            Console.Write("Enter Joining Date (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime joiningDate))
            {
                Console.WriteLine("Invalid date format.");
                return;
            }

            Console.Write("Enter Experience (years): ");
            if (!int.TryParse(Console.ReadLine(), out int exp))
            {
                Console.WriteLine("Invalid experience input.");
                return;
            }

            Console.Write("Enter Basic Salary: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal basic))
            {
                Console.WriteLine("Invalid basic salary input.");
                return;
            }

            decimal da = 0m, hra = 0m, pf = 0m;

            if (exp > 10)
            {
                da = basic * 0.10m;
                hra = basic * 0.085m;
                pf = 6200m;
            }
            else if (exp > 7)
            {
                da = basic * 0.07m;
                hra = basic * 0.065m;
                pf = 4100m;
            }
            else if (exp > 5)
            {
                da = basic * 0.041m;
                hra = basic * 0.038m;
                pf = 1800m;
            }
            else 
            {
                da = basic * 0.019m;
                hra = basic * 0.02m;
                pf = 1200m;
            }

            decimal netSalary = basic + da + hra - pf;

            using (SqlConnection con = new SqlConnection(cs))
            {
                string q = @"INSERT INTO Employee 
                             (name, manager, employeeType, joiningDate, exp, basic, da, hra, pf, netSalary) 
                             VALUES (@n, @m, 'Payroll', @jd, @e, @b, @d, @h, @p, @ns)";

                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@n", name);
                cmd.Parameters.AddWithValue("@m", manager);
                cmd.Parameters.AddWithValue("@jd", joiningDate);
                cmd.Parameters.AddWithValue("@e", exp);
                cmd.Parameters.AddWithValue("@b", basic);
                cmd.Parameters.AddWithValue("@d", da);
                cmd.Parameters.AddWithValue("@h", hra);
                cmd.Parameters.AddWithValue("@p", pf);
                cmd.Parameters.AddWithValue("@ns", netSalary);

                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("\nPayroll Employee added successfully.\n");
            }
        }

        static void DisplayAllEmployees()
        {
            Console.WriteLine("\n--- All Employees ---");
            using (SqlConnection con = new SqlConnection(cs))
            {
                string q = "SELECT * FROM Employee ORDER BY id";
                SqlCommand cmd = new SqlCommand(q, con);

                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(reader.GetOrdinal("id"));
                        string name = reader.GetString(reader.GetOrdinal("name"));
                        string manager = reader.GetString(reader.GetOrdinal("manager"));
                        string type = reader.GetString(reader.GetOrdinal("employeeType"));

                        Console.WriteLine($"\nID: {id} | Name: {name} | Manager: {manager} | Type: {type}");

                        if (type == "Contract")
                        {
                            DateTime cd = reader.GetDateTime(reader.GetOrdinal("contractDate"));
                            int dur = reader.GetInt32(reader.GetOrdinal("duration"));
                            decimal charges = reader.GetDecimal(reader.GetOrdinal("charges"));
                            Console.WriteLine($"Contract Date: {cd:d}, Duration: {dur} months, Charges: INR {charges:F2}");
                        }
                        else if (type == "Payroll")
                        {
                            DateTime jd = reader.GetDateTime(reader.GetOrdinal("joiningDate"));
                            int exp = reader.GetInt32(reader.GetOrdinal("exp"));
                            decimal basic = reader.GetDecimal(reader.GetOrdinal("basic"));
                            decimal da = reader.GetDecimal(reader.GetOrdinal("da"));
                            decimal hra = reader.GetDecimal(reader.GetOrdinal("hra"));
                            decimal pf = reader.GetDecimal(reader.GetOrdinal("pf"));
                            decimal net = reader.GetDecimal(reader.GetOrdinal("netSalary"));

                            Console.WriteLine($"Joining Date: {jd:d}, Experience: {exp} years");
                            Console.WriteLine($"Basic Salary: INR {basic:F2}, DA: INR {da:F2}, HRA: INR {hra:F2}, PF: INR {pf:F2}");
                            Console.WriteLine($"Net Salary: INR {net:F2}");
                        }
                    }
                }
            }
        }

        static int GetTotalEmployeeCount()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string q = "SELECT COUNT(*) FROM Employee";
                SqlCommand cmd = new SqlCommand(q, con);
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                return count;
            }
        }
    }
}
