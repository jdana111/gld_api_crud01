using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gld_ap_crud01.Models
{
    public class PropertyRepository : IPropertyRepository
    {
        private List<Property> propertys = new List<Property>();
        private int _nextId = 1;

        public PropertyRepository()
        {
            Add(new Property { name = "House of Crud", category = "Retail", street_name = "Washington Street" });
            Add(new Property { name = "Flea-Bag Automotive", category = "Automotive", street_name = "4th Street" });
            Add(new Property { name = "Scary Dentist", category = "Densistry", street_name = "Highway 93" });
        }

        public IEnumerable<Property> GetAll()
        {
            return propertys;
        }

        public Property Get(int id)
        {
            return propertys.Find(p => p.id == id);
        }

        public Property Add(Property item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.id = _nextId++;
            propertys.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            propertys.RemoveAll(p => p.id == id);
        }

        public bool Update(Property item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = propertys.FindIndex(p => p.id == item.id);
            if (index == -1)
            {
                return false;
            }
            propertys.RemoveAt(index);
            propertys.Add(item);
            return true;
        }
    }
}