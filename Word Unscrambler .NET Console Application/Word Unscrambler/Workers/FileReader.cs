using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Word_Unscrambler.Workers
{
    class FileReader
    {
        public string[] Read(string fileName)
        {
            string[] fileContent;
            try
            {
                fileContent = File.ReadAllLines(fileName);
                
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);              // throw ex;  it will erase the entire call stack;
            }
            return fileContent;
        }
    }
}



