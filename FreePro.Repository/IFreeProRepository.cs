using System.Threading.Tasks;
using FreePro.Domain;

namespace FreePro.Repository
{
    public interface IFreeProRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChanges();

        Task<Meeting[]> GetAllMeetingsByTheme(string theme, bool includeHoster);
        Task<Meeting[]> GetAllMeetings(bool includeHoster);
        Task<Meeting> GetMeetingById(int meetingId, bool includeHoster);

        Task<Hoster> GetHosterById(int hosterId, bool includeMeeting);
        Task<Hoster[]> GetHostersByName(string hosterName, bool includeMeeting);
    }
}