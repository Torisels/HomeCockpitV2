using System;
using System.Linq;
using System.Windows.Forms;

namespace HomeCockpitV2
{
    public partial class MainForm : Form
    {
        private DataBase  db = new DataBase();
        public MainForm()
        {
            InitializeComponent();
            var db = new DataBase();

            var resultList = db.GetBitRegisterPairs();
            int i = 1;
            foreach (var item in resultList)
            {
                Console.WriteLine(@"Pin: {0}, Register: {1}, Bit: {2}",i,item.Register,item.Bit);
                i++;
            }

            var item1 = resultList.ElementAt(5-1);
            Console.WriteLine(@"Pin: {0}, Register: {1}, Bit: {2}", 5, item1.Register, item1.Bit);
            FillDataGridViewPins();
        }

        public void FillDataGridViewPins()
        {
            var data = db.GetDataGridViewList();
            foreach (var item in data)
            {
                dataGridViewPins.Rows.Add(item.Pin, item.McuId, item.McuRegister, item.MasterBufferRegisterIndex);
            }
            
        }
    }
}
