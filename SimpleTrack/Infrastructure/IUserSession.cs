using YouTrackSharp.Infrastructure;

namespace SimpleTrack.Infrastructure
{
    public interface IUserSession
    {
        IConnection Connection { get; }
        string Username { get; }
        void Authenticate();
        void Logout();
    }
}