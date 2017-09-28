using DapperExtensions.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comic.Data.Models
{
    public class ComicBook : EntityBase 
    {
        public double IssueNumber { get; set; }
        public string ThumbnailImage { get; set; }
        
        //Todo: Add Ability to Add Multiple Characters and Creators associated to Comicbook

      //  public List<Character> Characters { get; set; }
      //  public List<Creator> Creators { get; set; }

        public class ComicBookMapper : ClassMapper<ComicBook>
        {
            public ComicBookMapper()
            {
                Table("Comic");
            //    Map(m => m.Characters).Ignore();
            //    Map(m => m.Creators).Ignore();
                AutoMap();
            }
        }
    }
}
