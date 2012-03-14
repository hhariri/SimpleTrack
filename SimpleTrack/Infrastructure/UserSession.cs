#region License
// My License Info here
// 
// UserSession.cs
// 
#endregion

using System;
using System.Configuration;
using YouTrackSharp.Infrastructure;

namespace SimpleTrack.Infrastructure
{
    public class UserSession : IUserSession
    {
        string _username;
        string _password;
        IConnection _connection;

        public UserSession(string userName, string password)
        {
            _username = userName;
            _password = password;
        }

        public IConnection Connection
        {
            get
            {
                if (_connection != null)
                {
                    if (!_connection.IsAuthenticated && System.Web.HttpContext.Current.Request.IsAuthenticated)
                    {
                        _connection.Authenticate(_username, _password);
                    }
                    return _connection;
                }
                throw new InvalidOperationException("Need to call Authenticate first");
            }
        }

        public string Username
        {
            get { return _username; }
        }

        public string Password
        {
            get { return _password; }
        }

        public void Authenticate()
        {
            _connection = new Connection(ConfigurationManager.AppSettings["YouTrackHost"],
                                         Convert.ToInt32(ConfigurationManager.AppSettings["YouTrackPort"]));

            _connection.Authenticate(_username, _password);
        }

        public void Logout()
        {
            if (_connection != null)
            {
                _connection.Logout();                
            }
        }
    }
}