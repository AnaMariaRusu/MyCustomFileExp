using MyCustomFile.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MyCustomFile.Models
{
    // helper class
    public  class HandlePartition
    {
        private string partition_name;
        public HandlePartition(string _actual_partition_name)
        {
            this.partition_name = _actual_partition_name;
            // check to be sure we can display correct files
            if (string.IsNullOrWhiteSpace(this.partition_name))
            {
                Utilities.ErrMsg("Invalid partition provided! Try Again!");
                return;
            }
        }

        // Returns an array of strings (or null in case of error) contains 
        // all existing files from a given partition
        public string[] getAllFilesFromPartition()
        {

            if (this.partition_name.Equals(Utilities.C_DIR))
                return Directory.GetFiles(@"c:\");
            else if (this.partition_name.Equals(Utilities.D_DIR))
                return Directory.GetFiles(@"d:\");
            else
                return null;
    
        }

        // Returns an array of strings (or null in case of error) contains 
        // all existing directories from a given partition
        public string[] getAllDirsFromPartition()
        {

            if (this.partition_name.Equals(Utilities.C_DIR))
                return Directory.GetDirectories(@"c:\");
            else if (this.partition_name.Equals(Utilities.D_DIR))
                return Directory.GetDirectories(@"d:\");
            else
                return null;
        }

        // TODO - make me thread safe method
        // Returns info about mounted (and ready) partitions on the system
        public static List<string> ExistingPartitions()
        {
            List<string> mList = new List<string>();

            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo d in allDrives)
            {
                mList.Add("Mounted partition: " + d.Name);
                mList.Add("Partition type: " + d.DriveType);
                // check if the machine is ready to query it
                if (d.IsReady == true)
                {
                    mList.Add("\tAvailable space on this partition: " + (int)(d.TotalFreeSpace/Math.Pow(1024,3)) + " GB");
                    
                    mList.Add("\tTotal size of this partition: " + (int)(d.TotalSize / Math.Pow(1024, 3)) + " GB");
                }
            }
            return mList;
        }
        
        public static List<String> getOnlyDirsPartition(string partition)
        {
            if (string.IsNullOrEmpty(partition))
                Utilities.ErrMsg(Utilities.ERR_MSG + " invalid partition provided!. Try again!");

            List<string> mCustomList = new List<string>();
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                mCustomList.Add(d.Name);
            }
            return mCustomList;
        }

        public static List<string> getRootPartitions()
        {
            List<string> mList = new List<string>();
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                mList.Add(d.Name);
            }
            return mList;
        }

        public static string[] getAllContentOfADirectory(string path)
        {
            string[] error = new string[1];
            error[0] = "No files in selected path";
            try
            {
                return Directory.GetFiles(path);
            }
            catch(IOException)
            {
                return error;
            }
            
        }

        public static string[] getDirsOfADirectory(string path)
        {
            string[] error = new string[1];
            error[0] = "No files in selected path -> press Back button";
            try
            {
                return Directory.GetDirectories(path);
            }
            catch (Exception)
            {
                return error;
            }

        }
    }
}
