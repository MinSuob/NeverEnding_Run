using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    #region Singleton
    private static DataManager instance;
    public static DataManager Instance
    {
        get { return instance; }
    }
    #endregion

    private List<string> DeckData = new List<string>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        DeckData = DeckDataSet.DataLoad();


    }

    void Update()
    {
        
    }

    public List<string> GetDeckData()
    {
        return DeckData;
    }

    public void SetDeckData(int index, string unit)
    {
        DeckData[index] = unit;
    }
}
