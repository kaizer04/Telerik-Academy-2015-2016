namespace UnitsOfWork
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UnitOfWork
    {
        private IDictionary<string, SortedSet<Unit>> unitsByType;
        private IDictionary<int, SortedSet<Unit>> unitsByAttack;
        private ISet<string> unitNames;
        private SortedSet<int> allAttacks;

        public UnitOfWork()
        {
            this.unitsByType = new Dictionary<string, SortedSet<Unit>>();
            this.unitNames = new HashSet<string>();
            this.unitsByAttack = new SortedDictionary<int, SortedSet<Unit>>();
            this.allAttacks = new SortedSet<int>();
        }

        public string Add(Unit unit)
        {
            // check unique names
            if (unitNames.Contains(unit.Name))
            {
                return string.Format("FAIL: {0} already exists!", unit.Name);
            }

            this.unitNames.Add(unit.Name);

            // add by type
            if (!unitsByType.ContainsKey(unit.Type))
            {
                unitsByType[unit.Type] = new SortedSet<Unit>();
            }

            this.unitsByType[unit.Type].Add(unit);

            // add by attack
            this.allAttacks.Add(unit.Attack);

            if (!this.unitsByAttack.ContainsKey(unit.Attack))
            {
                this.unitsByAttack[unit.Attack] = new SortedSet<Unit>();
            }

            this.unitsByAttack[unit.Attack].Add(unit);
            
            return string.Format("SUCCESS: {0} added!", unit.Name);
        }

        public IEnumerable<Unit> Find(string type)
        {
            if (!this.unitsByType.ContainsKey(type))
            {
                return Enumerable.Empty<Unit>();
            }

            return this.unitsByType[type].OrderByDescending(u => u.Attack).Take(10);
        }

        public IEnumerable<Unit> Power(int numberOfUnits)
        {

            var powers = new List<int>();

            for (int i = 0; i < numberOfUnits; i++)
            {
                powers[i] = this.allAttacks.Last() - i;
            }

            var filteredUnits = new HashSet<Unit>();
            var taken = 0;

            foreach (var power in powers)
            {
                foreach (var unit in this.unitsByAttack[power])
                {
                    if (taken == numberOfUnits)
                    {
                        return filteredUnits;
                    }

                    filteredUnits.Add(unit);
                    taken++;
                }
            }


            return filteredUnits;
        }

        public string Remove(string name)
        {
            if (!unitNames.Contains(name))
            {
                return string.Format("FAIL: {0} could not be found!", name);
            }

            this.unitNames.Remove(name);

            Unit removeUnit = null;
            foreach (var unit in unitsByType)
	        {
                foreach (var u in unit.Value)
                {
                    if (u.Name == name)
                    {
                        removeUnit = u;
                        break;
                    }
                }
	        }

            this.unitsByType[removeUnit.Type].Remove(removeUnit);

            this.unitsByAttack[removeUnit.Attack].Remove(removeUnit);

            //this.allAttacks.RemoveWhere(a => a == removeUnit.Attack);

            return string.Format("SUCCESS: {0} removed!", removeUnit.Name);
        }
    }
}
