using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class Actor
    {
        private int actorID;

        public int ActorID
        {
            get { return actorID; }
            set { actorID = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string biography;

        public string Biography
        {
            get { return biography; }
            set { biography = value; }
        }

        private DateTime dateOfBirth;

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

        List<Movie> Filmography = new List<Movie>();

        public Actor(int actorid, string name, string biography, DateTime dob, List<Movie> Filmography)
        {
            this.actorID = actorid;
            this.name = name;
            this.biography = biography;
            this.Filmography = Filmography;
        }

        public void ChangeActor(Actor actor, string changedValue)
        {

        }

        public List<Movie> ViewFilmography (Actor actor)
        {
            return actor.Filmography;
        }
        
    }
}