using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using gld_ap_crud01.Models;

namespace gld_ap_crud01.Controllers
{
    public class PropertiesController : ApiController
    {
        static readonly IPropertyRepository repository = new PropertyRepository();

        public IEnumerable<Property> GetAllProperties()
        {
            return repository.GetAll();
        }

        public Property GetProperty(int id)
        {
            Property item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public IEnumerable<Property> GetPropertiesByCategory(string category)
        {
            return repository.GetAll().Where(
                p => string.Equals(p.category, category, StringComparison.OrdinalIgnoreCase));
        }

        public HttpResponseMessage PostProperty(Property item)
        {
            item = repository.Add(item);
            var response = Request.CreateResponse<Property>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutProperty(int id, Property property)
        {
            property.id = id;
            if (!repository.Update(property))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteProperty(int id)
        {
            Property item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            repository.Remove(id);
        }

    }
}
