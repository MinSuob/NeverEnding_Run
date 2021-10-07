using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CharacterState;


public class EnemyDataSet : MonoBehaviour
{
    public static SortedDictionary<int, EnemyData> DataLoad()
    {
        float MeleeDistance = 1f; // 근거리
        float RangeDistance = 5f; // 원거리

        SortedDictionary<int, EnemyData> EnemyData = new SortedDictionary<int, EnemyData>();

        #region GoblinBasic
        EnemyData enemy = new EnemyData();
        enemy.Name = "미니 고블린";
        enemy.Job = EnemyJob.GoblinBasic;
        enemy.Grade = 1;
        enemy.MaxHp = 50;
        enemy.CurHp = enemy.MaxHp;
        enemy.Atk = 8;
        enemy.AtkDist = MeleeDistance;
        enemy.AtkDelay = 1f;
        enemy.AtkType = "Melee";
        enemy.MoveSpeed = 0.005f;
        enemy.Skill_Name = "전방베기";
        enemy.Skill_Tip = "전방에 있는 적 모두를 벤다.";
        enemy.SkillDist = enemy.AtkDist;
        enemy.Cool = 5f;
        enemy.DropGold = 5;
        EnemyData.Add((int)enemy.Job, enemy);
        #endregion

        #region GoblinSword
        enemy = new EnemyData();
        enemy.Name = "칼든 고블린";
        enemy.Job = EnemyJob.GoblinSword;
        enemy.Grade = 1;
        enemy.MaxHp = 150;
        enemy.CurHp = enemy.MaxHp;
        enemy.Atk = 12f;
        enemy.AtkDist = MeleeDistance;
        enemy.AtkDelay = 1f;
        enemy.AtkType = "Melee";
        enemy.MoveSpeed = 0.004f;
        enemy.Skill_Name = "전방베기";
        enemy.Skill_Tip = "전방에 있는 적 모두를 벤다.";
        enemy.SkillDist = enemy.AtkDist;
        enemy.Cool = 5f;
        enemy.DropGold = 8;
        EnemyData.Add((int)enemy.Job, enemy);
        #endregion

        #region GoblinSwordShield
        enemy = new EnemyData();
        enemy.Name = "칼든 고블린 방패병";
        enemy.Job = EnemyJob.GoblinSwordShield;
        enemy.Grade = 1;
        enemy.MaxHp = 200;
        enemy.CurHp = enemy.MaxHp;
        enemy.Atk = 10f;
        enemy.AtkDist = MeleeDistance;
        enemy.AtkDelay = 1f;
        enemy.AtkType = "Melee";
        enemy.MoveSpeed = 0.003f;
        enemy.Skill_Name = "전방베기";
        enemy.Skill_Tip = "전방에 있는 적 모두를 벤다.";
        enemy.SkillDist = enemy.AtkDist;
        enemy.Cool = 5f;
        enemy.DropGold = 10;
        EnemyData.Add((int)enemy.Job, enemy);
        #endregion

        #region GoblinAx
        enemy = new EnemyData();
        enemy.Name = "도끼든 고블린";
        enemy.Job = EnemyJob.GoblinAx;
        enemy.Grade = 1;
        enemy.MaxHp = 150;
        enemy.CurHp = enemy.MaxHp;
        enemy.Atk = 15f;
        enemy.AtkDist = MeleeDistance;
        enemy.AtkDelay = 1f;
        enemy.AtkType = "Melee";
        enemy.MoveSpeed = 0.004f;
        enemy.Skill_Name = "전방베기";
        enemy.Skill_Tip = "전방에 있는 적 모두를 벤다.";
        enemy.SkillDist = enemy.AtkDist;
        enemy.Cool = 5f;
        enemy.DropGold = 12;
        EnemyData.Add((int)enemy.Job, enemy);
        #endregion

        #region GoblinBow
        enemy = new EnemyData();
        enemy.Name = "활든 고블린";
        enemy.Job = EnemyJob.GoblinBow;
        enemy.Grade = 1;
        enemy.MaxHp = 100;
        enemy.CurHp = enemy.MaxHp;
        enemy.Atk = 12f;
        enemy.AtkDist = RangeDistance;
        enemy.AtkDelay = 1f;
        enemy.AtkType = "Bow";
        enemy.MoveSpeed = 0.004f;
        enemy.Skill_Name = "전방베기";
        enemy.Skill_Tip = "전방에 있는 적 모두를 벤다.";
        enemy.SkillDist = enemy.AtkDist;
        enemy.Cool = 5f;
        enemy.DropGold = 8;
        EnemyData.Add((int)enemy.Job, enemy);
        #endregion

        #region GoblinMagicon
        enemy = new EnemyData();
        enemy.Name = "마법쓰는 고블린";
        enemy.Job = EnemyJob.GoblinMagicon;
        enemy.Grade = 1;
        enemy.MaxHp = 100;
        enemy.CurHp = enemy.MaxHp;
        enemy.Atk = 8f;
        enemy.AtkDist = RangeDistance;
        enemy.AtkDelay = 1f;
        enemy.AtkType = "Magic";
        enemy.MoveSpeed = 0.004f;
        enemy.Skill_Name = "전방베기";
        enemy.Skill_Tip = "전방에 있는 적 모두를 벤다.";
        enemy.SkillDist = enemy.AtkDist;
        enemy.Cool = 5f;
        enemy.DropGold = 7;
        EnemyData.Add((int)enemy.Job, enemy);
        #endregion

        #region GoblinAxShield
        enemy = new EnemyData();
        enemy.Name = "도끼든 고블린 방패병";
        enemy.Job = EnemyJob.GoblinAxShield;
        enemy.Grade = 2;
        enemy.MaxHp = 250;
        enemy.CurHp = enemy.MaxHp;
        enemy.Atk = 20f;
        enemy.AtkDist = MeleeDistance;
        enemy.AtkDelay = 1f;
        enemy.AtkType = "Melee";
        enemy.MoveSpeed = 0.003f;
        enemy.Skill_Name = "전방베기";
        enemy.Skill_Tip = "전방에 있는 적 모두를 벤다.";
        enemy.SkillDist = enemy.AtkDist;
        enemy.Cool = 5f;
        enemy.DropGold = 20;
        EnemyData.Add((int)enemy.Job, enemy);
        #endregion

        #region GoblinDoubleAx
        enemy = new EnemyData();
        enemy.Name = "도끼 두개 고블린";
        enemy.Job = EnemyJob.GoblinDoubleAx;
        enemy.Grade = 2;
        enemy.MaxHp = 200;
        enemy.CurHp = enemy.MaxHp;
        enemy.Atk = 25f;
        enemy.AtkDist = MeleeDistance;
        enemy.AtkDelay = 1f;
        enemy.AtkType = "Melee";
        enemy.MoveSpeed = 0.003f;
        enemy.Skill_Name = "전방베기";
        enemy.Skill_Tip = "전방에 있는 적 모두를 벤다.";
        enemy.SkillDist = enemy.AtkDist;
        enemy.Cool = 5f;
        enemy.DropGold = 23;
        EnemyData.Add((int)enemy.Job, enemy);
        #endregion

        #region GoblinKing
        enemy = new EnemyData();
        enemy.Name = "고블린 킹";
        enemy.Job = EnemyJob.GoblinKing;
        enemy.Grade = 10;
        enemy.MaxHp = 550;
        enemy.CurHp = enemy.MaxHp;
        enemy.Atk = 35f;
        enemy.AtkDist = MeleeDistance;
        enemy.AtkDelay = 1f;
        enemy.AtkType = "Melee";
        enemy.MoveSpeed = 0.003f;
        enemy.Skill_Name = "전방베기";
        enemy.Skill_Tip = "전방에 있는 적 모두를 벤다.";
        enemy.SkillDist = enemy.AtkDist;
        enemy.Cool = 5f;
        enemy.DropGold = 500;
        EnemyData.Add((int)enemy.Job, enemy);
        #endregion


        return EnemyData;
    }

}
