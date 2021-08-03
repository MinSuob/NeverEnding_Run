using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CharacterState;


public class DataManager : MonoBehaviour
{
    #region Singleton
    private static DataManager instance;
    public static DataManager Instance
    {
        get { return instance; }
    }
    #endregion

    #region Json Child Name
    string DECK_DATA = "DeckData";
    string USER_DATA = "UserData";
    string UNIT_DATA = "UnitData";
    #endregion

    SortedDictionary<int, UnitData> UnitData;



    private List<string> DeckData = new List<string>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        DeckData = DeckDataSet.DataLoad();

        DataLoad();
    }

    public void DataLoad()
    {
        UnitData = UnitDataSet.DataLoad();
    }

    void Update()
    {
        
    }

    public UnitData GetUnitData(Job job)
    {
        return UnitData[(int)job];
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
