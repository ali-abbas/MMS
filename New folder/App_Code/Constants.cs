using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Constants
/// </summary>
public class Constants
{
	public Constants()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public static string constant1="Machine";

    public static string constant2 = "Laptop";



    public string Constant1
    {

        get
        {
            return constant1;
        }

    }


    public string Constant2
    {

        get
        {
            return constant2;
        }

    }


    public Dictionary<string,int> ConsList {

        get {

            return new Dictionary<string,int> {
                    
                {constant1,1},
                {constant2,2}
            
            };
        
        }
        
    }


}