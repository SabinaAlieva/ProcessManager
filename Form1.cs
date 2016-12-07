using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessManager
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            Table1.ColumnCount = 3;
            Table2.ColumnCount = 3;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //нажатие на кнопку обновить список процессов
        private void button2_Click(object sender, EventArgs e)
        {
            Table1.Rows.Clear();
            System.Diagnostics.Process[] processes;
            processes = System.Diagnostics.Process.GetProcesses();

            int pCount = processes.Length;
            for (int i = 0; i < pCount; i++)
            {
                Table1.Rows.Add(processes[i].ProcessName, processes[i].PrivateMemorySize, processes[i].Id );
            } 
        }

        //нажатие на кнопку удалить процесс
        //будет удален тот, на который последний раз нажали левой клавишей мыши в первой таблице
        private void button3_Click_1(object sender, EventArgs e)
        {
            int a = Table1.CurrentRow.Index;
            Table2.Rows.Add(Table1[0, a].Value.ToString(), Table1[1, a].Value.ToString(), Table1[2, a].Value.ToString());
            System.Diagnostics.Process localById = System.Diagnostics.Process.GetProcessById(int.Parse(Table1[2, a].Value.ToString()));
            localById.Kill();
            Table1.Rows.Remove(Table1.Rows[a]);
        }
    }
}
