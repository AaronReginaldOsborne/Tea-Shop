using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaShop
{
    // a way to store data normal it would be in a database but is okay
    public class TeaList
    {
        private List<Tea> Teas = null;
        private Tea returndTea = null;
        public TeaList()
        {
            Teas = new List<Tea>();
            populate();
        }

        private void populate()
        {
            Tea BlackTea = new Tea
            {
                Name = Properties.Resources.blacktea,
                Description = Properties.Resources.blackteadesc,
                Cost = 1.25,
                Image = "assests/black.jpg"
            };
            Teas.Add(BlackTea);

            Tea CamomileTea = new Tea
            {
                Name = Properties.Resources.camomiletea,
                Description = Properties.Resources.camomileteadesc,
                Cost = 4.57,
                Image = "assests/camomile.jpg"
            };
            Teas.Add(CamomileTea);

            Tea CoffTea = new Tea
            {
                Name = Properties.Resources.coffteatea,
                Description = Properties.Resources.coffteateadesc,
                Cost = 2.10,
                Image = "assests/cofftea.jpg"
            };
            Teas.Add(CoffTea);

            Tea earlgray = new Tea
            {
                Name = Properties.Resources.earlgraytea,
                Description = Properties.Resources.earlgrayteadesc,
                Cost = 4.50,
                Image = "assests/earlgray.jpg"
            };
            Teas.Add(earlgray);

            Tea greenTea = new Tea
            {
                Name = Properties.Resources.greentea,
                Description = Properties.Resources.greenteadesc,
                Cost = 3.28,
                Image = "assests/green.jpg"
            };
            Teas.Add(greenTea);

            Tea herbalTea = new Tea
            {
                Name = Properties.Resources.herbaltea,
                Description = Properties.Resources.herbalteadesc,
                Cost = 3.10,
                Image = "assests/herbal.jpg"
            };
            Teas.Add(herbalTea);

            Tea HoneyLemonTea = new Tea
            {
                Name = Properties.Resources.honeylemontea,
                Description = Properties.Resources.honeylemonteadesc,
                Cost = 2.97,
                Image = "assests/honey-lemon.jpg"
            };
            Teas.Add(HoneyLemonTea);

            Tea MasalaTea = new Tea
            {
                Name = Properties.Resources.masalatea,
                Description = Properties.Resources.masalateadesc,
                Cost = 8.99,
                Image = "assests/masala.jpg"
            };
            Teas.Add(MasalaTea);

            Tea OolongTea = new Tea
            {
                Name = Properties.Resources.oolongtea,
                Description = Properties.Resources.oolongteadesc,
                Cost = 7.20,
                Image = "assests/oolong.png"
            };
            Teas.Add(OolongTea);

            Tea WhiteTea = new Tea
            {
                Name = Properties.Resources.whitetea,
                Description = Properties.Resources.whiteteadesc,
                Cost = 13.76,
                Image = "assests/white.jpg"
            };
            Teas.Add(WhiteTea);
        }

        public int Length()
        {
            return Teas.Count();
        }
        public Tea GetTea (int Index)
        {
            returndTea = Teas[Index];
            return returndTea;
        }
    }
}
