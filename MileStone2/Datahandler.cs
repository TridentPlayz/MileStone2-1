using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace MileStone2
{
    class DataHandler
    {


        int modulecode;
        string modulename;
        string moduledescription;
        string moduleresource;

        SqlConnection conn = new SqlConnection("Server=.;Initial Catalog=Petshop;Integrated security=SSPI");
        public DataHandler() { }

        public DataHandler(int modulecode, string modulename, string moduledescription, string moduleresource)
        {
            this.modulecode = modulecode;
            this.modulename = modulename;
            this.moduledescription = moduledescription;
            this.moduleresource = moduleresource;
        }

        public DataHandler(int modulecode, string modulename, string moduledescription)
        {
            this.modulecode = modulecode;
            this.modulename = modulename;
            this.moduledescription = moduledescription;
        }
        public void updateName(int modulecode_, string modulename_)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("up1valname", conn);
            cmd.Parameters.AddWithValue("@id", modulecode_);
            cmd.Parameters.AddWithValue("@name", modulename_);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void updateSurname(int modulecode_, string moduledescription_)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("up1valSurname", conn);
            cmd.Parameters.AddWithValue("@id", modulecode_);
            cmd.Parameters.AddWithValue("@surname", moduledescription_);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void updateAll(int modulecode_, string modulename_, string moduledescription_, string moduleresource_)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("up1valall", conn);
            cmd.Parameters.AddWithValue("@id", modulecode_);
            cmd.Parameters.AddWithValue("@name", modulename_);
            cmd.Parameters.AddWithValue("@surname", moduledescription_);
            cmd.Parameters.AddWithValue("@surname", moduleresource_);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void DBAccess()
        {
            try
            {
                SqlConnection con = new SqlConnection("Server=.;Initial Catalog=Petshop;Integrated security=SSPI");

            }
            catch (Exception)
            {

                MessageBox.Show("was not connected", "Connection Problem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        public DataTable ReadData()
        {

            DataTable dt = new DataTable();
            try
            {

                conn.Open();
                SqlDataAdapter SDA = new SqlDataAdapter("ViewAll", conn);
                SDA.SelectCommand.CommandType = CommandType.StoredProcedure;
                SDA.Fill(dt);
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return dt;
            }
        }

        public void InsertData(string name, string surname, string idNumber, string gender)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Inserted", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@surname", surname);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@IDNumber", idNumber);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public DataTable ReadUserPet(int number)
        {
            DataTable tb = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("readPet", conn);
                cmd.Parameters.AddWithValue("ids", number);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter SDA = new SqlDataAdapter();
                SDA.SelectCommand = cmd;

                SDA.Fill(tb);
                conn.Close();
                return tb;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return tb;
            }
        }

        public string DeleteData(string num)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("deleteid", conn);
                cmd.Parameters.AddWithValue("@idNumber", num);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                conn.Close();
                return "record deleted";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public void StorePet(string name, string type, int age) //, int userid
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insertPet", conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@age", age);
                // cmd.Parameters.AddWithValue("@user", userid);
                conn.Close();
                MessageBox.Show("record inserted");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
    }
}
