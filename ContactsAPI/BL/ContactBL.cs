using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace ContactsAPI.BL
{
    public class ContactBL
    {
        public ContactBL()
        {

        }

        public DataTable getContacts()
        {
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand("select * from tblcontacts where isnull(isDeleted,0)=0", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public bool AddNewContact(ContactsAPI.Classes.ContactClass newContact)
        {
            var emailId = new SqlParameter("@EmailId", System.Data.SqlDbType.NVarChar)
            {
                Value = newContact.EmailId
            };
            var firstName = new SqlParameter("@Firstname", System.Data.SqlDbType.NVarChar)
            {
                Value = newContact.Firstname
            };
            var lastName = new SqlParameter("@LastName", System.Data.SqlDbType.NVarChar)
            {
                Value = newContact.LastName
            };
            var phoneNunmber = new SqlParameter("@PhoneNumber", System.Data.SqlDbType.NVarChar)
            {
                Value = newContact.PhoneNumber
            };
            var status = new SqlParameter("@Status", System.Data.SqlDbType.Bit)
            {
                Value = newContact.Status
            };
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand();
            if (newContact.Id > 0)
            {
                cmd = new SqlCommand(
                            "update tblcontacts set " +
                            "emailid=@EmailId, " +
                            "FirstName=@FirstName, " +
                            "LastName=@LastName, " +
                            "PhoneNumber=@PhoneNumber, " +
                            "status=@Status " +
                            "where id=@id"
                            , con);
                var id = new SqlParameter("@id", System.Data.SqlDbType.Int)
                {
                    Value = newContact.Id
                };
                cmd.Parameters.Add(id);
            }
            else
            {
                cmd = new SqlCommand(
             "insert into tblcontacts (emailId,firstName,lastName,phonenumber,status) " +
             "values(@EmailId,@FirstName,@LastName,@PhoneNumber,@Status)"
             , con);

            }
            cmd.Parameters.Add(emailId);
            cmd.Parameters.Add(firstName);
            cmd.Parameters.Add(lastName);
            cmd.Parameters.Add(phoneNunmber);
            cmd.Parameters.Add(status);
            int res = cmd.ExecuteNonQuery();
            return (res > 0);
        }

        public bool DeleteContact(int Id)
        {
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand();
            if (Id > 0)
            {
                cmd = new SqlCommand(
                            "update tblcontacts set " +
                            "isDeleted=1 " +
                            "where id=@id"
                            , con);
                var id = new SqlParameter("@id", System.Data.SqlDbType.Int)
                {
                    Value = Id
                };
                cmd.Parameters.Add(id);
                int res = cmd.ExecuteNonQuery();
                return (res > 0);
            }
            else
            {
                return false;
            }
        }


        public SqlConnection GetConnection()
        {
            string connection = Startup.Connection;
            SqlConnection con = new SqlConnection(connection);
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
            return con;
        }
    }
}
