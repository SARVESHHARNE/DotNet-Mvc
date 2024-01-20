using System.Data;
using App.Models;
using MySql.Data.MySqlClient;

namespace App.Service;

public class Disconnected
{
    MySqlConnection connection = new MySqlConnection(@"server=localhost; port=3306; user=root; password=root123; database=dotnet;");

    public List<Trainer> GetAll()
    {
        MySqlCommand cmd = new MySqlCommand("select * from gym");
        cmd.Connection = connection;
        List<Trainer> trainers = new List<Trainer>();
        try
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            MySqlCommandBuilder bd = new MySqlCommandBuilder(da);
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            DataRowCollection rows = dt.Rows;
            foreach (DataRow row in rows)
            {
                int id = int.Parse(row["id"].ToString());
                string name = row["name"].ToString();
                string email = row["email"].ToString();
                string mobilenumber = row["mobile"].ToString();
                string address = row["address"].ToString();
                string special = row["special"].ToString();
                int exp = int.Parse(row["exp"].ToString());
                DateTime joining = DateTime.Parse(row["joining"].ToString());
                string remuneration = row["remuneration"].ToString();
                Status status = Enum.Parse<Status>(row["status"].ToString().ToUpper());
                trainers.Add(new Trainer { Id = id, Name = name, Email = email, MobileNumber = mobilenumber, Address = address, Special = special, Exp = exp, Joining = joining, Remuneration = remuneration, Status = status });
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return trainers;
    }

    public Trainer GetById(int eid)
    {
        MySqlCommand cmd = new MySqlCommand("select * from gym");
        cmd.Connection = connection;
        Trainer trainers = null;
        try
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            MySqlCommandBuilder bd = new MySqlCommandBuilder(da);
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            DataRow[] rows = dt.Select("id=" + eid);
            DataRow row = rows[0];

            int id = int.Parse(row["id"].ToString());
            string name = row["name"].ToString();
            string email = row["email"].ToString();
            string mobilenumber = row["mobile"].ToString();
            string address = row["address"].ToString();
            string special = row["special"].ToString();
            int exp = int.Parse(row["exp"].ToString());
            DateTime joining = DateTime.Parse(row["joining"].ToString());
            string remuneration = row["remuneration"].ToString();
            Status status = Enum.Parse<Status>(row["status"].ToString().ToUpper());
            trainers = new Trainer { Id = id, Name = name, Email = email, MobileNumber = mobilenumber, Address = address, Special = special, Exp = exp, Joining = joining, Remuneration = remuneration, Status = status };
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return trainers;
    }

    public Trainer Add(Trainer t)
    {
        MySqlCommand cmd = new MySqlCommand("select * from gym");
        cmd.Connection = connection;
        Trainer trainers = null;
        try
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            MySqlCommandBuilder bd = new MySqlCommandBuilder(da);
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            DataRow row = dt.NewRow();
            Console.WriteLine(t.Email);
            row["id"] = t.Id;
            row["name"] = t.Name;
            row["email"] = t.Email;
            row["mobile"] = t.MobileNumber;
            row["address"] = t.Address;
            row["special"] = t.Special;
            row["exp"] = t.Exp;
            row["joining"] = DateTime.Now;
            row["remuneration"] = t.Remuneration;
            row["status"] = t.Status.ToString();
            dt.Rows.Add(row);
            da.Update(ds);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return trainers;
    }

    public Trainer Edit(Trainer t)
    {
        MySqlCommand cmd = new MySqlCommand("select * from gym");
        cmd.Connection = connection;
        Trainer trainers = null;
        try
        {
            Console.WriteLine("edit with edit");
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            MySqlCommandBuilder bd = new MySqlCommandBuilder(da);
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            DataRow[] rows = dt.Select("id=" + t.Id);
            DataRow row = rows[0];
            Console.WriteLine(t.Email);
            row["id"] = t.Id;
            row["name"] = t.Name;
            row["email"] = t.Email;
            row["mobile"] = t.MobileNumber;
            row["address"] = t.Address;
            row["special"] = t.Special;
            row["exp"] = t.Exp;
            row["joining"] = t.Joining;
            row["remuneration"] = t.Remuneration;
            row["status"] = t.Status.ToString();
            da.Update(ds);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return trainers;
    }

    public Trainer Delete(int eid)
    {
        MySqlCommand cmd = new MySqlCommand("select * from gym");
        cmd.Connection = connection;
        Trainer trainers = null;
        try
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            MySqlCommandBuilder bd = new MySqlCommandBuilder(da);
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            DataRow[] rows = dt.Select("id=" + eid);
            DataRow row = rows[0];
            row.Delete();
            da.Update(ds);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return trainers;
    }
}