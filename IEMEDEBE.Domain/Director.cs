using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEMEDEBE.Domain
{
    public class Director
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Sex { get; set; }
        public string Description { get; set; }

        public Director()
        {
            Name = "";
            Birthday = new DateTime();
            Sex = "";
            Description = "";
        }

        public override bool Equals(object obj)
        {
            return obj is Director director &&
                    this.Name.Equals(((Director)obj).Name);
        }
        public override string ToString()
        {
            return $"Name:  {Name} - Birthday: {Birthday} -  Sex: {Sex} - Description: {Description}";
        }
    }
}
