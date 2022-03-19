using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace CCG_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {

            RawData data = new RawData();
            data.ReadInCSV(args[0]);

            Node rootNode = new Node( true );

            int rowIndex = 0;
            while ( rowIndex < data.GetRowsCount() ) {
                rootNode.AddChild( NodeBuilder.Build( data.GetHeaders(), data.GetDataRowAt(rowIndex) ) );
                rowIndex++;
            }

            File.WriteAllText(args[1], rootNode.OutputTree() );
            
        }

    }

}
