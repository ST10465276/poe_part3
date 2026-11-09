using part3_poe.Models;

namespace part3_poe.Api_backendRequestor
{
    public class FindMarathon
    {
        public List<Category> Categories { get; set; }
        public List<get_viewEvents> Events { get; set; }

        public FindMarathon()
        {
            Categories = new List<Category>
            {
                new Category { Id = 1, Name = "10km", Description = "A 10 kilometre road race open to all runners.", OrganizerId = 1 },
                new Category { Id = 2, Name = "21km", Description = "Half marathon distance for experienced runners.", OrganizerId = 1 },
                new Category { Id = 3, Name = "42km", Description = "Full marathon distance for elite runners.", OrganizerId = 1 },
                new Category { Id = 4, Name = "5km Fun Run", Description = "A relaxed 5km run for families and first-timers.", OrganizerId = 2 }
            };


            Events = new List<get_viewEvents>
            {
                new get_viewEvents { EventID = 1, EventName = "Johannesburg City Marathon", Description = "A full city marathon through the heart of Johannesburg, with routes for every level and categories for all age groups.", Date = new DateTime(2026, 6, 12), Location = "Johannesburg CBD", Distance = 42.00m, EventType = "Marathon", Age = 18, StartTime = new TimeSpan(6, 0, 0), UserId = 1, CategoryId = 3, CategoryName = "42km", JoinedCount = 1240 },
                new get_viewEvents { EventID = 2, EventName = "Sandton Half Marathon", Description = "A fast half marathon through Sandton with three categories and a route designed for personal bests.", Date = new DateTime(2026, 8, 3), Location = "Sandton", Distance = 21.00m, EventType = "Half Marathon", Age = 16, StartTime = new TimeSpan(7, 0, 0), UserId = 1, CategoryId = 2, CategoryName = "21km", JoinedCount = 860 },
                new get_viewEvents { EventID = 3, EventName = "Spring Fun Run", Description = "A relaxed 10km run open to everyone, perfect for first-timers and families looking for a weekend race.", Date = new DateTime(2026, 9, 21), Location = "Rosebank", Distance = 10.00m, EventType = "Fun Run", Age = 12, StartTime = new TimeSpan(8, 0, 0), UserId = 2, CategoryId = 1, CategoryName = "10km", JoinedCount = 420 },
                new get_viewEvents { EventID = 4, EventName = "Rosebank Night Run", Description = "An evening run through Rosebank with lit routes and a 5km and 10km category to choose from.", Date = new DateTime(2026, 11, 14), Location = "Rosebank", Distance = 10.00m, EventType = "Night Run", Age = 14, StartTime = new TimeSpan(18, 0, 0), UserId = 2, CategoryId = 1, CategoryName = "10km", JoinedCount = 310 },
                new get_viewEvents { EventID = 5, EventName = "Soweto Marathon", Description = "A community marathon through Soweto with a 10km, 21km, and 42km category open to all runners.", Date = new DateTime(2026, 7, 5), Location = "Soweto", Distance = 42.00m, EventType = "Marathon", Age = 18, StartTime = new TimeSpan(5, 30, 0), UserId = 1, CategoryId = 3, CategoryName = "42km", JoinedCount = 2100 },
                new get_viewEvents { EventID = 6, EventName = "Pretoria Capital Run", Description = "A scenic run through the capital with a flat route ideal for first-time half marathoners.", Date = new DateTime(2026, 7, 19), Location = "Pretoria", Distance = 21.00m, EventType = "Half Marathon", Age = 16, StartTime = new TimeSpan(6, 30, 0), UserId = 1, CategoryId = 2, CategoryName = "21km", JoinedCount = 740 },
                new get_viewEvents { EventID = 7, EventName = "Durban Beach Run", Description = "A coastal 10km along the Durban beachfront with ocean views the whole way.", Date = new DateTime(2026, 8, 2), Location = "Durban Beachfront", Distance = 10.00m, EventType = "Fun Run", Age = 12, StartTime = new TimeSpan(7, 0, 0), UserId = 2, CategoryId = 1, CategoryName = "10km", JoinedCount = 560 },
                new get_viewEvents { EventID = 8, EventName = "Cape Town Trail Run", Description = "A trail run up Table Mountain with two distances and stunning views from the top.", Date = new DateTime(2026, 8, 23), Location = "Cape Town", Distance = 15.00m, EventType = "Trail Run", Age = 18, StartTime = new TimeSpan(6, 0, 0), UserId = 2, CategoryId = 2, CategoryName = "21km", JoinedCount = 390 },
                new get_viewEvents { EventID = 9, EventName = "Centurion Night Race", Description = "A floodlit evening race through Centurion with 5km and 15km categories.", Date = new DateTime(2026, 10, 11), Location = "Centurion", Distance = 15.00m, EventType = "Night Run", Age = 14, StartTime = new TimeSpan(18, 30, 0), UserId = 1, CategoryId = 4, CategoryName = "5km Fun Run", JoinedCount = 280 },
                new get_viewEvents { EventID = 10, EventName = "Midrand Charity Run", Description = "A charity 10km supporting local schools, with a family category and a kids race.", Date = new DateTime(2026, 10, 25), Location = "Midrand", Distance = 10.00m, EventType = "Charity Run", Age = 10, StartTime = new TimeSpan(7, 0, 0), UserId = 2, CategoryId = 1, CategoryName = "10km", JoinedCount = 640 },
                new get_viewEvents { EventID = 11, EventName = "Roodepoort Hill Run", Description = "A challenging hill run with a steep 8km route for runners looking for elevation.", Date = new DateTime(2026, 11, 8), Location = "Roodepoort", Distance = 8.00m, EventType = "Hill Run", Age = 16, StartTime = new TimeSpan(6, 0, 0), UserId = 2, CategoryId = 4, CategoryName = "5km Fun Run", JoinedCount = 210 },
                new get_viewEvents { EventID = 12, EventName = "Benoni Summer Run", Description = "A summer evening 10km with a fast flat route and a 5km fun category for families.", Date = new DateTime(2026, 12, 6), Location = "Benoni", Distance = 10.00m, EventType = "Fun Run", Age = 12, StartTime = new TimeSpan(17, 0, 0), UserId = 1, CategoryId = 1, CategoryName = "10km", JoinedCount = 480 }
            };


        }
    }
}