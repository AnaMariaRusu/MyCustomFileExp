using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace MyCustomFile.Helper
{
    public abstract class Utilities
    {
        // let's suppose for now that only C and D partitions are mounted
        // testing purposes!
        public static string C_DIR = "C";
        public static string D_DIR = "D";
        // test

        // used to cache the list of dirs for history 
        public static List<string> mCachedList = new List<string>();
        public static string test = null;

        // log this error 
        public static short ERROR_CODE = -1;
        public static string ERR_MSG = "Error: ";


        // display an error message to the user
        public static void ErrMsg(string message)
        {
            // nothing to display
            if (string.IsNullOrEmpty(message))
                return;
            MessageBox.Show(ERR_MSG + " " + message);
        }

    }
}
