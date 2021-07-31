using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Media;
using System.Diagnostics;
using Microsoft.Win32;

namespace BackgroundChanger
{
    public partial class Form1 : Form
    {
        private SoundPlayer snd_back;
        public Form1()
        {
            InitializeComponent();
        }
        public static void Extract(string nameSpace, string outDirectory, string internalFilePath, string resourceName)
        {
            //Это Екстрактор... НЕ ТРОГАТЬ!!!!

            Assembly assembly = Assembly.GetCallingAssembly();

            using (Stream s = assembly.GetManifestResourceStream(nameSpace + "." + (internalFilePath == "" ? "" : internalFilePath + ".") + resourceName))
            using (BinaryReader r = new BinaryReader(s))
            using (FileStream fs = new FileStream(outDirectory + "\\" + resourceName, FileMode.OpenOrCreate))
            using (BinaryWriter w = new BinaryWriter(fs))
                w.Write(r.ReadBytes((int)s.Length));
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists(@"C:\BackgroundChanger\BackgroundChanger.exe"))
            {
                Directory.CreateDirectory(@"C:\BackgroundChanger");
                Extract("BackgroundChanger", @"C:\BackgroundChanger", "Resources", "SomeThingsNeverChanged.wav");
                Extract("BackgroundChanger", @"C:\BackgroundChanger", "Resources", "BurnoutParadise.jpg");
            }
            if (File.Exists(@"C:\BackgroundChanger\SomeThingsNeverChanged.wav"))
            {
                snd_back = new SoundPlayer(@"C:\BackgroundChanger\SomeThingsNeverChanged.wav");
                snd_back.PlayLooping();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            var NewForm = new BurnoutParadise();
            NewForm.ShowDialog();
        }
    }
}