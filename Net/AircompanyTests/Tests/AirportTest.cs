using Aircompany;
using Aircompany.Models;
using Aircompany.Planes;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace AircompanyTests.Tests
{
    [TestFixture]
    public class AirportTest
    {
        private List<Plane> _planes = new List<Plane>(){
           new PassengerPlane("P", 0, 0, 1, 999),
           new PassengerPlane("P", 0, 0, 0, 0),
           new PassengerPlane("P", 0, 0, 2, 0),
           new MilitaryPlane("Mi", 0, 0, 3, MilitaryType.Bomber),
           new MilitaryPlane("Mi", 0, 0, 4, MilitaryType.Fighter),
           new MilitaryPlane("Tr", 0, 0, 5, MilitaryType.Transport)
        };

        private List<Plane> _planesSortedByMaxLoadCapacity = new List<Plane>(){
           new PassengerPlane("P", 0, 0, 0, 0),
           new PassengerPlane("P", 0, 0, 1, 999),
           new PassengerPlane("P", 0, 0, 2, 0),
           new MilitaryPlane("Mi", 0, 0, 3, MilitaryType.Bomber),
           new MilitaryPlane("Mi", 0, 0, 4, MilitaryType.Fighter),
           new MilitaryPlane("Tr", 0, 0, 5, MilitaryType.Transport)
        };

        private List<MilitaryPlane> _transportMilitaryPlanes = new List<MilitaryPlane> { new MilitaryPlane("Tr", 0, 0, 5, MilitaryType.Transport) };

        private PassengerPlane _passengerPlaneWithMaxPassengerCapacity = new PassengerPlane("P", 0, 0, 1, 999);

        [Test]
        public void Add_MultiplePlanes_ReturnsTransportMilitaryPlanes()
        {
            var airport = new Airport(_planes);
            Assert.AreEqual(airport.GetTransportMilitaryPlanes(), _transportMilitaryPlanes);
        }

        [Test]
        public void Add_MultiplePlanes_ReturnsPlaneWithMaxPassengersCapacity()
        {
            var airport = new Airport(_planes);
            var expectedPassengerPlaneWithMaxCapacity = airport.GetPassengerPlaneWithMaxCapacity();
            Assert.AreEqual(expectedPassengerPlaneWithMaxCapacity, _passengerPlaneWithMaxPassengerCapacity);
        }

        [Test]
        public void Add_MultiplePlanes_SortsByMaxLoadCapacity()
        {
            var airport = new Airport(_planes);
            airport.SortByMaxLoadCapacity();
            Assert.AreEqual(airport.Planes, _planesSortedByMaxLoadCapacity);
        }
    }
}
