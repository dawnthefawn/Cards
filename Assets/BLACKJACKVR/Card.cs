using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Dawn_Of_VR { 

public class Card : MonoBehaviour {

    public GameObject objCard;
    public int intValue;
    public bool blnFirstCard;
    private int intRank;
    private string strCardObjectName;
    private string strFace;
    private string strSuit;


    /// <summary>
    /// Use this to retreive a card
    /// </summary>
    /// <param name="r">Rank as Integer 1-13</param>
    /// <param name="s">Suit</param>
    /// <returns>Corresponding Card Prefab</returns>
    public bool blnRun(int r, string s)
    {
        if (blnSetFace(r) == false)
        {
            Debug.LogError("InitiateCard, blnSetFace Failed");
            return false;
        }

        if (blnSetSuit(s) == false)
        {
            Debug.LogError("InitiateCard, blnSetSuit Failed");
            return false;
        }

        if (blnSetValue(r) == false)
        {
            Debug.LogError("InitiateCard, blnSetValue Failed");
            return false;
        }

        if (blnSetCardObjectName() == false)
        {
            Debug.LogError("InitiateCard, blnCardObjectName Failed");
            return false;
        }

        if (blnInstantiateCard() == false)
        {
            Debug.LogError("InitiateCard, blnSetFace Failed");
            return false;
        }

        return true;
       
    }



    private enum Enum_Face
    {
        A=1,
        J=11,
        Q=12,
        K=13

    }

    private bool blnSetFace(int r)
    {
        try
        {
            if(r > 1 && r < 11)
            {
                strFace = r.ToString();
                return true;
            }
            if(r == 1 || r > 10)
            {
                strFace = ((Enum_Face)r).ToString();
                 return true;
            }
        }
        catch(InvalidCastException e)
        {
            Debug.LogError(e.Message);
        }
         return false;
    }

    private bool blnSetSuit(string s)
    {
        try
        {
            strSuit = s;
            return true;
        }
        catch(InvalidCastException e)
        {
            Debug.LogError(e.Message);
        }
        return false;
    }

    private bool blnSetValue(int r)
    {
        if(r < 10 && r > 0)
        {
            intValue = r;
            return true;
        }
        if(r > 10 && r < 14)
        {
            intValue = 10;
            return true;
        }
        Debug.LogError("int r Rank out of bounds");
        return false;
    }

    private bool blnSetCardObjectName()
    {
        if(strSuit != null && strFace != null)
        {
            strCardObjectName = "PlayingCards_" + strFace + strSuit + ".fbx";
            return true;
        }
        Debug.LogError("Unable to set Card Object Name");
        return false;
    }

    private bool blnInstantiateCard()
    {
        try
        {
            objCard = Instantiate(Resources.Load(strCardObjectName)) as GameObject;

        }
        catch(InvalidCastException e)
        {
            Debug.LogError(e.Message);
            return false;

        }
        return true;
    }
}
}
