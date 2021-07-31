using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CharacterState;


public class UnitData
{
    // 유닛별 데이터 ( 공격력, 체력, 강화 등 )

    public string Name { get; set; } // 유닛이름

    public Job Job { get; set; } // 유닛 번호

    public int Level { get; set; } // 레벨

    public float MaxHp { get; set; } // 최대 체력

    public float CurHp { get; set; } // 현재 체력

    public float Atk { get; set; } // 공격력

    public float AtkDist { get; set; } // 공격 사거리

    public float AtkDelay { get; set; } // 공격속도

    public float Cool { get; set; } // 스킬 쿨타임

    public float SkillDist { get; set; } // 스킬 사거리

    public string Skill_Name { get; set; } // 스킬 이름

    public string Skill_Tip { get; set; } // 스킬 설명

    public string Char_Tip { get; set; } // 캐릭터 설명

}
