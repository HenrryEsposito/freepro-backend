using System.Linq;
using System.Threading.Tasks;
using FreePro.Domain;
using FreePro.Repository;
using Microsoft.EntityFrameworkCore;

namespace FreePro.Repository
{
    public class FreeProRepository : IFreeProRepository
    {
        public FreeProContext _context { get; }
        public FreeProRepository(FreeProContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
           _context.Remove(entity);
        }

        public async Task<bool> SaveChanges()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Meeting[]> GetAllMeetings(bool includeHoster = false)
        {
            IQueryable<Meeting> query = _context.Meetings
                .Include(k => k.Batches)
                .Include(k => k.SocialNetworks);

            if(includeHoster) {
                query = query
                        .Include(k => k.HosterMeetings)
                        .ThenInclude(ek => ek.Hoster);
            }

            query = query.OrderByDescending(k => k.MeetingDate);

            return await query.ToArrayAsync();
        }
        public async Task<Meeting> GetMeetingById(int meetingId, bool includeHoster = false)
        {
            IQueryable<Meeting> query = _context.Meetings
                .Include(k => k.Batches)
                .Include(k => k.SocialNetworks);

            if(includeHoster) {
                query = query
                        .Include(k => k.HosterMeetings)
                        .ThenInclude(ek => ek.Hoster);
            }

            query = query.OrderByDescending(k => k.MeetingDate)
                        .Where(k => k.Id == meetingId);

            return await query.FirstOrDefaultAsync();
        }
        public async  Task<Meeting[]> GetAllMeetingsByTheme(string theme, bool includeHoster = false)
        {
            IQueryable<Meeting> query = _context.Meetings
                .Include(k => k.Batches)
                .Include(k => k.SocialNetworks);

            if(includeHoster) {
                query = query
                        .Include(k => k.HosterMeetings)
                        .ThenInclude(ek => ek.Hoster);
            }

            query = query.OrderByDescending(k => k.MeetingDate)
                        .Where(k => k.Theme.ToLower().Contains(theme.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Hoster> GetHosterById(int hosterId, bool includeMeeting = false)
        {
            IQueryable<Hoster> query = _context.Hosters
                .Include(k => k.SocialNetworks);

            if(includeMeeting) {
                query = query
                        .Include(k => k.HosterMeetings)
                        .ThenInclude(ek => ek.Meeting);
            }

            query = query.OrderBy(k => k.Name)
                        .Where(k => k.Id == hosterId);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Hoster[]> GetHostersByName(string hosterName, bool includeMeeting = false)
        {
            IQueryable<Hoster> query = _context.Hosters
                .Include(k => k.SocialNetworks);

            if(includeMeeting) {
                query = query
                        .Include(k => k.HosterMeetings)
                        .ThenInclude(ek => ek.Meeting);
            }

            query = query.Where(k => k.Name.ToLower().Contains(hosterName.ToLower()));

            return await query.ToArrayAsync();
        }
    }
}