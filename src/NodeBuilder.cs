using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CCG_Assignment
{
    class NodeBuilder
    {

        public static Node Build( string[] allHeaders, string[] allData ) {

            Node rowNode = new Node();

            int colIndex = 0;

            foreach ( string eachHeader in allHeaders ) {

                if ( eachHeader.Contains('_') ) 
                {
                    string[] splitNode = eachHeader.Split('_');
                    if ( !rowNode.HasChild(splitNode[0]) )
                    {
                        rowNode.AddChild( new Node(){ Name = splitNode[0] } );
                    }
                    Node childNode = rowNode.GetChild( splitNode[0] );
                    childNode.AddChild( NodeBuilder.Build( splitNode[1], allData[colIndex]) );
                }
                else
                {
                    rowNode.AddChild( NodeBuilder.Build( eachHeader, allData[colIndex]) );
                }

                colIndex++;

            }

            return rowNode;

        }

        public static Node Build( string header, string content) {
            return new Node(){ Name = header, Content = content };   
        }

    }

}