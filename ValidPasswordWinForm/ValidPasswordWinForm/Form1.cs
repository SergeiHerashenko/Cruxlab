using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValidPasswordWinForm
{
    public partial class Form1 : Form
    {
        private string selectedFilePath;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            // Відкриваємо діалогове вікно вибору файлу
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                // Зберігаємо шлях у поле
                selectedFilePath = openFile.FileName;
                // Виводимо обраний шлях на перший лейбл
                label1.Text = "Selected file:" + selectedFilePath;
                // Очищаємо другий лейбл
                label2.Text = "";
                // Включаємо видимість кнопки "Підрахувати"
                button2.Visible = true; 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Виклик методу для підрахунку валідних паролів
            int ValidPasswordCount = new CountValidPassword().countPassword(selectedFilePath);
            // Вивід кількості валідних паролів на другий лейбл
            label2.Text = "Number of valid passwords:" + ValidPasswordCount; 
        }
    }
}
