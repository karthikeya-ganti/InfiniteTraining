using NUnit.Framework.Legacy;
using NUnit.Framework;
using Mini_Project;

namespace MiniProject_Testing
{
    [TestFixture]
    class TestClass
    {
        [Test]
        public void AuthenticateAdmin_ValidCredentials()
        {
            string username = "mario";
            string password = "mario@123";
            string role = "admin";

            bool is_authenticated = RailwayReservation.AuthenticateUser(username, password, role);

            ClassicAssert.IsTrue(is_authenticated);
        }
        
        [Test]
        public void AuthenticateAdmin_InvalidCredentials()
        {
            string username = "mario";
            string password = "mario@123";
            string role = "customer";

            bool is_authenticated = RailwayReservation.AuthenticateUser(username, password, role);

            ClassicAssert.IsFalse(is_authenticated);
        }

        [Test]
        public void AuthenticateCustomer_ValidCredentials()
        {
            string username = "karthik";
            string password = "karthik@123";
            string role = "customer";

            bool is_authenticated = RailwayReservation.AuthenticateUser(username, password, role);

            ClassicAssert.IsTrue(is_authenticated);
        }

        [Test]
        public void AuthenticateCustomer_InvalidCredentials()
        {
            string username = "karthik";
            string password = "karthik@007";
            string role = "customer";

            bool is_authenticated = RailwayReservation.AuthenticateUser(username, password, role);

            ClassicAssert.IsFalse(is_authenticated);
        }
    }
}