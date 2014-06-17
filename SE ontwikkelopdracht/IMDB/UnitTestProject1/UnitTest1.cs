using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication2;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFilmography()
        {
            DateTime dob = DateTime.Now;
            System.Collections.Generic.List<string> filmography = new System.Collections.Generic.List<string>();
            System.Collections.Generic.List<string> filmographyResult = new System.Collections.Generic.List<string>();
            filmography.Add("film 1");
            Actor actor = new Actor(5339, "Test", "test", dob, filmography);

            filmographyResult = actor.ViewFilmography(actor);

            Assert.AreEqual(filmography, filmographyResult);
        }

        [TestMethod]
        public void TestLogOnAdmin()
        {
            string username = "Admin";
            string password = "Admin";
            Account acc;

            acc = DatabaseManager.LogIn(username, password);

            Assert.IsNotNull(acc);
        }

        [TestMethod]
        public void TestLogOnUser()
        {
            string username = "Blackroses";
            string password = "Geheim";
            Account acc;

            acc = DatabaseManager.LogIn(username, password);

            Assert.IsNotNull(acc);
        }

        [TestMethod]
        public void TestInsertActor()
        {
            DateTime dob = DateTime.Now;
            int ID = Convert.ToInt32(DatabaseManager.GiveHighestID("ACTEUR"));
            Actor actor = new Actor(ID + 1, "Test", "Test", dob);
            bool succes = false;

            try
            {
                DatabaseManager.InsertActor(actor);
                succes = true;
            }
            catch
            {
                Assert.Fail("Assert failed");
            }

            Assert.IsTrue(succes);
        }

        [TestMethod]
        public void TestInsertMovie()
        {
            Movie next = new Movie();
            int ID = Convert.ToInt32(DatabaseManager.GiveHighestID("FILM"));
            Movie movie = new Movie(ID + 1, "Test", DateTime.Now, "Test", EnumGenre.Adventure, next, next, "null", true, false, true, true, true);
            bool succes = false;

            try
            {
                DatabaseManager.InsertMovie(movie);
                succes = true;
            }
            catch
            {
                Assert.Fail("Assert failed");
            }

            Assert.IsTrue(succes);
        }

        [TestMethod]
        public void TestGetMovieID()
        {
            string title = "Divergent";
            int movieID;
            bool succes = false;

            try
            {
                movieID = DatabaseManager.GiveMovieIDFromTitle(title);
                succes = true;
            }
            catch
            {
                Assert.Fail("Assert failed");
            }

            Assert.IsTrue(succes);
        }

        [TestMethod]
        public void TestGetMovies()
        {
            System.Collections.Generic.List<Movie> movies;

            movies = DatabaseManager.GiveMovies();

            Assert.IsNotNull(movies);
        }

        [TestMethod]
        public void TestGetActors()
        {
            System.Collections.Generic.List<Actor> actors;

            actors = DatabaseManager.GiveActors();

            Assert.IsNotNull(actors);
        }

        [TestMethod]
        public void TestGetGenres()
        {
            System.Collections.Generic.List<String> genres;

            genres = DatabaseManager.GiveGenres();

            Assert.IsNotNull(genres);
        }

        [TestMethod]
        public void TestGetHighestID()
        {
            string type = "ACTEUR";
            string ID = null;

           ID =  DatabaseManager.GiveHighestID(type);

           Assert.IsNotNull(ID);
        }
        
    }
}
