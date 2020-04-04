using Planetgram.Handler;
using Planetgram.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planetgram.ViewModel
{
    public class PlanetViewModel
    {
        public static Planet planet;

        public PlanetViewModel()
        {
            planet = new Planet();
            populatePlanetProperties();
            var planetPopulated = PlanetBuilder.CalculateGeometry(planet.Separators,
                                                                  planet.Radius,
                                                                  planet.Points,
                                                                  planet.TriangleIndices);
            planet = planetPopulated;

        }
        public Planet Planet
        {
            get
            {
                return planet;
            }

            set
            {
                planet = value;
            }
        }
        public void populatePlanetProperties()
        {

            if (planet != null)
            {
                planet.Radius = 65;
                planet.Separators = 7;
            }
            else
                return;
        }
    }
}
