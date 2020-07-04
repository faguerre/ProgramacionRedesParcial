using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEMEDEBE.Domain
{
    public class Genre
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Genre()
        {
            Name = "";
            Description = "";
        }
        public override bool Equals(object obj)
        {
            return obj is Genre genre &&
                   this.Name.Equals(genre.Name);
        }

        public override string ToString()
        {
            return $"Name:  {Name} - Description: {Description}";
        }
    }
}
