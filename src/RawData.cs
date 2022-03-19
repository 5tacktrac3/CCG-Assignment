using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CCG_Assignment
{
    class RawData
    {
        List<string> allRows = new List<string>();

        public RawData() {

        }

        public void ReadInCSV( string path ) {
            string[] lines = System.IO.File.ReadAllLines(path);
            allRows = lines.ToList();
        }

        public string[] GetHeaders() {
            return allRows[0].Split(",");
        }    

        public int GetRowsCount() {            
            return allRows.Count()-1;
        }       

        public string[] GetDataRowAt( int index ) {
            if ( index < allRows.Count - 1) return allRows[index+1].Split(",");
            return new string[]{};
        }

    }

}
