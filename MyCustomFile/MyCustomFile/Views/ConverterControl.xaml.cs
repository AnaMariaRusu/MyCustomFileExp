using MyCustomFile.Helper;
using MyCustomFile.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace MyCustomFile.Views
{
    public partial class ConverterControl
    {        
        private static short mCounter;
        private static short step;

        public ConverterControl()
        {
            InitializeComponent();
            populateThisComboBox();
            populateThisListBox();
           
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
            Utilities.test = mycomboBox.Text;
            //MessageBox.Show("This is a test");
            mycomboBox.Items.Clear();
            // do again combobox population
            foreach (string item in HandlePartition.getDirsOfADirectory(Utilities.test))
            {
                mycomboBox.Items.Add(item);
                
            }
            mCounter++;

        }
        
        // dummy implementation
        private void populateThisListBox()
        {
            foreach(string item in HandlePartition.ExistingPartitions()){
                myListBox.Items.Add(item);
            }
        }

        private void populateThisComboBox()
        {
            foreach (string item in HandlePartition.getRootPartitions())
            {
                if (string.IsNullOrEmpty(item))
                    continue;
                mycomboBox.Items.Add(item);
            }
        }

        private void ListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            mycomboBox.Items.Clear();
         
           
            Utilities.mCachedList.Reverse();
            foreach (string s in Utilities.mCachedList)
            {
                if (step++ == 0)
                    continue;
                mycomboBox.Items.Add(s);
            }
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            mycomboBox.Items.Clear();
            populateThisComboBox();
        }
    }
}
