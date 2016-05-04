namespace UnitsOfWork
{
    using System;
    using System.Collections.Generic;

    public class Unit : IComparable<Unit>
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public int Attack { get; set; }

        public static Unit Parse(IList<string> units)
        {
            return new Unit
            {
                Name = units[0],
                Type = units[1],
                Attack = int.Parse(units[2])
            };
        }

        public int CompareTo(Unit other)
        {
            var result = this.Attack.CompareTo(other.Attack);
            if (result == 0)
            {
                result = this.Name.CompareTo(other.Name);
            }

            return result;
        }

        public override string ToString()
        {
            return string.Format("{0}[{1}]({2})", this.Name, this.Type, this.Attack);
        }
    }
}
