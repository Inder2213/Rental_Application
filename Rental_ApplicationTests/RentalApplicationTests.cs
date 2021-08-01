using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rental_Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rental_Application.Controller;
using System.Windows.Forms;

namespace Rental_Application.Tests
{
    [TestClass()]
    public class RentalApplicationTests
    {
        [TestMethod()]
        public void RentalApplicationTest()
        {
            functionalTask functional = new functionalTask();
            if (functional.addClient("Aman", "1234", "Aman@gmail.com", "NZ") == 1)
            {
                MessageBox.Show("CLient is Registered ");
                Assert.IsTrue(true);
            }
            else {
                Assert.IsTrue(false);
            }
            
        }


        [TestMethod()]
        public void RentalApplicationTest2()
        {
            functionalTask functional = new functionalTask();
            if (functional.deleteClient(1) == 1)
            {
                MessageBox.Show("CLient is Erased ");
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }

        }
    }
}