using System;
using System.IO;
using System.Collections.Generic;

namespace day6
{
    class Program
    {

        static void Main(string[] args)
        {
            Array allOrbitData = File.ReadAllLines("test.txt");
            Dictionary<string, Planet> allPlanets = new Dictionary<string, Planet>();
            int numberOfOrbits = 0;
            
            foreach(string orbitData in allOrbitData)
            {
                var parsedPlanets = OrbitParser(orbitData);
                Planet planet = new Planet(parsedPlanets[1].ToString(), parsedPlanets[0].ToString());
                
                if(!allPlanets.ContainsKey(planet.Name))
                {
                    allPlanets[planet.Name] = planet;
                }
            }
            /*
            Planet planetYOU = GetPlanetObjectFromName(allPlanets, "YOU");
            Planet planetSAN = GetPlanetObjectFromName(allPlanets, "SAN");

            Planet planetYOUAreOrbiting = GetPlanetObjectFromName(allPlanets, planetYOU.Orbiting);
            Planet planetSANIsOrbiting = GetPlanetObjectFromName(allPlanets, planetSAN.Orbiting);
            
            int orbitsFromYOU = FindAllOrbitsForPlanet(allPlanets, planetYOUAreOrbiting);
            int orbitsFromSAN = FindAllOrbitsForPlanet(allPlanets, planetSANIsOrbiting);

            Console.WriteLine("OrbitsFromYOU: {0}", orbitsFromYOU);
            Console.WriteLine("OrbitsFromSAN: {0}", orbitsFromSAN);
            numberOfOrbits = orbitsFromYOU - orbitsFromSAN;
            */
            foreach(var planet in allPlanets)
            {
                numberOfOrbits = countAllOrbits(allPlanets, planet.Value);
            }
            Console.WriteLine("Orbit Difference: {0}", numberOfOrbits);
        }

        static int countAllOrbits(Dictionary<string, Planet> allPlanets, Planet planet)
        {
            if(planet.Orbiting != null)
            {
                return 1;
            }
            else
            {
                return 1 + countAllOrbits(allPlanets, GetPlanetObjectFromName(allPlanets, planet.Orbiting));
            }
        }

        static int FindAllOrbitsForPlanet(Dictionary<string, Planet> allPlanets, Planet planet)
        {
                Console.WriteLine("Planet: {0}", planet.Name);
                Planet orbitingPlanet = GetPlanetObjectFromName(allPlanets, planet.Orbiting);
                int innerOrbit = 0;
                if(string.Equals(planet.Orbiting, "COM"))
                {
                    innerOrbit++;
                }
                while(orbitingPlanet != null )
                {
                    Console.WriteLine("Orbiting Name: {0}", orbitingPlanet.Name);
                    innerOrbit++;
                    Console.WriteLine("While Inner Orbit: {0}", innerOrbit);
                    if(string.Equals(orbitingPlanet.Orbiting, "COM"))
                    {
                        innerOrbit++;
                    }
                    orbitingPlanet = GetPlanetObjectFromName(allPlanets, orbitingPlanet.Orbiting);
                }
                return innerOrbit;
        }

        static int FindAllOrbits(Dictionary<string, Planet> allPlanets)
        {
            int orbitCounter = 0;

            foreach(var planet in allPlanets)
            {
                Console.WriteLine("Planet: {0}", planet.Value.Name);
                Planet orbitingPlanet = GetPlanetObjectFromName(allPlanets, planet.Value.Orbiting);
                int innerOrbit = 0;
                if(string.Equals(planet.Value.Orbiting, "COM"))
                {
                    innerOrbit++;
                }
                while(orbitingPlanet != null )
                {
                    Console.WriteLine("Orbiting Name: {0}", orbitingPlanet.Name);
                    innerOrbit++;
                    Console.WriteLine("While Inner Orbit: {0}", innerOrbit);
                    if(string.Equals(orbitingPlanet.Orbiting, "COM"))
                    {
                        innerOrbit++;
                    }
                    orbitingPlanet = GetPlanetObjectFromName(allPlanets, orbitingPlanet.Orbiting);
                }
                
                Console.WriteLine("Inner Orbit: {0}", innerOrbit);
                orbitCounter+= innerOrbit;
                Console.WriteLine("OrbitCounter After: {0}", orbitCounter);
            }
            return orbitCounter;
        }

        static Planet GetPlanetObjectFromName(Dictionary<string, Planet> allPlanets, string planetName)
        {
            if(allPlanets.ContainsKey(planetName))
            {
                return allPlanets[planetName];
            }
            return null;
        }

        static string[] OrbitParser(string orbitData)
        {
            string[] planets = orbitData.Split(")");
            return planets;
        }

        public class Planet
        {
            public string Name {get; set;}
            public string Orbiting {get; set;}
            public Planet(string name, string orbiting)
            {
                Name = name;
                Orbiting = orbiting;
            }
        }
    }
}
