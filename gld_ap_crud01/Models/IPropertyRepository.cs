using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gld_ap_crud01.Models
{
    public interface IPropertyRepository
    {
        IEnumerable<Property> GetAll();
        Property Get(int id);
        Property Add(Property item);
        void Remove(int id);
        bool Update(Property item);
    }
}
