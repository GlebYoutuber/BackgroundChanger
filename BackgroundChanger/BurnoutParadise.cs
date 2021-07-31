using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Threading;
using System.Diagnostics;

namespace BackgroundChanger
{
    public partial class BurnoutParadise : Form
    {
        public BurnoutParadise()
        {
            InitializeComponent();
        }

        private void BurnoutParadise_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to Burnout Paradise Wallpaper Changer, Enjoy!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistryKey wallpaper = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            wallpaper.SetValue("Wallpaper", "C:\\BackgroundChanger\\BurnoutParadise.jpg");
            MessageBox.Show("Смена Картинки в Рабочем Столе Успешно Применена, но потребуется Перезагрузка");
            //Перезагружаем чтоб Применение Заработали Успешно
            Thread.Sleep(2700);
            Process.Start("shutdown", "/r /t 500");
            Environment.Exit(-1);
        }
    }
}