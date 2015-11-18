<%@ WebHandler Language="C#" Class="excel" %>

using System;
using System.Web;

public class excel : IHttpHandler {

    public void ProcessRequest (HttpContext context) {

        string FileName = DateTime.Now.ToString("ddMMyyyyHHmmss");

        context.Response.AddHeader("content-disposition", "inline;filename=" + FileName + @".xls");
        context.Response.ContentType = "application/vnd.xls";

        context.Response.BinaryWrite(Trello.ToExcel());

    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}