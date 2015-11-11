using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Permissions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Ducks
{
    public class DucksController : ApiController
    {
        [HttpGet]
        public async Task<Duck> GetById(string id)
        {
            if (!Repository.Ducks.ContainsKey(id))
            {
                throw new ArgumentException("Duck doesn't exists");
            }

            return Repository.Ducks[id];
        }

        [HttpGet]
        public async Task<IEnumerable<Duck>> GetAll()
        {
            return Repository.Ducks.Select(kvp => kvp.Value);
        }

        [HttpPost]
        //[AuthorizationFilter]
        public async Task<HttpResponseMessage> Create(Duck duck)
        {
            if (Repository.Ducks.ContainsKey(duck.Name))
            {
                Repository.Ducks[duck.Name] = duck;
                return Request.CreateResponse(HttpStatusCode.Created);
            }

            Repository.Ducks.Add(duck.Name, duck);

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPut]
        [Route("api/ducks/{id}/eggs")]
        public async Task<IEnumerable<Duck>> Hatch(string id)
        {
            if (!Repository.Ducks.ContainsKey(id))
            {
                throw new ArgumentException("Duck doesn't exists");
            }

            var duck = Repository.Ducks[id];
            var children = new List<Duck>();
            for (var i = 0; i < duck.EggsCount; i++)
            {
                var child = new Duck()
                {
                    Name = duck.Name + i,
                    Color = duck.Color
                };
                children.Add(child);
                Repository.Ducks.Add(child.Name, child);
            }

            return children;
        }

        //[HttpPost]
        //public async Task<HttpResponseMessage> Create(CreateDuckRequest request)
        //{
        //    Repository.RequestsDucks.Add(request.Id, request.Duck);
        //    if(Repository.RequestsDucks.Select(kvp => kvp))
        //    {
                
        //    }
        //}

        [HttpPut]
        public async Task Update(Duck duck)
        {
            if (!Repository.Ducks.ContainsKey(duck.Name))
            {
                throw new ArgumentException("Duck doesn't exists");
            }

            Repository.Ducks[duck.Name] = duck;
        }

        [HttpDelete]
        public async Task Delete(string id)
        {
            if (!Repository.Ducks.ContainsKey(id))
            {
                throw new ArgumentException("Duck doesn't exists");
            }

            Repository.Ducks.Remove(id);
        }
    }
}