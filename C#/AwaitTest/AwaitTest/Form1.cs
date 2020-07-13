using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AwaitTest
{
    public partial class Form1 : Form
    {
        private int _a = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAsync_Click(object sender, EventArgs e)
        {
            AsyncRun();
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            SyncRun();
        }

        private void SyncRun()
        {
            for (int i = 0; i < 10; i++)
            {
                int rst = PlusPlus(ref _a);
                label1.Text = rst.ToString();
            }
        }

        private async void AsyncRun()
        {
            int rst;
            
            for (int i = 0; i < 10; i++)
            {
                var taskPlusPlus = Task.Run(() => PlusPlus(ref _a)); // 여기서 PlusPlus() 메소드가 실행된다.
                rst = await taskPlusPlus;                            // 여기서 PlusPlus() 메소드가 끝날때까지 기다린다.
                label1.Text = rst.ToString();
            }
        }

        private int PlusPlus(ref int n)
        {
            Thread.Sleep(1000);
            return ++n;
        }

    }
}
