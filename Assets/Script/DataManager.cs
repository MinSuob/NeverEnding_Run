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

    public long GetGold()
    {
        return UserData.Gold;
    }
    public void SetGold(long money)
    {
        UserData.Gold = money;
    }

    public int GetDiamond()
    {
        return UserData.Diamond;
    }
    public void SetDiamond(int Diamond)
    {
        UserData.Diamond = Diamond;
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

    public float GetSFX_Volume()
    {
        return UserData.SFX_Volume;
    }

    public void SetCurStage(float SFX_Volume)
    {
        UserData.SFX_Volume = SFX_Volume;
    }

    public float GetMusic_Volume()
    {
        return UserData.Music_Volume;
    }

    public void SetMusic_Volume(float Music_Volume)
    {
        UserData.Music_Volume = Music_Volume;
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
