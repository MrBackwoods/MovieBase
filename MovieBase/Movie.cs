using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase
{
    class Movie
    {
        // Object Movie has private variables and also getters and setters for those
        private int id;
        private string name;
        private string director;
        private string releaseYear;
        private string note;
        private int review;
        
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Director
        {
            get { return director; }
            set { director = value; }
        }

        public string ReleaseYear
        {
            get { return releaseYear; }
            set { releaseYear = value; }
        }

        public int Review
        {
            get { return review; }
            set { review = value; }
        }

        public string Note
        {
            get { return note; }
            set { note = value; }
        }
    }
}
