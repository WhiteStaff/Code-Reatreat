using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using  NUnit.Framework;
namespace Life_Game
{
    [TestFixture]
    class LifeTests
    {
        public bool[,] field;
        public bool[,] idealfield1;
        public bool[,] idealfield2;
        [SetUp]
        public void SetUp()
        {
            field = new bool[3,3]{{false, true, false}, {false, true, false}, { false, true, false } };
            idealfield1 = new bool[,]{ { false, false, false, false, false }, { false, false, false, false, false }, { false, true, true, true, false }, { false, false, false, false, false }, { false, false, false, false, false } };
            idealfield2 = new bool[,] { { false, true, false }, { false, true, false }, { false, true, false } };
        }
        [Test]
        public void IsTrueNewArray()
        {
            Assert.That(()=>Program.NewArr(field).GetLength(0) == 5);
        }

        [Test]
        public void IsArrayTurnsFigure()
        {
            Assert.That(Program.CorrectArray(field).Equals(idealfield1));
        }

        [Test]
        public void IsCounterTrue()
        {
            Assert.That(Program.GetNeighbours(2,1, idealfield1).Equals(3));
        }
    }

}
