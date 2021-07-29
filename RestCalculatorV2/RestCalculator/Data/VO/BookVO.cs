using RestPerson.Hypermedia;
using RestPerson.Hypermedia.Abstract;
using System;
using System.Collections.Generic;

namespace RestPerson.Data.VO
{

    public class BookVO : ISupportsHyperMedia
    {
        public long Id { get; set; }
        public string Author { get; set; }
        public DateTime LaunchDate { get; set; }
        public Double Price { get; set; }
        public string Title { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
