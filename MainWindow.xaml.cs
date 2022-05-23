using Lab3.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Windows;

namespace Lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SlavsList slavsList = new slavsList();
        public MainWindow()
        {
            InitializeComponent();
            ChooseSlavs.Items.Add(new Belarusian());
            ChooseSlavs.Items.Add(new Ukrainian());
            ChooseSlavs.Items.Add(new Russian());
            ChooseSlavs.Items.Add(new Poles());
            ChooseSlavs.Items.Add(new Czechs());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Type type = ChooseSlavs.SelectedItem.GetType();
            Slavs s = (Slavs)Activator.CreateInstance(type);
            if (s != null)
            {
                s.Nation = AddNation.Text;
                s.Population = Convert.ToInt32(AddPopulation.Text);
                s.Area = Convert.ToDouble(AddArea.Text);
            }
            slavsList.Add(s);
            ShowSlavs.Items.Clear();
            foreach (Slavs slav in slavsList)
                ShowSlavs.Items.Add(slav.ShowInfo());
        }

        private void Serialize_Click(object sender, RoutedEventArgs e)
        {
            Serializator s = new Serializator();
            File.WriteAllText(FileToSerialize.Text, s.Serialize(slavsList));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            slavsList.Remove(slavsList.Get(ShowSlavs.SelectedIndex));
            ShowSlavs.Items.Clear();
            foreach (Slavs slav in slavsList)
                 ShowSlavs.Items.Add(slav.ShowInfo());
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Slavs s = slavsList.Get(ShowSlavs.SelectedIndex);
            s.Nation = AddNation.Text;
            s.Population = Convert.ToInt32(AddPopulation.Text);
            s.Area = Convert.ToDouble(AddArea.Text);
            ShowSlavs.Items.Clear();
            foreach (Slavs slav in slavsList)
                ShowSlavs.Items.Add(slav.ShowInfo());
        }

        private void Deserialize_Click(object sender, RoutedEventArgs e)
        {
            Serializator s = new Serializator();
            SlavsList tmp = s.Deserialize(File.ReadAllText(FileToDeserialize.Text));
            foreach (Slavs slav in tmp)
                slavsList.Add(slav);
            ShowSlavs.Items.Clear();
            foreach (Slavs slav in slavsList)
                ShowSlavs.Items.Add(slav.ShowInfo());
        }
    }
}
