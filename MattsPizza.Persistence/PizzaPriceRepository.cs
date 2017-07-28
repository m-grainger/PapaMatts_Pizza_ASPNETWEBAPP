using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MattsPizza.Persistence
{
    public class PizzaPriceRepository
    {
        public static DTO.PizzaPriceDTO GetPizzaPrices()
        {
            var db = new MattsPizzaDbEntities();
            var prices = db.PizzaPrices.FirstOrDefault();
            var dto = convertToDTO(prices);
            return dto;

        }
        private static DTO.PizzaPriceDTO convertToDTO(PizzaPrice pizzaPrice)
        {
            var dto = new DTO.PizzaPriceDTO();
            //changed pizzaPrice.DTO to simply dto

            dto.SmallSizeCost = pizzaPrice.SmallSizeCost;
            dto.MediumSizeCost = pizzaPrice.MediumSizeCost;
            dto.LargeSizeCost = pizzaPrice.LargeSizeCost;
            dto.ThickCrustCost = pizzaPrice.ThickCrustCost;
            dto.ThinCrustCost = pizzaPrice.ThinCrustCost;
            dto.RegularCrustCost = pizzaPrice.RegularCrustCost;
            dto.SausageCost = pizzaPrice.SausageCost;
            dto.PepperoniCost = pizzaPrice.PepperoniCost;
            dto.OnionsCost = pizzaPrice.OnionsCost;
            dto.GreenPeppersCost = pizzaPrice.GreenPeppersCost;

            return dto;

        }
    }
}
