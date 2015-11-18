using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Caching;
using System.Web.Configuration;

/// <summary>
/// This is for all internal Milktart DB functions.
/// </summary>
public static class DBCommand {

    #region SQL CONNECTION

    /// <summary>
    /// This method handles ALL the Database executions. Easy to generate a generic error response then. Without Token validation.
    /// </summary>
    /// <param name="Command"></param>
    /// <returns></returns>
    private static DataSet ExecuteSQLConnectionCommand(SqlCommand Command) {

        bool secondAttempt = false;

        using (SqlConnection Connection = new SqlConnection(WebConfigurationManager.AppSettings["DBConnection"])) {

            DataSet ReturnDataSet = new DataSet();
            Command.CommandType = CommandType.StoredProcedure;
            Command.Connection = Connection;

            /* OPEN CONNECTION TO THE DATABASE */
            Connection.Open();

            RETRY:

            try {

                using (SqlDataAdapter SQLDataAdapter = new SqlDataAdapter(Command)) {
                    /* POPULATE THE DATASET WITH THE DATA */
                    SQLDataAdapter.Fill(ReturnDataSet);
                }

            } catch (SqlException ex) {

                // IF TIMEOUT EXCEPTION, TRY AGAIN PLEASE
                if (ex.Number == 2 && !secondAttempt) {
                    secondAttempt = true;
                    goto RETRY;
                }

            }

            /* RETURN THE DATASET */
            return ReturnDataSet;

        }

    }

    /// <summary>
    /// Generic method to create a SQLParameter.
    /// </summary>
    /// <param name="ParameterName">Specify the @Parameter name value.</param>
    /// <param name="DataType">Which data type, varchar, int?</param>
    /// <param name="Size">The size, normally in brackets in SQL, ie. VARCHAR(200)</param>
    /// <param name="Value">The value of the parameter being passed in.</param>
    /// <returns></returns>
    private static SqlParameter CreateSQLParameter(string ParameterName, SqlDbType DataType, object Value, int Size) {

        SqlParameter objParam = new SqlParameter();
        objParam.ParameterName = ParameterName;
        objParam.Size = Size;
        objParam.SqlDbType = DataType;
        objParam.Value = Value;

        return objParam;

    }

    /// <summary>
    /// Generic method to create a SQLParameter.
    /// </summary>
    /// <param name="ParameterName">Specify the @Parameter name value.</param>
    /// <param name="DataType">Which data type, varchar, int?</param>
    /// <param name="Value">The value of the parameter being passed in.</param>
    /// <returns></returns>
    private static SqlParameter CreateSQLParameter(string ParameterName, SqlDbType DataType, object Value) {

        SqlParameter objParam = new SqlParameter();
        objParam.ParameterName = ParameterName;
        objParam.SqlDbType = DataType;
        objParam.Value = Value;

        return objParam;

    }

    #endregion

    /// <summary>
    /// Create a new board entry.
    /// </summary>
    /// <param name="BoardGUID"></param>
    /// <param name="BoardName"></param>
    /// <param name="BoardDescription"></param>
    /// <param name="Closed"></param>
    /// <param name="LastActivity"></param>
    /// <param name="Invited"></param>
    /// <param name="Starred"></param>
    /// <param name="URL"></param>
    /// <param name="BackgroundImage"></param>
    /// <param name="DateLastViewed"></param>
    /// <returns></returns>
    public static int Board_Insert_New_Board_ReturnBoardID(string BoardGUID, string BoardName, string BoardDescription, bool Closed, DateTime LastActivity, bool Invited, bool Starred, string URL, string BackgroundImage, DateTime DateLastViewed) {

        using (SqlCommand Command = new SqlCommand("Board_Insert_New_Board_ReturnBoardID")) {

            Command.Parameters.Add(CreateSQLParameter("BoardGUID", SqlDbType.VarChar, BoardGUID, 255));
            Command.Parameters.Add(CreateSQLParameter("BoardName", SqlDbType.VarChar, BoardName, 255));
            Command.Parameters.Add(CreateSQLParameter("BoardDescription", SqlDbType.VarChar, BoardDescription, 2000));
            Command.Parameters.Add(CreateSQLParameter("Closed", SqlDbType.Bit, Closed));
            Command.Parameters.Add(CreateSQLParameter("LastActivity", SqlDbType.DateTime, LastActivity));
            Command.Parameters.Add(CreateSQLParameter("Invited", SqlDbType.Bit, Invited));
            Command.Parameters.Add(CreateSQLParameter("Starred", SqlDbType.Bit, Starred));
            Command.Parameters.Add(CreateSQLParameter("URL", SqlDbType.VarChar, URL, 2000));
            Command.Parameters.Add(CreateSQLParameter("BackgroundImage", SqlDbType.VarChar, BackgroundImage, 2000));
            Command.Parameters.Add(CreateSQLParameter("DateLastViewed", SqlDbType.DateTime, DateLastViewed));

            DataSet SecurityDataSet = ExecuteSQLConnectionCommand(Command);

            if (SecurityDataSet.Tables.Count > 0 && SecurityDataSet.Tables[0].Rows.Count > 0) {
                return int.Parse(SecurityDataSet.Tables[0].Rows[0]["BoardID"].ToString());
            }

            return 0;

        }

    }

    /// <summary>
    /// Create a new member and assign them to the board.
    /// </summary>
    /// <param name="BoardID"></param>
    /// <param name="BoardMemberGUID"></param>
    /// <param name="MemberGUID"></param>
    /// <param name="MemberType"></param>
    /// <param name="MemberName"></param>
    /// <param name="Initials"></param>
    /// <param name="UserName"></param>
    /// <returns></returns>
    public static int Board_Insert_New_Member_ReturnMemberID(int BoardID, string BoardMemberGUID, string MemberGUID, string MemberType, string MemberName, string Initials, string UserName) {

        using (SqlCommand Command = new SqlCommand("Board_Insert_New_Member_ReturnMemberID")) {

            Command.Parameters.Add(CreateSQLParameter("BoardID", SqlDbType.Int, BoardID));
            Command.Parameters.Add(CreateSQLParameter("BoardMemberGUID", SqlDbType.VarChar, BoardMemberGUID, 255));
            Command.Parameters.Add(CreateSQLParameter("MemberGUID", SqlDbType.VarChar, MemberGUID, 255));
            Command.Parameters.Add(CreateSQLParameter("MemberType", SqlDbType.VarChar, MemberType, 50));
            Command.Parameters.Add(CreateSQLParameter("MemberName", SqlDbType.VarChar, MemberName, 255));
            Command.Parameters.Add(CreateSQLParameter("Initials", SqlDbType.VarChar, Initials, 50));
            Command.Parameters.Add(CreateSQLParameter("UserName", SqlDbType.VarChar, UserName, 255));

            DataSet SecurityDataSet = ExecuteSQLConnectionCommand(Command);

            if (SecurityDataSet.Tables.Count > 0 && SecurityDataSet.Tables[0].Rows.Count > 0) {
                return int.Parse(SecurityDataSet.Tables[0].Rows[0]["MemberID"].ToString());
            }

            return 0;

        }

    }

    /// <summary>
    /// Updates the member with new details.
    /// </summary>
    /// <param name="MemberGUID"></param>
    /// <param name="MemberName"></param>
    /// <param name="Initials"></param>
    /// <param name="UserName"></param>
    /// <returns></returns>
    public static int Board_Update_Member_ReturnMemberID(string MemberGUID, string MemberName, string Initials, string UserName) {

        using (SqlCommand Command = new SqlCommand("Board_Update_Member_ReturnMemberID")) {

            Command.Parameters.Add(CreateSQLParameter("MemberGUID", SqlDbType.VarChar, MemberGUID, 255));
            Command.Parameters.Add(CreateSQLParameter("MemberName", SqlDbType.VarChar, MemberName, 255));
            Command.Parameters.Add(CreateSQLParameter("Initials", SqlDbType.VarChar, Initials, 50));
            Command.Parameters.Add(CreateSQLParameter("UserName", SqlDbType.VarChar, UserName, 255));

            DataSet SecurityDataSet = ExecuteSQLConnectionCommand(Command);

            if (SecurityDataSet.Tables.Count > 0 && SecurityDataSet.Tables[0].Rows.Count > 0) {
                return int.Parse(SecurityDataSet.Tables[0].Rows[0]["MemberID"].ToString());
            }

            return 0;

        }

    }

    /// <summary>
    /// Creates a board list.
    /// </summary>
    /// <param name="BoardID"></param>
    /// <param name="ListID"></param>
    /// <param name="Closed"></param>
    /// <param name="Name"></param>
    /// <returns></returns>
    public static int Board_Insert_List_ReturnListID(int BoardID, string ListID, bool Closed, string Name) {

        using (SqlCommand Command = new SqlCommand("Board_Insert_List_ReturnListID")) {

            Command.Parameters.Add(CreateSQLParameter("BoardID", SqlDbType.Int, BoardID));
            Command.Parameters.Add(CreateSQLParameter("GUID", SqlDbType.VarChar, ListID, 255));
            Command.Parameters.Add(CreateSQLParameter("Closed", SqlDbType.Bit, Closed));
            Command.Parameters.Add(CreateSQLParameter("Name", SqlDbType.VarChar, Name, 255));

            DataSet SecurityDataSet = ExecuteSQLConnectionCommand(Command);

            if (SecurityDataSet.Tables.Count > 0 && SecurityDataSet.Tables[0].Rows.Count > 0) {
                return int.Parse(SecurityDataSet.Tables[0].Rows[0]["ListID"].ToString());
            }

            return 0;

        }

    }

    /// <summary>
    /// Create card.
    /// </summary>
    /// <param name="CurrentListID"></param>
    /// <param name="CurrentBoardID"></param>
    /// <param name="CardGUID"></param>
    /// <param name="Closed"></param>
    /// <param name="Name"></param>
    /// <param name="Description"></param>
    /// <param name="URL"></param>
    /// <returns></returns>
    public static int Board_Insert_Card_ReturnCardID(int CurrentListID, int CurrentBoardID, string CardGUID, bool Closed, string Name, string Description, string URL, DateTime DateCreated) {

        using (SqlCommand Command = new SqlCommand("Board_Insert_Card_ReturnCardID")) {

            Command.Parameters.Add(CreateSQLParameter("CurrentListID", SqlDbType.Int, CurrentListID));
            Command.Parameters.Add(CreateSQLParameter("CurrentBoardID", SqlDbType.Int, CurrentBoardID));
            Command.Parameters.Add(CreateSQLParameter("GUID", SqlDbType.VarChar, CardGUID, 255));
            Command.Parameters.Add(CreateSQLParameter("Closed", SqlDbType.Bit, Closed));
            Command.Parameters.Add(CreateSQLParameter("Name", SqlDbType.VarChar, Name, 255));
            Command.Parameters.Add(CreateSQLParameter("Description", SqlDbType.VarChar, Description, 2000));
            Command.Parameters.Add(CreateSQLParameter("URL", SqlDbType.VarChar, URL, 2000));
            Command.Parameters.Add(CreateSQLParameter("DateCreated", SqlDbType.DateTime, DateCreated));

            DataSet SecurityDataSet = ExecuteSQLConnectionCommand(Command);

            if (SecurityDataSet.Tables.Count > 0 && SecurityDataSet.Tables[0].Rows.Count > 0) {
                return int.Parse(SecurityDataSet.Tables[0].Rows[0]["CardID"].ToString());
            }

            return 0;

        }

    }

    /// <summary>
    /// Assign the card to the list
    /// </summary>
    /// <param name="CardID"></param>
    /// <param name="ListID"></param>
    /// <param name="MemberGUID"></param>
    /// <param name="DateCreated"></param>
    /// <returns></returns>
    public static int Board_Insert_Assign_Card_ToList_ReturnID(int CardID, string ListGUID, string MemberGUID, DateTime DateCreated) {

        using (SqlCommand Command = new SqlCommand("Board_Insert_Assign_Card_ToList_ReturnID")) {

            Command.Parameters.Add(CreateSQLParameter("CardID", SqlDbType.Int, CardID));
            Command.Parameters.Add(CreateSQLParameter("ListGUID", SqlDbType.VarChar, ListGUID, 255));
            Command.Parameters.Add(CreateSQLParameter("MemberGUID", SqlDbType.VarChar, MemberGUID, 255));
            Command.Parameters.Add(CreateSQLParameter("DateCreated", SqlDbType.DateTime, DateCreated));

            DataSet SecurityDataSet = ExecuteSQLConnectionCommand(Command);

            if (SecurityDataSet.Tables.Count > 0 && SecurityDataSet.Tables[0].Rows.Count > 0) {
                return int.Parse(SecurityDataSet.Tables[0].Rows[0]["CardListID"].ToString());
            }

            return 0;

        }

    }

    /// <summary>
    /// Add an action to the card.
    /// </summary>
    /// <param name="CardID"></param>
    /// <param name="ActionGUID"></param>
    /// <param name="MemberGUID"></param>
    /// <param name="ActionType"></param>
    /// <param name="ActionText"></param>
    /// <param name="DateCreated"></param>
    /// <returns></returns>
    public static int Board_Insert_Card_Action_ReturnActionID(int CardID, string ActionGUID, string MemberGUID, string ActionType, string ActionText, DateTime DateCreated) {

        using (SqlCommand Command = new SqlCommand("Board_Insert_Card_Action_ReturnActionID")) {

            Command.Parameters.Add(CreateSQLParameter("CardID", SqlDbType.Int, CardID));
            Command.Parameters.Add(CreateSQLParameter("ActionGUID", SqlDbType.VarChar, ActionGUID, 255));
            Command.Parameters.Add(CreateSQLParameter("MemberGUID", SqlDbType.VarChar, MemberGUID, 255));
            Command.Parameters.Add(CreateSQLParameter("ActionType", SqlDbType.VarChar, ActionType, 50));
            Command.Parameters.Add(CreateSQLParameter("ActionText", SqlDbType.VarChar, ActionText, 2000));
            Command.Parameters.Add(CreateSQLParameter("DateCreated", SqlDbType.DateTime, DateCreated));

            DataSet SecurityDataSet = ExecuteSQLConnectionCommand(Command);

            if (SecurityDataSet.Tables.Count > 0 && SecurityDataSet.Tables[0].Rows.Count > 0) {
                return int.Parse(SecurityDataSet.Tables[0].Rows[0]["ActionID"].ToString());
            }

            return 0;

        }

    }

    /// <summary>
    /// Clear the entire database.
    /// </summary>
    public static void Delete_Clear_Database() {

        using (SqlCommand Command = new SqlCommand("Delete_Clear_Database")) {

            DataSet SecurityDataSet = ExecuteSQLConnectionCommand(Command);

        }

    }

    /// <summary>
    /// Does Trello exist? 
    /// </summary>
    /// <returns></returns>
    public static bool Verify_Database_Exists() {

        if (!string.IsNullOrEmpty(WebConfigurationManager.AppSettings["DBConnection"])) {

            SqlConnection db = new SqlConnection(WebConfigurationManager.AppSettings["DBConnection"]);

            try {

                db.Open();
                return true;

            } catch {

                return false;

            }

        }

        return false;

    }

    /// <summary>
    /// Create Trello database.
    /// </summary>
    /// <returns></returns>
    public static bool Create_Database() {

        string _logPath = HttpContext.Current.Server.MapPath("") + @"\output\log.txt";
        string _DBScript = File.ReadAllText(HttpContext.Current.Server.MapPath("") + @"\scripts\CreateTrello.sql");

        using (SqlCommand Command = new SqlCommand(_DBScript)) {

            try {

                using (SqlConnection Connection = new SqlConnection(WebConfigurationManager.AppSettings["DBConnection"]
                    .Replace(";Database=Trello;", ";Database=master;"))) {

                    Command.CommandType = CommandType.Text;
                    Command.Connection = Connection;

                    /* OPEN CONNECTION TO THE DATABASE */
                    Connection.Open();

                    Command.ExecuteNonQuery();

                    return true;

                }

            } catch (Exception ex) {

                File.WriteAllText(_logPath, DateTime.Now.ToString(@"ddMMyyyy HH:mm:ss") + " ERROR: Failed to create Trello database." + Environment.NewLine +
                    "--> Reason: " + ex.Message.ToString() + Environment.NewLine +
                    "--> Stack Trace: " + ex.StackTrace + Environment.NewLine + Environment.NewLine);

            }

        }

        return false;

    }

}
