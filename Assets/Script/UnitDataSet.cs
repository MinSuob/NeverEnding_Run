using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CharacterState;


public class UnitDataSet
{
    

    public static SortedDictionary<int, UnitData> DataLoad()
    {
        float MeleeDistance = 1f; // 근거리
        float RangeDistance = 5f; // 원거리

        SortedDictionary<int, UnitData> Unitdata = new SortedDictionary<int, UnitData>();

        #region Unit0
        UnitData unit = new UnitData();
        unit.Name = "칼병";
        unit.Char_Tip = "칼병";
        unit.Job = Job.Unit0;
        unit.Level = 1;
        unit.MaxHp = 100;
        unit.CurHp = unit.MaxHp;
        unit.Atk = 10f;
        unit.AtkDist = MeleeDistance;
        unit.AtkDelay = 3f;
        unit.Skill_Name = "전방베기";
        unit.Skill_Tip = "전방에 있는 적 모두를 벤다.";
        unit.SkillDist = unit.AtkDist;
        unit.Cool = 5f;
        Unitdata.Add((int)unit.Job, unit);
        #endregion




        return DataLoad();
    }


}
