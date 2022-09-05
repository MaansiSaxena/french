using System;
using System.Data;
using System.Data.SqlClient;

namespace Franchise
{
    class Program
    {
        enum categories
        {
            medical,
            noida,
            delhi,
            Mumbai,
            Agra,
            Jaipur
        }
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection("server=BHAVNAWKS593;database=franchchisee;integrated security=true");

            Console.WriteLine("Enter your id and password : ");
            int logid = int.Parse(Console.ReadLine());
            string pass = Console.ReadLine();

            SqlDataAdapter da = new SqlDataAdapter("select * from login_franch", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "login_fran");
            int x = ds.Tables[0].Rows.Count;


            for (int i = 0; i < x; i++)
            {
                if (logid.ToString() == "1")
                {
                if (logid.ToString() == ds.Tables[0].Rows[i][0].ToString())
                {
                    if (pass.ToString() == ds.Tables[0].Rows[i][1].ToString())
                    {
                        string isRepeat = "Y";

                        while (isRepeat.ToUpper() == "Y")
                        {
                            Console.WriteLine("Franchisee log in!!");
                           
                            Console.WriteLine("press 1 for data insertion"); //in which table
                            Console.WriteLine("press 2 for view the franchisee data");

                                int n = int.Parse(Console.ReadLine());

                            franch_info fi = new franch_info();
                            switch (n)
                            {
                                case 1:
                                    Console.WriteLine("Franchisee details: e_id, employee name,pfl, salary,sale, date, c_id");

                                    fi.e_id = int.Parse(Console.ReadLine());
                                    fi.e_name = Console.ReadLine();
                                    fi.pfl = Console.ReadLine();
                                    fi.salary = int.Parse(Console.ReadLine());
                                    fi.sale = Console.ReadLine();
                                    fi.date = Console.ReadLine();
                                    fi.c_id = int.Parse(Console.ReadLine());


                                    SqlCommand cmd = new SqlCommand("insert into franc_2 values(" + fi.e_id + ",'" + fi.e_name + "','" + fi.pfl + "', " + fi.salary + ",'" + fi.sale + "' , '" + fi.date + "', " + fi.c_id + ")", con);
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                    Console.WriteLine("record inserted");
                                    break;
                                    case 2:
                                        Console.WriteLine("Enter the franch id to be searched");
                                        fi.c_id = int.Parse(Console.ReadLine());

                                        SqlDataAdapter dataadap = new SqlDataAdapter("select * from franc_2", con);
                                        dataadap.Fill(ds, "product"); //variable product
                                        int num = ds.Tables[1].Rows.Count;
                                        int temp = 0; //declare

                                        for (int j = 0; j < num; j++)
                                        {
                                            if (fi.c_id.ToString() == ds.Tables[1].Rows[j][6].ToString())
                                            {
                                                Console.WriteLine("Employee name: " + ds.Tables["product"].Rows[j][1].ToString());
                                                Console.WriteLine("emp profile: " + ds.Tables["product"].Rows[j][2].ToString());
                                                Console.WriteLine("emp salary: " + ds.Tables["product"].Rows[j][3].ToString());
                                                Console.WriteLine("sale: " + ds.Tables["product"].Rows[j][4].ToString());
                                                Console.WriteLine("date: " + ds.Tables["product"].Rows[j][5].ToString());
                                                Console.WriteLine("city: " + Enum.GetName(typeof(categories), ds.Tables["product"].Rows[j][6]));
                                                temp = 1; // else na chle
                                                break;
                                            }
                                            else
                                            {
                                                temp = 0;
                                            }
                                        }
                                        if (temp == 0)
                                        {
                                            Console.WriteLine("franchisee is not available");
                                        }
                                        break;

                                }

                                Console.WriteLine("Do you want to continue Y/N");
                                isRepeat = Console.ReadLine();


                                // owner login krne k baad option aaye kis city ki details chahiye 1.Delhi 2.Mumbai 3.Noida 4.Agra 5.Jaipur
                                // Mumbai ki chahiye press 2
                                //wants to 1.update 2.insert 3.delete or 4.see all the details
                                // 4 option select krne p to unke wha employee unki salary, sale datewise, total employee aa jaye 


                            }
                        }
                }
            }
                if (logid.ToString() == "2")
                {
                    if (logid.ToString() == ds.Tables[0].Rows[i][0].ToString())
                    {
                        if (pass.ToString() == ds.Tables[0].Rows[i][1].ToString())
                        {
                            string isRepeat = "Y";

                            while (isRepeat.ToUpper() == "Y")
                            {
                                Console.WriteLine("Admin Log in!!");
                                Console.WriteLine("press 1 create franchisee"); //in which table
                                Console.WriteLine("press 2 view franchisee data");

                                int n = int.Parse(Console.ReadLine());

                                admin ad = new admin();
                                switch (n)
                                {
                                    case 1:
                                        Console.WriteLine("create Franchisee: f_code, f_city, date, t_sale");

                                        ad.f_code = int.Parse(Console.ReadLine());
                                        ad.f_city = Console.ReadLine();
                                        ad.date = Console.ReadLine();
                                        ad.t_sale = int.Parse(Console.ReadLine());




                                        SqlCommand cmd = new SqlCommand("insert into admin_french values(" + ad.f_code + ",'" + ad.f_city + "','" + ad.date + "', " + ad.t_sale + ")", con);
                                        con.Open();
                                        cmd.ExecuteNonQuery();
                                        con.Close();
                                        Console.WriteLine("Frenchisee created");
                                        break;


                                    case 2:

                                        DataSet ds2 = new DataSet();
                                        SqlDataAdapter dataadap = new SqlDataAdapter("select * from admin_french", con);
                                        dataadap.Fill(ds2, "admin1"); //variable product
                                        int num = ds2.Tables[0].Rows.Count;                           

                                        for (int j = 0; j < num; j++)
  
                                            {
                                                Console.WriteLine("french_code: " + ds2.Tables["admin1"].Rows[j][0].ToString());
                                                Console.WriteLine("french_city: " + ds2.Tables["admin1"].Rows[j][1].ToString());
                                                Console.WriteLine("french_date: " + ds2.Tables["admin1"].Rows[j][2].ToString());
                                                Console.WriteLine("french_totalsale: " + ds2.Tables["admin1"].Rows[j][3].ToString());                                       
                                            }

                                        break; 
                                }
                                Console.WriteLine("Do you want to continue Y/N");
                                isRepeat = Console.ReadLine();

                            }
                        }

                    }
                }

            }
        }
    }
}