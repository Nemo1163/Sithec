using sitech.Models;
using System.Collections.Generic;

namespace sitech.Data
{
    public class HumanData
    {
        public List<HumanModel> ListHuman()
        {

            List<HumanModel> listHuman = new List<HumanModel>()
            {
                new HumanModel()
                { 
                    Id= 1,
                    Name="Carlos Carrillo",
                    Sex = "Hombre",
                    Years = 21,
                    Height = 1.68,
                    Weight = 56.5

                },
                new HumanModel()
                {
                    Id= 2,
                    Name="Jetzibe Betancourt",
                    Sex = "Mujer",
                    Years = 18,
                    Height = 1.70,
                    Weight = 60

                },
                new HumanModel()
                {
                    Id= 3,
                    Name="Eduardo Pech",
                    Sex = "Hombre",
                    Years = 23,
                    Height = 1.70,
                    Weight = 76.2

                }
            };

            return listHuman;

        }
    }
}
