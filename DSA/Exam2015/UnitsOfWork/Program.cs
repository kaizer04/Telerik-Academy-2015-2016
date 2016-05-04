namespace UnitsOfWork
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main()
        {
            var unitOfWork = new UnitOfWork();
            var finalResult = new StringBuilder();

            var line = Console.ReadLine();
            while (line != "end")
            {
                var command = Command.Parse(line);

                switch (command.Name)
                {
                    case "add":
                        var unit = Unit.Parse(command.Arguments);
                        var result = unitOfWork.Add(unit);
                        finalResult.AppendLine(result);
                        
                        break;
                    case "remove":
                        var name = command.Arguments[0];
                        var removeName = unitOfWork.Remove(name);
                        finalResult.AppendLine(removeName);

                        break;
                    case "find":
                        var type = command.Arguments[0];
                        var findByType = unitOfWork.Find(type);
                        if (!findByType.Any())
                        {
                            finalResult.AppendLine(string.Format("RESULT: ", type));
                        }
                        else
                        {
                            finalResult.AppendLine(string.Format("RESULT: {0}", string.Join(", ", findByType)));
                        }

                        break;
                    case "power":
                        var numberOfUnits = int.Parse(command.Arguments[0]);
                        var filteredPower = unitOfWork.Power(numberOfUnits);
                        finalResult.AppendLine(string.Format("RESULT: {0}", string.Join(", ", filteredPower)));

                        break;
                    default:
                        throw new InvalidOperationException();
                }
                
                line = Console.ReadLine();
            }

            Console.WriteLine(finalResult.ToString().Trim());
        }
    }
}
