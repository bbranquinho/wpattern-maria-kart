using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Maria_Kart__Game_Player_;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maria_Kart__Unit_Test_
{
    [TestClass]
    public class MeuTeste
    {
        [TestMethod]
        public void TestMethodBranquinho()
        {
            Dayverton meuObj = new Dayverton();

            MessageBox.Show(meuObj.MeuMetodo().ToString());
        }
    }
}
