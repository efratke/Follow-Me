using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;


namespace FollowMe
{
    public class Dal
    {
        String dbConnection;
        public SqlConnection con;
        SqlDataAdapter adap = new SqlDataAdapter();
        /// <summary>
        /// בניית מחרוזת ההתחברות
        /// </summary>
        public Dal()
        {
            dbConnection = @" Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\owner\Documents\לאה\לימודים\תואר ראשון בהנדסה\שנה ה\פרוייקט גמר\FollowMe\FollowMe\App_Data\FollowMeDB.mdf;Integrated Security=True;User Instance=True";
            con = new SqlConnection(dbConnection);
        }
        /// <summary>
        ///  התחברות לבסיס הנתונים
        /// </summary>
        private void OpenConnection()
        {
            try
            {
                con.Open();
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// closes the connection to the access DB
        /// </summary>
        private void CloseConnection()
        {
            try
            {

                con.Close();
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// מחזירה טבלה בזכרון מבסיס הנתונים
        /// </summary>
        /// <param name="tableName">שם טבלה</param>
        /// <returns>אוביקט הטבלה שבקשנו</returns>

        public object ReadScalar(string queryString, List<SqlParameter> myParameter)
        {
            SqlCommand cmd = new SqlCommand(queryString, con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddRange(myParameter.ToArray());
            cmd.CommandType = CommandType.StoredProcedure;
            object x = cmd.ExecuteScalar();
            con.Close();
            return x;
        }

        public object ReadScalar(string queryString)
        {
            SqlConnection connection = new SqlConnection(dbConnection);
            SqlCommand command = new SqlCommand(queryString, connection);
            connection.Open();
            Object x = command.ExecuteScalar();
            connection.Close();
            return x;
        }

        public DataTable GetTable(String tableName)
        {//פתח התחברות
            OpenConnection();
            //אוביקט פקודה שמגדיר מה לעשות והיכן לעשות
            SqlCommand cmd = new SqlCommand(tableName + "Select", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //הגדרת מתווך- מתאם ואיתחולו בפקודה 
            adap = new SqlDataAdapter(cmd);
            //הצהרה על אוביקט מסוג טבלה בזכרון 
            DataTable dt = new DataTable(tableName);
            //מילוי הטבלה בזכרון מבסיס הנתונים 
            adap.Fill(dt);
            //סגירה 
            CloseConnection();
            return dt;
        }
        public DataTable GetTable(String tableName, List<SqlParameter> myParameter)
        {//פתח התחברות
            OpenConnection();
            //אוביקט פקודה שמגדיר מה לעשות והיכן לעשות
            SqlCommand cmd = new SqlCommand(tableName + "Select", con);
            cmd.Parameters.AddRange(myParameter.ToArray());
            cmd.CommandType = CommandType.StoredProcedure;
            //הגדרת מתווך- מתאם ואיתחולו בפקודה 
            adap = new SqlDataAdapter(cmd);
            //הצהרה על אוביקט מסוג טבלה בזכרון 
            DataTable dt = new DataTable(tableName);
            //מילוי הטבלה בזכרון מבסיס הנתונים 
            adap.Fill(dt);
            //סגירה 
            CloseConnection();
            return dt;
        }

        public DataTable ReadTable(String queryString)
        {
            SqlConnection connection = new SqlConnection(dbConnection);
            SqlCommand cmd = new SqlCommand(queryString, connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }


        public int SetTable(DataTable dt)
        {
            SqlCommand myInsertCommand = new SqlCommand(dt.TableName + "Insert", con);
            SqlCommand myDeleteCommand = new SqlCommand(dt.TableName + "Delete", con);
            myInsertCommand.CommandType = CommandType.StoredProcedure;
            myDeleteCommand.CommandType = CommandType.StoredProcedure;
            //איתחול הפרמטרים בעזרת בונה הפקודה
            OpenConnection();
            SqlCommandBuilder.DeriveParameters(myDeleteCommand);
            SqlCommandBuilder.DeriveParameters(myInsertCommand);
            //לדאוג לערכים .לעמודת מקור של כל אחד מהפרמטרים שנבנו בתוך אוסף הפרמטרים

            adap.DeleteCommand = myDeleteCommand;
            adap.InsertCommand = myInsertCommand;

            int i = adap.Update(dt);
            CloseConnection();
            return i;
        }

        public int WriteToDB(String tableName, List<SqlParameter> l)
        {
            SqlCommand command = new SqlCommand(tableName + "Insert", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(l.ToArray());
            con.Open();
            int x = command.ExecuteNonQuery();
            con.Close();
            return x;
        }
        public int DeleteInDB(String tableName, List<SqlParameter> l)
        {
            SqlCommand command = new SqlCommand(tableName + "Delete", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(l.ToArray());
            con.Open();
            int x = command.ExecuteNonQuery();
            con.Close();
            return x;
        }



        public int WriteToDB(String queryString)
        {
            SqlConnection connection = new SqlConnection(dbConnection);
            SqlCommand command = new SqlCommand(queryString, connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            connection.Open();
            int x = command.ExecuteNonQuery();
            connection.Close();
            return x;
        }


    }
}