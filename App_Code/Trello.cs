using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web;

/// <summary>
/// The Trello definition object.
/// </summary>
public class Trello {

    /// <summary>
    /// The Trello board object.
    /// </summary>
    public class Board {

        /// <summary>
        /// Each board has lists.
        /// </summary>
        public class List {

            /// <summary>
            /// Each list has cards.
            /// </summary>
            public class Card {

                /// <summary>
                /// Each card has actions
                /// </summary>
                public class Action {

                    public object id { get; set; }
                    public object idMemberCreator { get; set; }
                    public Data data { get; set; }
                    public object type { get; set; }
                    public object date { get; set; }
                    public Membercreator memberCreator { get; set; }

                    public class Data {
                        public List list { get; set; }
                        public Listafter listAfter { get; set; }
                        public Listbefore listBefore { get; set; }
                        [ScriptIgnore]
                        public Board board { get; set; }
                        [ScriptIgnore]
                        public Card card { get; set; }
                        [ScriptIgnore]
                        public Old old { get; set; }
                        public string text { get; set; }
                    }

                    public class List {
                        public object name { get; set; }
                        public object id { get; set; }
                    }

                    public class Listafter {
                        public object name { get; set; }
                        public object id { get; set; }
                    }

                    public class Listbefore {
                        public object name { get; set; }
                        public object id { get; set; }
                    }

                    public class Board {
                        public object shortLink { get; set; }
                        public object name { get; set; }
                        public object id { get; set; }
                    }

                    public class Card {
                        public object shortLink { get; set; }
                        public object idShort { get; set; }
                        public object name { get; set; }
                        public object id { get; set; }
                        public object idList { get; set; }
                    }

                    public class Old {
                        public object idList { get; set; }
                    }

                    public class Membercreator {
                        public object id { get; set; }
                        public object avatarHash { get; set; }
                        public object fullName { get; set; }
                        public object initials { get; set; }
                        public object username { get; set; }
                    }

                }

                public object id { get; set; }
                [ScriptIgnore]
                public object[] checkItemStates { get; set; }
                public object closed { get; set; }
                public object dateLastActivity { get; set; }
                public object desc { get; set; }
                [ScriptIgnore]
                public Descdata descData { get; set; }
                public object idBoard { get; set; }
                public object idList { get; set; }
                [ScriptIgnore]
                public object[] idMembersVoted { get; set; }
                public object idShort { get; set; }
                public object idAttachmentCover { get; set; }
                public object manualCoverAttachment { get; set; }
                [ScriptIgnore]
                public object[] idLabels { get; set; }
                public object name { get; set; }
                public object pos { get; set; }
                public object shortLink { get; set; }
                [ScriptIgnore]
                public Badges badges { get; set; }
                public object due { get; set; }
                public object email { get; set; }
                [ScriptIgnore]
                public object[] idChecklists { get; set; }
                [ScriptIgnore]
                public object[] idMembers { get; set; }
                public Label[] labels { get; set; }
                public object shortUrl { get; set; }
                public object subscribed { get; set; }
                public object url { get; set; }

                public class Descdata {
                    public Emoji emoji { get; set; }
                }

                public class Emoji {
                }

                public class Badges {
                    public object votes { get; set; }
                    public object viewingMemberVoted { get; set; }
                    public object subscribed { get; set; }
                    public object fogbugz { get; set; }
                    public object checkItems { get; set; }
                    public object checkItemsChecked { get; set; }
                    public object comments { get; set; }
                    public object attachments { get; set; }
                    public object description { get; set; }
                    public object due { get; set; }
                }

                public class Label {
                    public object id { get; set; }
                    public object idBoard { get; set; }
                    public object name { get; set; }
                    public object color { get; set; }
                    public object uses { get; set; }
                }

                public List<Action> Actions;

            }

            public object id { get; set; }
            public object name { get; set; }
            public object closed { get; set; }
            public object idBoard { get; set; }
            public object pos { get; set; }
            public object subscribed { get; set; }
            public List<Card> Cards;

        }

        public object name { get; set; }
        public object desc { get; set; }
        public object descData { get; set; }
        public object closed { get; set; }
        public object idOrganization { get; set; }
        public object pinned { get; set; }
        public object invitations { get; set; }
        public object shortLink { get; set; }
        [ScriptIgnore]
        public object[] powerUps { get; set; }
        public object dateLastActivity { get; set; }
        [ScriptIgnore]
        public object[] idTags { get; set; }
        public object id { get; set; }
        public object invited { get; set; }
        public object starred { get; set; }
        public object url { get; set; }
        [ScriptIgnore]
        public Prefs prefs { get; set; }
        public Membership[] memberships { get; set; }
        public object subscribed { get; set; }
        [ScriptIgnore]
        public Labelnames labelNames { get; set; }
        public object dateLastView { get; set; }
        public object shortUrl { get; set; }

        public class Prefs {
            public object permissionLevel { get; set; }
            public object voting { get; set; }
            public object comments { get; set; }
            public object invitations { get; set; }
            public object selfJoin { get; set; }
            public object cardCovers { get; set; }
            public object cardAging { get; set; }
            public object calendarFeedEnabled { get; set; }
            public object background { get; set; }
            public object backgroundColor { get; set; }
            public object backgroundImage { get; set; }
            public object backgroundImageScaled { get; set; }
            public object backgroundTile { get; set; }
            public object backgroundBrightness { get; set; }
            public object canBePublic { get; set; }
            public object canBeOrg { get; set; }
            public object canBePrivate { get; set; }
            public object canInvite { get; set; }
        }

        public class Labelnames {
            public object green { get; set; }
            public object yellow { get; set; }
            public object orange { get; set; }
            public object red { get; set; }
            public object purple { get; set; }
            public object blue { get; set; }
            public object sky { get; set; }
            public object lime { get; set; }
            public object pink { get; set; }
            public object black { get; set; }
        }

        public class Membership {
            public object id { get; set; }
            public object idMember { get; set; }
            public object memberType { get; set; }
            public object unconfirmed { get; set; }
            public object deactivated { get; set; }
        }

        public List<List> Lists;

    }

    public List<Board> Boards;

    /// <summary>
    /// Parse the information from the directory.
    /// </summary>
    /// <returns></returns>
    public static List<Board> ParseBoardData() {

        string _rootPath = HttpContext.Current.Server.MapPath("") + @"\output\boards";

        List<Board> _boards = new List<Board>();
        DirectoryInfo[] _boardDirs = new DirectoryInfo(_rootPath).GetDirectories();

        foreach (DirectoryInfo _boardDir in _boardDirs) {

            // Board information
            string _boardId = _boardDir.Name;
            string _boardJsonString = File.ReadAllText(_rootPath + @"\" + _boardId + @"\" + _boardId + @".json");

            if (_boardJsonString != null && !string.IsNullOrEmpty(_boardJsonString)) {

                Board _boardInfo = new JavaScriptSerializer().Deserialize<Board>(_boardJsonString);
                _boardInfo.Lists = new List<Board.List>();

                #region LISTS

                if (Directory.Exists(_rootPath + @"\" + _boardId + @"\lists")) {

                    DirectoryInfo[] _listDirs = new DirectoryInfo(_rootPath + @"\" + _boardId + @"\lists").GetDirectories();

                    foreach (DirectoryInfo _listDir in _listDirs) {

                        // List information
                        string _listId = _listDir.Name;
                        string _listJsonString = File.ReadAllText(_rootPath + @"\" + _boardId + @"\lists\" + _listId + @"\" + _listId + @".json");

                        Board.List _listInfo = new JavaScriptSerializer().Deserialize<Board.List>(_listJsonString);
                        _listInfo.Cards = new List<Board.List.Card>();

                        #region CARDS

                        if (Directory.Exists(_rootPath + @"\" + _boardId + @"\lists\" + _listId + @"\cards")) {

                            DirectoryInfo[] _cardDirs = new DirectoryInfo(_rootPath + @"\" + _boardId + @"\lists\" + _listId + @"\cards").GetDirectories();

                            foreach (DirectoryInfo _cardDir in _cardDirs) {

                                // Card information
                                string _cardId = _cardDir.Name;
                                string _cardJsonString = File.ReadAllText(_rootPath + @"\" + _boardId + @"\lists\" + _listId + @"\cards\" + _cardId + @"\" + _cardId + @".json");

                                Board.List.Card _cardInfo = new JavaScriptSerializer().Deserialize<Board.List.Card>(_cardJsonString);
                                _cardInfo.Actions = new List<Board.List.Card.Action>();

                                #region ACTIONS

                                if (Directory.Exists(_rootPath + @"\" + _boardId + @"\lists\" + _listId + @"\cards\" + _cardId + @"\actions")) {

                                    DirectoryInfo[] _actionDirs = new DirectoryInfo(_rootPath + @"\" + _boardId + @"\lists\" + _listId + @"\cards\" + _cardId + @"\actions").GetDirectories();

                                    foreach (DirectoryInfo _actionDir in _actionDirs) {

                                        // Action information
                                        string _actionId = _actionDir.Name;
                                        string _actionJsonString = File.ReadAllText(_rootPath + @"\" + _boardId + @"\lists\" + _listId + @"\cards\" + _cardId + @"\actions\" + _actionId + @"\" + _actionId + @".json");

                                        Board.List.Card.Action _actionInfo = new JavaScriptSerializer().Deserialize<Board.List.Card.Action>(_actionJsonString);

                                        _cardInfo.Actions.Add(_actionInfo);

                                    }

                                }

                                #endregion

                                _listInfo.Cards.Add(_cardInfo);
                            }

                        }

                        #endregion

                        _boardInfo.Lists.Add(_listInfo);

                    }

                }

                #endregion

                _boards.Add(_boardInfo);

            }

        }

        return _boards;

    }

    /// <summary>
    /// Send board data into the database.
    /// </summary>
    /// <param name="Boards"></param>
    /// <returns></returns>
    public static string ImportData() {

        string _logPath = HttpContext.Current.Server.MapPath("") + @"\output\log.txt";
        List<Board> _boards = ParseBoardData();

        // First, let's delete the data.
        DBCommand.Delete_Clear_Database();
        File.WriteAllText(_logPath, "");

        int _imported = 0;
        List<string> _failed = new List<string>();

        foreach (Board _boardInfo in _boards) {

            try {

                #region CREATE THE BOARD

                int _boardID = DBCommand.Board_Insert_New_Board_ReturnBoardID(
                    _boardInfo.id.ToString(),
                    _boardInfo.name.ToString(),
                    _boardInfo.desc.ToString(),
                    (!string.IsNullOrEmpty(_boardInfo.closed.ToString())) ? bool.Parse(_boardInfo.closed.ToString()) : false,
                    (_boardInfo.dateLastActivity != null) ? DateTime.Parse(_boardInfo.dateLastActivity.ToString()) : DateTime.Now,
                    (!string.IsNullOrEmpty(_boardInfo.invited.ToString())) ? bool.Parse(_boardInfo.invited.ToString()) : false,
                    (!string.IsNullOrEmpty(_boardInfo.starred.ToString())) ? bool.Parse(_boardInfo.starred.ToString()) : false,
                    _boardInfo.url.ToString(),
                    _boardInfo.prefs.backgroundImage.ToString(),
                    (_boardInfo.dateLastView != null) ? DateTime.Parse(_boardInfo.dateLastView.ToString()) : DateTime.Now);

                #endregion

                // Now, for that board, add lists etc.
                if (_boardID > 0) {

                    _imported += 1;

                    #region ADD THE MEMBERS, LISTS & CARDS

                    #region ADD BOARD MEMBERSHIPS

                    // First, let's add the ones from the board memberships.
                    foreach (Board.Membership _member in _boardInfo.memberships) {

                        try {

                            int _memberID = DBCommand.Board_Insert_New_Member_ReturnMemberID(
                                _boardID,
                                _member.id.ToString(),
                                _member.idMember.ToString(),
                                _member.memberType.ToString(),
                                string.Empty,
                                string.Empty,
                                string.Empty);

                        } catch (Exception ex) {

                            File.AppendAllText(_logPath, DateTime.Now.ToString(@"ddMMyyyy HH:mm:ss") + " ERROR: Failed to insert member." + Environment.NewLine +
                                "--> Board: " + _boardID.ToString() + Environment.NewLine +
                                "--> Reason: " + ex.Message.ToString() + Environment.NewLine +
                                "--> Trace: " + ex.StackTrace.ToString() + Environment.NewLine +
                                "--> Member ID: " + _member.id.ToString() + Environment.NewLine + Environment.NewLine);

                        }

                    }

                    #endregion

                    // Now, let's go through the actions.
                    if (_boardInfo.Lists.Count > 0) {

                        foreach (Board.List _list in _boardInfo.Lists) {

                            int _listID = 0;

                            #region ADD LIST TO BOARD

                            try {

                                _listID = 0;
                                _listID = DBCommand.Board_Insert_List_ReturnListID(
                                    _boardID,
                                    _list.id.ToString(),
                                    bool.Parse(_list.closed.ToString()),
                                    _list.name.ToString());

                            } catch (Exception ex) {

                                File.AppendAllText(_logPath, DateTime.Now.ToString(@"ddMMyyyy HH:mm:ss") + " ERROR: Failed to create board list." + Environment.NewLine +
                                    "--> Reason: " + ex.Message.ToString() + Environment.NewLine +
                                    "--> Trace: " + ex.StackTrace.ToString() + Environment.NewLine + Environment.NewLine);

                            }

                            #endregion

                            if (_listID > 0 && _list.Cards.Count > 0) {

                                foreach (Board.List.Card _card in _list.Cards) {

                                    int _cardID = 0;

                                    #region INSERT CARD

                                    DateTime _startDate = new DateTime(1970, 01, 01);
                                    _startDate = _startDate.AddSeconds(int.Parse(_card.id.ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));

                                    try {

                                        // Clear card id
                                        _cardID = 0;
                                        _cardID = DBCommand.Board_Insert_Card_ReturnCardID(
                                            _listID,
                                            _boardID,
                                            _card.id.ToString(),
                                            bool.Parse(_card.closed.ToString()),
                                            _card.name.ToString(),
                                            _card.desc.ToString(),
                                            _card.url.ToString(),
                                            _startDate);

                                        #region ASSIGN LIST TO CARD

                                        if (_cardID > 0 && !string.IsNullOrEmpty(_card.idList.ToString())) {

                                            try {

                                                //Add this list as part of the card's history
                                                DBCommand.Board_Insert_Assign_Card_ToList_ReturnID(
                                                    _cardID,
                                                    _card.idList.ToString(),
                                                    string.Empty,
                                                    _startDate);

                                            } catch (Exception ex) {

                                                File.AppendAllText(_logPath, DateTime.Now.ToString(@"ddMMyyyy HH:mm:ss") + " ERROR: Failed to assign card to list." + Environment.NewLine +
                                                    "--> Reason: " + ex.Message.ToString() + Environment.NewLine +
                                                    "--> List ID: " + _card.idList.ToString() + Environment.NewLine +
                                                    "--> Card ID: " + _cardID.ToString() + Environment.NewLine + Environment.NewLine);

                                            }

                                        }

                                        #endregion

                                    } catch (Exception ex) {

                                        File.AppendAllText(_logPath, DateTime.Now.ToString(@"ddMMyyyy HH:mm:ss") + " ERROR: Failed to insert a card." + Environment.NewLine +
                                            "--> Reason: " + ex.Message.ToString() + Environment.NewLine +
                                            "--> Trace: " + ex.StackTrace.ToString() + Environment.NewLine +
                                            "--> List ID: " + _card.idList.ToString() + Environment.NewLine +
                                            "--> Card ID: " + _cardID.ToString() + Environment.NewLine + Environment.NewLine);

                                    }

                                    #endregion

                                    if (_cardID > 0 && _card.Actions.Count > 0) {

                                        foreach (Board.List.Card.Action _action in _card.Actions) {

                                            #region ASSIGN CARD TO LIST (FROM ACTION)

                                            if (_action.data != null) {

                                                try {

                                                    if (_action.data.list != null) {

                                                        //Add this list as part of the card's history
                                                        DBCommand.Board_Insert_Assign_Card_ToList_ReturnID(
                                                            _cardID,
                                                            _action.data.list.id.ToString(),
                                                            _action.idMemberCreator.ToString(),
                                                            DateTime.Parse(_action.date.ToString()));

                                                    }

                                                    if (_action.data.listAfter != null) {

                                                        //Add this list as part of the card's history
                                                        DBCommand.Board_Insert_Assign_Card_ToList_ReturnID(
                                                            _cardID,
                                                            _action.data.listAfter.id.ToString(),
                                                            _action.idMemberCreator.ToString(),
                                                            DateTime.Parse(_action.date.ToString()));

                                                    }

                                                    if (_action.data.listBefore != null) {

                                                        //Add this list as part of the card's history
                                                        DBCommand.Board_Insert_Assign_Card_ToList_ReturnID(
                                                            _cardID,
                                                            _action.data.listBefore.id.ToString(),
                                                            _action.idMemberCreator.ToString(),
                                                            DateTime.Parse(_action.date.ToString()));

                                                    }

                                                } catch (Exception ex) {

                                                    File.AppendAllText(_logPath, DateTime.Now.ToString(@"ddMMyyyy HH:mm:ss") + " ERROR: Failed to assign card to list." + Environment.NewLine +
                                                        "--> Reason: " + ex.Message.ToString() + Environment.NewLine +
                                                        "--> Trace: " + ex.StackTrace.ToString() + Environment.NewLine +
                                                        "--> Card ID: " + _cardID.ToString() + Environment.NewLine + Environment.NewLine);

                                                }

                                            }

                                            #endregion

                                            #region INSERT ACTION

                                            try {

                                                // Associates the action with the card.
                                                DBCommand.Board_Insert_Card_Action_ReturnActionID(
                                                    _cardID,
                                                    _action.id.ToString(),
                                                    _action.idMemberCreator.ToString(),
                                                    _action.type.ToString(),
                                                    _action.data.text,
                                                    DateTime.Parse(_action.date.ToString()));

                                            } catch (Exception ex) {

                                                File.AppendAllText(_logPath, DateTime.Now.ToString(@"ddMMyyyy HH:mm:ss") + " ERROR: Failed to insert action." + Environment.NewLine +
                                                    "--> Reason: " + ex.Message.ToString() + Environment.NewLine +
                                                    "--> Action ID: " + _action.id.ToString() + Environment.NewLine +
                                                    "--> Trace: " + ex.StackTrace.ToString() + Environment.NewLine +
                                                    "--> Member ID: " + _action.idMemberCreator.ToString() + Environment.NewLine + Environment.NewLine);

                                            }

                                            #endregion

                                            #region UPDATE MEMBER INFORMATION FROM ACTION

                                            if (_action.memberCreator != null) {

                                                try {

                                                    int _actionMemberID = DBCommand.Board_Update_Member_ReturnMemberID(
                                                        _action.memberCreator.id.ToString(),
                                                        _action.memberCreator.fullName.ToString(),
                                                        _action.memberCreator.initials.ToString(),
                                                        _action.memberCreator.username.ToString());

                                                } catch (Exception ex) {

                                                    File.AppendAllText(_logPath, DateTime.Now.ToString(@"ddMMyyyy HH:mm:ss") + " ERROR: Failed to update action member." + Environment.NewLine +
                                                        "--> Board: " + _boardID.ToString() + Environment.NewLine +
                                                        "--> Name: " + _action.memberCreator.fullName.ToString() + Environment.NewLine +
                                                        "--> Reason: " + ex.Message.ToString() + Environment.NewLine +
                                                        "--> Trace: " + ex.StackTrace.ToString() + Environment.NewLine +
                                                        "--> Member ID: " + _action.memberCreator.id.ToString() + Environment.NewLine + Environment.NewLine);

                                                }

                                            }

                                            #endregion

                                        }

                                    }

                                }

                            }

                        }

                    }

                    #endregion

                }

            } catch (Exception ex) {

                File.AppendAllText(_logPath, DateTime.Now.ToString(@"ddMMyyyy HH:mm:ss") + " ERROR: Failed to insert board." + Environment.NewLine +
                    "--> Reason: " + ex.Message.ToString() + Environment.NewLine +
                    "--> Trace: " + ex.StackTrace.ToString() + Environment.NewLine +
                    "--> Dump: " + new JavaScriptSerializer().Serialize(_boardInfo) + Environment.NewLine + Environment.NewLine);

            }

        }

        string _message = _imported.ToString() + " of " + _boards.Count.ToString() + @" boards imported.";
        _message += @"<br /><a target=""_blank"" href=""/output/log.txt"">View log</a>";

        return _message;

    }

    /// <summary>
    /// Create an Excel document with a nice breakdown of Trello.
    /// </summary>
    /// <returns></returns>
    public static byte[] ToExcel() {

        List<Board> _boards = ParseBoardData();

        // New workbook
        var workbook = new HSSFWorkbook();

        foreach (Board _boardInfo in _boards) {

            JavaScriptSerializer _worker = new JavaScriptSerializer();
            _worker.MaxJsonLength = int.MaxValue;
            File.WriteAllText(HttpContext.Current.Server.MapPath("") + @"\output\" + _boardInfo.name.ToString() + ".json", _worker.Serialize(_boardInfo));

            // Create a sheet
            var sheet = workbook.CreateSheet(_boardInfo.name.ToString());
            // Kill everything not supposed to be in there.
            var rowIndex = 0;

            #region HEADING STYLE

            HSSFFont _headingFont = (HSSFFont)workbook.CreateFont();
            _headingFont.Boldweight = (short)FontBoldWeight.Bold;
            _headingFont.Color = HSSFColor.Grey80Percent.Index;
            //_headingFont.FontHeight = 280;
            HSSFCellStyle _headingStyle = (HSSFCellStyle)workbook.CreateCellStyle();
            _headingStyle = (HSSFCellStyle)workbook.CreateCellStyle();
            _headingStyle.VerticalAlignment = VerticalAlignment.Center;
            _headingStyle.SetFont(_headingFont);

            #endregion

            // Create the heading
            var row = sheet.CreateRow(rowIndex);
            row.Height = 350;
            HSSFCell cell = (HSSFCell)row.CreateCell(0);
            cell.SetCellValue("Card name");
            cell.CellStyle = _headingStyle;
            cell = (HSSFCell)row.CreateCell(1);
            cell.SetCellValue("Date created");
            cell.CellStyle = _headingStyle;
            cell = (HSSFCell)row.CreateCell(2);
            cell.SetCellValue("Pending");
            cell.CellStyle = _headingStyle;
            cell = (HSSFCell)row.CreateCell(3);
            cell.SetCellValue("In Progress");
            cell.CellStyle = _headingStyle;
            cell = (HSSFCell)row.CreateCell(4);
            cell.SetCellValue("In Testing");
            cell.CellStyle = _headingStyle;
            cell = (HSSFCell)row.CreateCell(5);
            cell.SetCellValue("Released");
            cell.CellStyle = _headingStyle;
            cell = (HSSFCell)row.CreateCell(6);
            cell.SetCellValue("On Hold");
            cell.CellStyle = _headingStyle;
            cell = (HSSFCell)row.CreateCell(7);
            cell.SetCellValue("Description");
            cell.CellStyle = _headingStyle;
            // Next row
            rowIndex++;

            #region ROW STYLE

            HSSFCellStyle _rowStyle = (HSSFCellStyle)workbook.CreateCellStyle();
            _rowStyle.VerticalAlignment = VerticalAlignment.Center;
            IDataFormat _dataFormat = workbook.CreateDataFormat();

            #endregion

            if (_boardInfo.Lists != null) {

                foreach (Board.List _listData in _boardInfo.Lists) {

                    if (_listData.Cards != null) {

                        foreach (Board.List.Card _cardData in _listData.Cards) {

                            // Add the row
                            row = sheet.CreateRow(rowIndex);
                            row.Height = 350;

                            // Card name
                            cell = (HSSFCell)row.CreateCell(0);
                            cell.SetCellValue(_cardData.name.ToString());
                            cell.CellStyle = _rowStyle;

                            // Created
                            cell = (HSSFCell)row.CreateCell(1);
                            DateTime _startDate = new DateTime(1970, 01, 01);
                            cell.SetCellValue(_startDate.AddSeconds(int.Parse(_cardData.id.ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber)).ToString("dd/MM/yyyy HH:mm:ss"));
                            cell.CellStyle = _rowStyle;

                            // Actions
                            foreach (Board.List.Card.Action _actionData in _cardData.Actions) {

                                if (_actionData.data != null) {

                                    if (_actionData.data.listAfter != null && _actionData.data.listAfter.name.ToString().ToLower().Contains("pending")) {

                                        cell = (HSSFCell)row.CreateCell(2);
                                        cell.SetCellValue(DateTime.Parse(_actionData.date.ToString()).ToString("dd/MM/yyyy HH:mm:ss"));
                                        cell.CellStyle = _rowStyle;

                                    } else if (_actionData.data.listAfter != null && _actionData.data.listAfter.name.ToString().ToLower().Contains("progress")) {

                                        cell = (HSSFCell)row.CreateCell(3);
                                        cell.SetCellValue(DateTime.Parse(_actionData.date.ToString()).ToString("dd/MM/yyyy HH:mm:ss"));
                                        cell.CellStyle = _rowStyle;

                                    } else if (_actionData.data.listAfter != null && _actionData.data.listAfter.name.ToString().ToLower().Contains("testing")) {

                                        cell = (HSSFCell)row.CreateCell(4);
                                        cell.SetCellValue(DateTime.Parse(_actionData.date.ToString()).ToString("dd/MM/yyyy HH:mm:ss"));
                                        cell.CellStyle = _rowStyle;

                                    } else if (_actionData.data.listAfter != null && _actionData.data.listAfter.name.ToString().ToLower().Contains("release")) {

                                        cell = (HSSFCell)row.CreateCell(5);
                                        cell.SetCellValue(DateTime.Parse(_actionData.date.ToString()).ToString("dd/MM/yyyy HH:mm:ss"));
                                        cell.CellStyle = _rowStyle;

                                    } else if (_actionData.data.listAfter != null && _actionData.data.listAfter.name.ToString().ToLower().Contains("hold")) {

                                        cell = (HSSFCell)row.CreateCell(6);
                                        cell.SetCellValue(DateTime.Parse(_actionData.date.ToString()).ToString("dd/MM/yyyy HH:mm:ss"));
                                        cell.CellStyle = _rowStyle;

                                    }

                                }

                            }

                            // Description
                            cell = (HSSFCell)row.CreateCell(7);
                            cell.SetCellValue(_cardData.desc.ToString());
                            cell.CellStyle = _rowStyle;

                            // Next row.
                            rowIndex++;

                        }

                    }

                }

                // Size it
                sheet.AutoSizeColumn(0);
                sheet.AutoSizeColumn(1);
                sheet.AutoSizeColumn(2);
                sheet.AutoSizeColumn(3);
                sheet.AutoSizeColumn(4);
                sheet.AutoSizeColumn(5);
                sheet.AutoSizeColumn(6);
                sheet.AutoSizeColumn(7);

                sheet.CreateFreezePane(0, 1);

            }

        }

        #region OUTPUT

        // Save the Excel spreadsheet to a MemoryStream and return it to the client
        using (var exportData = new MemoryStream()) {

            workbook.Write(exportData);
            return exportData.GetBuffer();

        }

        #endregion  

    }

}