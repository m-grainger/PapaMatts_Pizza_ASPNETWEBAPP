using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MattsPizza.DTO;
using System.Data.Entity;

namespace MattsPizza.Domain
{
    public class PizzaPriceManager
    {
        public static decimal CalculateCost(DTO.OrderDTO order)
        {
            decimal cost= 0.0m;
            var prices = getPizzaPrices();

            cost += calculateSizeCost(order, prices);
            cost += calculateCrustCost(order, prices);
            cost += calculateToppings(order, prices);

            return cost;
        }

        private static decimal calculateToppings(OrderDTO order, DTO.PizzaPriceDTO prices)
        {
            decimal cost = 0.0m;

            cost += (order.Sausage) ? prices.SausageCost : 0m;
            cost += (order.Pepperoni) ? prices.PepperoniCost : 0m;
            cost += (order.Onions) ? prices.OnionsCost : 0m;
            cost += (order.GreenPeppers) ? prices.GreenPeppersCost : 0m;

            return cost;

        }

        private static decimal calculateCrustCost(OrderDTO order, DTO.PizzaPriceDTO prices)
        {
            decimal cost = 0.0m;

            switch (order.Crust)
            {
                case DTO.Enums.CrustType.Regular:
                    cost = prices.RegularCrustCost;
                    break;
                case DTO.Enums.CrustType.Thin:
                    cost = prices.ThinCrustCost;
                    break;
                case DTO.Enums.CrustType.Thick:
                    cost = prices.ThinCrustCost;
                    break;
                default:
                    break;

            }
            return cost;
        }

        private static decimal calculateSizeCost(OrderDTO order, DTO.PizzaPriceDTO prices)
        {
            decimal cost = 0.0m;

            switch (order.Size)
            {
                case DTO.Enums.SizeType.Small:
                    cost = prices.SmallSizeCost;
                    break;
                case DTO.Enums.SizeType.Medium:
                    cost = prices.MediumSizeCost;
                    break;
                case DTO.Enums.SizeType.Large:
                    cost = prices.LargeSizeCost;
                    break;
                default:
                    break;
            }

            return cost;
        }

        private static DTO.PizzaPriceDTO getPizzaPrices()
        {
           var prices =  Persistence.PizzaPriceRepository.GetPizzaPrices();
           return prices;
        }
    }
}
