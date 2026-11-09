using part_2API.backend;
using System.Xml.Linq;

namespace part3_poe.Api_backendRequestor
{
    public class add_category
    {




        public string add_categories(string name, string description, int organizer_id)
        {



            manage_categories categories_manager = new manage_categories();

            return categories_manager.store_categorySite(name , description , organizer_id);


        }

        public string delete_categories(int id, int organizer_id)
        {
            manage_categories categories_manager = new manage_categories();

            return categories_manager.deleting_categoriesSite(id, ""+ organizer_id);

        }

        public string update_categories(int id, string name, string description, int organizer_id)
        {

            manage_categories categories_manager = new manage_categories();

            return categories_manager.updating_categoriesSite(id, name, description, ""+organizer_id, "both");

        }
    }
}
