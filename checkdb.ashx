<%@ WebHandler Language="C#" Class="checkdb" %>

using System;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using System.Configuration;
using System.Web;

public class checkdb : IHttpHandler {

    public class _response {
        public bool Success { get; set; }
        public string ConnString { get; set; }
    }

    public void ProcessRequest(HttpContext context) {

        context.Response.ContentType = "application/json";

        switch (context.Request.QueryString["action"]) {

            case "createdb":

                bool _success = DBCommand.Create_Database();

                context.Response.Write(new JavaScriptSerializer().Serialize(new _response() {
                    Success = _success
                }));

                break;

            case "checkdb":
                
                 // Save config
                string _conn = context.Request.QueryString["conn"].Replace(";Database=Trello;", string.Empty) + ";Database=Trello;";

                var configuration = WebConfigurationManager.OpenWebConfiguration("~");
                var section = (AppSettingsSection)configuration.GetSection("appSettings");
                section.Settings["DBConnection"].Value = _conn;
                configuration.Save();

                System.Threading.Thread.Sleep(2000);

                context.Response.Write(new JavaScriptSerializer().Serialize(new _response() {
                    Success = DBCommand.Verify_Database_Exists()
                }));

                break;

            default:

                context.Response.Write(new JavaScriptSerializer().Serialize(new _response() {
                    ConnString = WebConfigurationManager.AppSettings["DBConnection"]
                }));

                break;

        }

    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}