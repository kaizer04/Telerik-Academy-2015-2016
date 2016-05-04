namespace OnlineMarket
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
            var superMarket = new Supermarket();
            var finalResult = new StringBuilder();

            var line = Console.ReadLine();
            while (line != "end")
            {
                var command = Command.Parse(line);

                switch (command.Name)
                {
                    case "add":
                        var product = Product.Parse(command.Arguments);
                        var result = superMarket.Add(product);
                        finalResult.AppendLine(result);
                        break;

                    case "filter":

                        switch (command.Arguments[1])
	                    {
                            case "type":
                                var type = command.Arguments[2];
                                var filterByType = superMarket.FilterByType(type);
                                if (!filterByType.Any())
                                {
                                    finalResult.AppendLine(string.Format("Error: Type {0} does not exists", type));
                                }
                                else
                                {
                                    finalResult.AppendLine(string.Format("Ok: {0}", string.Join(", ", filterByType)));
                                }
                                
                                break;

                            case "price":
                                var minPrice = 0.0;
                                var maxPrice = double.MaxValue;

                                // from and to toghether
                                if (command.Arguments.Count > 4)
                                {
                                    minPrice = double.Parse(command.Arguments[3]);
                                    maxPrice = double.Parse(command.Arguments[5]);
                                }
                                // only to
                                else if (command.Arguments[2] == "to")
                                {
                                    maxPrice = double.Parse(command.Arguments[3]);
                                }
                                else
	                            {
                                    minPrice = double.Parse(command.Arguments[3]);
	                            }

                                var filteredPrice = superMarket.FilterByPrice(minPrice, maxPrice);
                                finalResult.AppendLine(string.Format("Ok: {0}", string.Join(", ", filteredPrice)));

                                break;

		                    default:
                                throw new InvalidOperationException();
	                    }
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
