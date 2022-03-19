using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CCG_Assignment
{
    class Node
    {
        private List<Node> children = new List<Node>();
        private bool isRoot = false;

        public string Name { get; set; } = "";
        public string Content { get; set; } = "";

        public Node( bool rootNode = false ){
            isRoot = rootNode;
         }

        public void AddChild( Node newNode ) {
            children.Add( newNode );
        }

        public bool HasChild( string nodeName ){
            return children.Any<Node>( n => n.Name == nodeName );
        }

        public Node GetChild( string nodeName ){
            return children.FirstOrDefault<Node>( n => n.Name == nodeName );
        }

        public String OutputTree( int depth = 0 ) {

            String padding = "".PadLeft(depth, ' ');

            StringBuilder sBuilder = new StringBuilder();

            // Display Name/Content Pair
            if ( Name.Length > 0 && Content.Length > 0 ) {
                sBuilder.Append( padding + $"\"{this.Name}\" : \"{Content}\"" );
            }

            // Parse Children
            if ( children.Count > 0 ) {

                if ( this.Name.Length > 0 ) {
                    sBuilder.Append( padding + $"\"{this.Name}\" : " + "{\n" );
                }
                else {
                    if ( isRoot ) 
                        sBuilder.Append( padding + "[\n" );  
                    else
                        sBuilder.Append( padding + "{\n" );  
                }                


                foreach ( Node eachChild in children){

                    sBuilder.Append( eachChild.OutputTree( depth+2 ) );     

                    // Comma Tidying Rules
                    if ( children[children.Count-1] != eachChild ) 
                        sBuilder.Append( ",\n");
                    else
                        sBuilder.Append( "\n");

                }   

                if ( isRoot ) 
                    sBuilder.Append( padding + "]" );  
                else
                    sBuilder.Append( padding + "}" );  

            }

            return sBuilder.ToString();

        }

    }

}