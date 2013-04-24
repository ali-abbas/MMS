using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserDesignationEntity
/// </summary>
public class UserDesignationEntity
{
    #region constructor
	public UserDesignationEntity()
    {

    }

    #endregion constructor

    #region Attributes

    private Int32 id = 0;

    private string userDesignation = string.Empty;

    #endregion Attributes

    #region properties

    public int Id {

        get {

            return id;

        }

        set {
            id = value;
        }
    
    }

    public string UserDesignation {

        get {
            return userDesignation;
        }

        set {
            userDesignation = value;
        }
    }

    #endregion properties

    #region Methods

    #endregion Methods


}