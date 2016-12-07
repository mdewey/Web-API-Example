using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication4.Models;


namespace WebApplication4.Controllers
{
    public class HomeController : ApiController
    {
        public static List<Person> People { get; set; } = new List<Person>
        {
            new Person { FavoriteMovie = "Goldfinger", Name="Paul" },
            new Person { FavoriteMovie = "Boondock Saints", Name="Ryan" },
            new Person {FavoriteMovie="Death Proof", Name="Uma" }
        };

        [HttpGet]
        public IEnumerable<Person> GetAllPeople()
        {
            return People;
        }

        [HttpGet]
        public IHttpActionResult GetPerson(string name)
        {
            return Ok(People.FirstOrDefault(f => String.Compare(name, f.Name) == 0));
        }
        [HttpPut]
        public Person PutPerson(string name, string movie)
        {
            var p = new Person { Name = name, FavoriteMovie = movie };
            People.Add(p);
            return p;
        }

        [HttpPost]
        public IHttpActionResult PostPeron(Person updated)
        {
            var found = People.FirstOrDefault(f => f.Id == updated.Id);
            if (found == null)
            {
                return NotFound();
            }
            else
            {
                found.Name = updated.Name;
                found.FavoriteMovie = updated.FavoriteMovie;
                return Ok(found);
            }
        }

        [HttpDelete]
        public IHttpActionResult DeletePerson(Guid id)
        {
            People = People.Where(w => w.Id != id).ToList();
            return Ok();
        }




    }
}
