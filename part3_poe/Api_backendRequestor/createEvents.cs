using part_2API.backend;

namespace part3_poe.Api_backendRequestor
{
    public class createEvents
    {
        public string add_event(string eventName, string description, DateTime date, string location, decimal distance, string eventType, int age, TimeSpan startTime, int user_id, int category_id, string image)
        {





            //store_eventSite(string eventName, string description, DateTime? date, string location, decimal? distance, string eventType,
            //int? age, TimeSpan? startTime, int? category_id, string image, int organizer_id)


            manage_events store = new manage_events();

            return store.store_eventSite( eventName,  description,  date,  location,   distance,  eventType,age, startTime,  category_id,  image, user_id);


        }


    }
}
