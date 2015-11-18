<%@ WebHandler Language="C#" Class="import" %>

using System;
using System.Web;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Configuration;
using System.Reflection;
using System.Collections.Generic;

public class import : IHttpHandler {

    public void ProcessRequest(HttpContext context) {

        context.Response.ContentType = "text/plain";

        // Import the information into the SQL database.
        context.Response.Write(Trello.ImportData());

    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}