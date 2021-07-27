using System;

namespace RestPerson.Data.VO
{

    public class BookVO
    {
        public long Id { get; set; }
        public string Author { get; set; }
        public DateTime LaunchDate { get; set; }
        public Double Price { get; set; }
        public string Title { get; set; }
    }
}
