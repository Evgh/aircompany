using Aircompany.Models;
using Aircompany.Planes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class Airport
    {
        public List<Plane> Planes { get; private set; }

        public Airport(IEnumerable<Plane> planes)
        {
            Planes = planes.ToList();
        }

        public List<PassengerPlane> GetPassengersPlanes()
        {
            return Planes.Where((plane) => plane is PassengerPlane).Cast<PassengerPlane>().ToList();
        }

        public List<MilitaryPlane> GetMilitaryPlanes()
        {
            return Planes.Where((plane) => plane is MilitaryPlane).Cast<MilitaryPlane>().ToList();
        }

        public PassengerPlane GetPassengerPlaneWithMaxCapacity()
        {
            var passengerPlanes = GetPassengersPlanes();
            return passengerPlanes.Aggregate((w, x) => w.PassengersCapacity > x.PassengersCapacity ? w : x);             
        }

        public List<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            List<MilitaryPlane> militaryPlanes = GetMilitaryPlanes();
            return militaryPlanes.Where((plane) => plane.Type == MilitaryType.Transport).Cast<MilitaryPlane>().ToList();
        }

        public void SortByMaxDistance()
        {
            Planes.OrderBy(w => w.MaxFlightDistance);
        }

        public void SortByMaxSpeed()
        {
            Planes.OrderBy(w => w.MaxSpeed);
        }

        public void SortByMaxLoadCapacity()
        {
            Planes.OrderBy(w => w.MaxLoadCapacity);
        }

        public Airport CloneAirport()
        {
            return new Airport(Planes);
        }


        public override string ToString()
        {
            return $"Airport {{ planes={ string.Join(", ", Planes.Select(x => x.Model)) }";
        }
    }
}
