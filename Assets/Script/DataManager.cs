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
    SortedDictionary<int, EnemyData> EnemyData; 

    private UserData UserData = new UserData();




    private List<string> DeckData = new List<string>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }


        DataLoad();
    }

    public void DataLoad()
    {
        DeckData = DeckDataSet.DataLoad();
        UnitData = UnitDataSet.DataLoad();
        EnemyData = EnemyDataSet.DataLoad();
        UserData = UserDataSet.DataLoad();

    }

    void Update()
    {
        
    }

    public int GetMaxStage()
    {
        return UserData.MaxStage;
    }

    public void SetMaxStage(int Stage)
    {
        UserData.MaxStage = Stage;
    }

    public int GetCurStage()
    {
        return UserData.CurStage;
    }

    public void SetCurStage(int Stage)
    {
        UserData.CurStage = Stage;
    }

    public UnitData GetUnitData(Job job)
    {
        return UnitData[(int)job];
    }

    public EnemyData GetEnemyData(EnemyJob job)
    {
        return EnemyData[(int)job];
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
