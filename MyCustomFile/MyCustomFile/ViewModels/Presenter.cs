using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;
using System.Windows;
using MyCustomFile.Models;
using MyCustomFile.Helper;

namespace MyCustomFile.ViewModels
{
    // main class
    // FIXME
    public class Presenter : ObservableObject
    {
        private readonly ObservableCollection<string> _content = new ObservableCollection<string>();
        private string _someText;
        

        public string SomeText
        {
            get { return _someText; }
            set
            {
                _someText = value;
                RaisePropertyChangedEvent("SomeText");
            }
        }

        public IEnumerable<string> History
        {
            get { return _content; }
        }

        public ICommand SearchTextCommand
        {
            get { return new DelegateCommand(DoValidation); }

        }
       
        private void DoValidation()
        {
            /* deprecated for now###
            HandlePartition handlePartition = new HandlePartition(SomeText);
            string []filles = handlePartition.getAllFilesFromPartition();
            PopulateListContent(filles);
            */
            if (string.IsNullOrEmpty(Utilities.test))
                return;

            // make sure that old content is removed
            _content.Clear();
            //Utilities.mCachedList.Clear();

            foreach(string item in HandlePartition.getAllContentOfADirectory(Utilities.test)){
                _content.Add("File: " + item);
            }

            foreach (string item in HandlePartition.getDirsOfADirectory(Utilities.test))
            {
                _content.Add("Directory: " + item);
                Utilities.mCachedList.Add(item);
            }
            Utilities.mCachedList.Add("### One step back ### (not a directory)");
        }

        private void PopulateListContent(string[] item)
        {
            // even if no file is selected, length will be 0
            // it means the following loop will never execute
            for(int i = 0; i < item.Length; i++)
                _content.Add(item[i]);
        }
    }
}
