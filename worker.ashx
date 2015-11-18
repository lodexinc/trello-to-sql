<%@ WebHandler Language="C#" Class="worker" %>

using System;
using System.Web;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Configuration;
using System.Reflection;
using System.Collections.Generic;

public class worker : IHttpHandler {

    /// <summary>
    /// Application path
    /// </summary>
    string _rootPath = string.Empty;

    public void ProcessRequest(HttpContext context) {

        context.Response.ContentType = "text/html";

        _rootPath = context.Server.MapPath("");

        string sURL = "https://api.trello.com/1/members/me/boards?key=" + ConfigurationManager.AppSettings["APIKey"] + "&token=" + context.Request.QueryString["token"];
        WebClient web = new WebClient();
        string _resultStr = web.DownloadString(sURL);
        object[] _boardArr = new JavaScriptSerializer().Deserialize<object[]>(_resultStr);

        int _boards = 0;
        int _newBoards = 0;

        try {

            _boards = _boardArr.Length;

            for (int i = 0, il = _boardArr.Length; i < il; i++) {

                object _tempObj = _boardArr[i];
                Dictionary<string, object> _tempDic = (Dictionary<string, object>)_tempObj;

                if (_tempDic["id"] != null) {

                    string _boardId = _tempDic["id"].ToString();

                    if (!Directory.Exists(_rootPath + @"\output\boards\" + _boardId)) {

                        _newBoards += 1;

                        Directory.CreateDirectory(_rootPath + @"\output\boards\" + _boardId);
                        File.WriteAllText(_rootPath + @"\output\boards\" + _boardId + @"\" + _boardId + @".json", new JavaScriptSerializer().Serialize(_tempObj));

                        // Create the lists directory structure.
                        BuildLists(context.Request.QueryString["token"], _boardId);

                    }

                }

            }

            if (_newBoards == 0) {
                context.Response.Write("No new boards detected. Delete your current boards for a fresh download.");
            } else {
                context.Response.Write("Created " + _newBoards + @" new board" + ((_newBoards == 1) ? string.Empty : "s") + @" and downloaded their data.");
            }

            context.Response.Write(@"<a target=""_blank"" href=""/output/boards/" + @"""><br />Open downloads</a>");

        } catch (Exception ex) {

            context.Response.Write(@"<br /><br />ERROR:<br />" + ex.Message + @"<br /><br />" + ex.StackTrace);

        }

    }

    public void BuildLists(string token, string boardId) {

        System.Threading.Thread.Sleep(20);

        // Get lists
        WebClient web = new WebClient();
        string sURL = "https://api.trello.com/1/boards/" + boardId + @"/lists/all/?key=" + ConfigurationManager.AppSettings["APIKey"] + "&token=" + token;
        string _resultStr = web.DownloadString(sURL);
        object[] _listsArr = new JavaScriptSerializer().Deserialize<object[]>(_resultStr);

        for (int y = 0, yl = _listsArr.Length; y < yl; y++) {

            object _tempList = _listsArr[y];
            Dictionary<string, object> _tempListDic = (Dictionary<string, object>)_tempList;

            if (_tempListDic["id"] != null) {

                string _listId = _tempListDic["id"].ToString();

                if (!Directory.Exists(_rootPath + @"\output\boards\" + boardId + @"\lists\" + _listId)) {

                    Directory.CreateDirectory(_rootPath + @"\output\boards\" + boardId + @"\lists\" + _listId);
                    File.WriteAllText(_rootPath + @"\output\boards\" + boardId + @"\lists\" + _listId + @"\" + _listId + @".json", new JavaScriptSerializer().Serialize(_tempList));

                    // Get cards
                    BuildCards(token, boardId, _listId);

                }

            }

        }

    }

    public void BuildCards(string token, string boardId, string listId) {

        System.Threading.Thread.Sleep(20);

        // Get cards
        WebClient web = new WebClient();
        string sURL = "https://api.trello.com/1/lists/" + listId + @"/cards/all/?key=" + ConfigurationManager.AppSettings["APIKey"] + "&token=" + token;
        string _resultStr = web.DownloadString(sURL);
        object[] _cardsArr = new JavaScriptSerializer().Deserialize<object[]>(_resultStr);

        for (int y = 0, yl = _cardsArr.Length; y < yl; y++) {

            object _tempCard = _cardsArr[y];
            Dictionary<string, object> _tempCardDic = (Dictionary<string, object>)_tempCard;

            if (_tempCardDic["id"] != null) {

                string _cardId = _tempCardDic["id"].ToString();

                if (!Directory.Exists(_rootPath + @"\output\boards\" + boardId + @"\lists\" + listId + @"\cards\" + _cardId)) {

                    Directory.CreateDirectory(_rootPath + @"\output\boards\" + boardId + @"\lists\" + listId + @"\cards\" + _cardId);
                    File.WriteAllText(_rootPath + @"\output\boards\" + boardId + @"\lists\" + listId + @"\cards\" + _cardId + @"\" + _cardId + @".json", new JavaScriptSerializer().Serialize(_tempCard));

                    // Get actions
                    BuildActions(token, boardId, listId, _cardId);

                }

            }

        }

    }

    public void BuildActions(string token, string boardId, string listId, string cardId) {

        System.Threading.Thread.Sleep(20);

        // Get actions
        WebClient web = new WebClient();
        string sURL = "https://api.trello.com/1/cards/" + cardId + @"/actions/?key=" + ConfigurationManager.AppSettings["APIKey"] + "&token=" + token;
        string _resultStr = web.DownloadString(sURL);
        object[] _actionsArr = new JavaScriptSerializer().Deserialize<object[]>(_resultStr);

        for (int y = 0, yl = _actionsArr.Length; y < yl; y++) {

            object _tempAction = _actionsArr[y];
            Dictionary<string, object> _tempActionDic = (Dictionary<string, object>)_tempAction;

            if (_tempActionDic["id"] != null) {

                string _actionId = _tempActionDic["id"].ToString();

                if (!Directory.Exists(_rootPath + @"\output\boards\" + boardId + @"\lists\" + listId + @"\cards\" + cardId + @"\actions\" + _actionId)) {

                    Directory.CreateDirectory(_rootPath + @"\output\boards\" + boardId + @"\lists\" + listId + @"\cards\" + cardId + @"\actions\" + _actionId);
                    File.WriteAllText(_rootPath + @"\output\boards\" + boardId + @"\lists\" + listId + @"\cards\" + cardId + @"\actions\" + _actionId + @"\" + _actionId + @".json", new JavaScriptSerializer().Serialize(_tempAction));

                }

            }

        }

    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}