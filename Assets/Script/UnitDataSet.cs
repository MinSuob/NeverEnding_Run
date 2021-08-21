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
        unit.Grade = 1;
        unit.Piece = 0;
        unit.MaxPiece = 20;
        unit.Level = 1;
        unit.MaxHp = 100;
        unit.CurHp = unit.MaxHp;
        unit.Atk = 30;
        unit.AtkDist = MeleeDistance;
        unit.AtkDelay = 1f;
        unit.AtkType = "Melee";
        unit.AtkName = "CFX_Poof";
        unit.Skill_Name = "CFX4AuraBubbleC";
        unit.Skill_Tip = "공격 시 10%의 확률로 10초동안 공격력과 체력이 100% 상승합니다.";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
        Unitdata.Add((int)unit.Job, unit);
        #endregion

        #region Unit1
        unit = new UnitData();
        unit.Name = "궁수";
        unit.Char_Tip = "궁수";
        unit.Job = Job.Unit1;
        unit.Grade = 1;
        unit.Piece = 0;
        unit.MaxPiece = 20;
        unit.Level = 1;
        unit.MaxHp = 60;
        unit.CurHp = unit.MaxHp;
        unit.Atk = 8f;
        unit.AtkDist = RangeDistance;
        unit.AtkDelay = 2f;
        unit.AtkType = "Bow";
        unit.AtkName = "CFX_Hit_CWhite";
        unit.Skill_Name = "CFX4MagicHit";
        unit.Skill_Tip = "공격 시 10%의 확률로 범위안에 모든적들에게 화살을 날린다.";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
        Unitdata.Add((int)unit.Job, unit);
        #endregion

        #region Unit2
        unit = new UnitData();
        unit.Name = "독 마법사";
        unit.Char_Tip = "독 마법사";
        unit.Job = Job.Unit2;
        unit.Grade = 1;
        unit.Piece = 0;
        unit.MaxPiece = 20;
        unit.Level = 1;
        unit.MaxHp = 60;
        unit.CurHp = unit.MaxHp;
        unit.Atk = 6f;
        unit.AtkDist = RangeDistance;
        unit.AtkDelay = 2f;
        unit.AtkType = "Magic";
        unit.AtkName = "CFX_Virus";
        unit.Skill_Name = "CFX2_WWExplosion_C";
        unit.Skill_Tip = "공격 시 20% 확률로 적을 중독시키는 독안개를 소환한다.\n( 중독된 대상은 공격력의 450% 데미지를 3회에 걸쳐 받습니다. )";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 20;
        Unitdata.Add((int)unit.Job, unit);
        #endregion

        #region Unit3
        unit = new UnitData();
        unit.Name = "빙결 마법사";
        unit.Char_Tip = "빙결 마법사";
        unit.Job = Job.Unit3;
        unit.Grade = 1;
        unit.Piece = 0;
        unit.MaxPiece = 20;
        unit.Level = 1;
        unit.MaxHp = 60;
        unit.CurHp = unit.MaxHp;
        unit.Atk = 5f;
        unit.AtkDist = RangeDistance;
        unit.AtkDelay = 2f;
        unit.AtkType = "Magic";
        unit.AtkName = "CFX4HitPaintC(Cyan)";
        unit.Skill_Name = "IceSpear";
        unit.Skill_Tip = "공격 시 20% 확률로 적을 빙결시키는 얼음송곳을 소환한다.\n( 빙결된 대상은 공격력의 100% 데미지를 받고 3초간 느려집니다. )";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 20;
        Unitdata.Add((int)unit.Job, unit);
        #endregion

        #region Unit4
        unit = new UnitData();
        unit.Name = "불 마법사";
        unit.Char_Tip = "불 마법사";
        unit.Job = Job.Unit4;
        unit.Grade = 1;
        unit.Piece = 0;
        unit.MaxPiece = 20;
        unit.Level = 1;
        unit.MaxHp = 60;
        unit.CurHp = unit.MaxHp;
        unit.Atk = 7f;
        unit.AtkDist = RangeDistance;
        unit.AtkDelay = 2f;
        unit.AtkType = "Magic";
        unit.AtkName = "CFX4HitB(Orange)";
        unit.Skill_Name = "CFX3_Fire_Shield";
        unit.Skill_Name2 = "CFX3_Fire_Explosion";
        unit.Skill_Tip = "공격 시 10% 확률로 불의기둥을 소환한다.\n( 3초간 500%의 데미지를 주고 폭발합니다. ( 폭발 데미지 150% ))";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
        Unitdata.Add((int)unit.Job, unit);
        #endregion

        #region Unit5
        unit = new UnitData();
        unit.Name = "라이트닝 마법사";
        unit.Char_Tip = "라이트닝 마법사";
        unit.Job = Job.Unit5;
        unit.Grade = 1;
        unit.Piece = 0;
        unit.MaxPiece = 20;
        unit.Level = 1;
        unit.MaxHp = 60;
        unit.CurHp = unit.MaxHp;
        unit.Atk = 6f;
        unit.AtkDist = RangeDistance;
        unit.AtkDelay = 2f;
        unit.AtkType = "Magic";
        unit.AtkName = "CFX_ElectricityBall";
        unit.Skill_Name = "Spark";
        unit.Skill_Tip = "공격 시 20% 확률로 기절시키는 스파크를 발사한다.\n( 200%의 데미지를 받고 2초간 기절합니다. )";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 20;
        Unitdata.Add((int)unit.Job, unit);
        #endregion

        #region Unit6
        unit = new UnitData();
        unit.Name = "모험가";
        unit.Char_Tip = "모험가";
        unit.Job = Job.Unit6;
        unit.Grade = 1;
        unit.Piece = 0;
        unit.MaxPiece = 20;
        unit.Level = 1;
        unit.MaxHp = 70;
        unit.CurHp = unit.MaxHp;
        unit.Atk = 9f;
        unit.AtkDist = RangeDistance;
        unit.AtkDelay = 2f;
        unit.AtkType = "Melee";
        unit.AtkName = "CFX_Poof";
        unit.Skill_Name = "CFX2_Wandering_Spirits";
        unit.Skill_Tip = "공격 시 10%의 확률로 반딧불을 소환해 5초동안 공격력의 500%데미지를 줍니다.\n( 반딧불이 존재할 시 1초마다 공격력만큼의 체력을 회복합니다. )";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
        Unitdata.Add((int)unit.Job, unit);
        #endregion

        #region Unit7
        unit = new UnitData();
        unit.Name = "도적";
        unit.Char_Tip = "도적";
        unit.Job = Job.Unit7;
        unit.Grade = 1;
        unit.Piece = 0;
        unit.MaxPiece = 20;
        unit.Level = 1;
        unit.MaxHp = 70;
        unit.CurHp = unit.MaxHp;
        unit.Atk = 6f;
        unit.AtkDist = MeleeDistance;
        unit.AtkDelay = 0.5f;
        unit.AtkType = "Melee";
        unit.AtkName = "CFX4HitPow";
        unit.Skill_Name = "CFX2_Blood";
        unit.Skill_Tip = "공격 시 10%의 확률로 범위내 적들의 급소를 공격해 300%의 데미지를 입힌다.";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
        Unitdata.Add((int)unit.Job, unit);
        #endregion

        #region Unit8
        unit = new UnitData();
        unit.Name = "탱커";
        unit.Char_Tip = "탱커";
        unit.Job = Job.Unit8;
        unit.Grade = 1;
        unit.Piece = 0;
        unit.MaxPiece = 20;
        unit.Level = 1;
        unit.MaxHp = 150;
        unit.CurHp = unit.MaxHp;
        unit.Atk = 10f;
        unit.AtkDist = MeleeDistance;
        unit.AtkDelay = 2f;
        unit.AtkType = "Melee";
        unit.AtkName = "CFX_Poof";
        unit.Skill_Name = "VenomSpell";
        unit.Skill_Tip = "공격 시 10%의 확률로 공격력의 200%만큼 체력을 회복한다.";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
        Unitdata.Add((int)unit.Job, unit);
        #endregion

        #region Unit9
        unit = new UnitData();
        unit.Name = "창병";
        unit.Char_Tip = "창병";
        unit.Job = Job.Unit9;
        unit.Grade = 1;
        unit.Piece = 0;
        unit.MaxPiece = 20;
        unit.Level = 1;
        unit.MaxHp = 120;
        unit.CurHp = unit.MaxHp;
        unit.Atk = 12f;
        unit.AtkDist = MeleeDistance;
        unit.AtkDelay = 1.5f;
        unit.AtkType = "Melee";
        unit.AtkName = "CFX_Poof";
        unit.Skill_Name = "SpearShot";
        unit.Skill_Tip = "공격 시 20%의 확률로 관통하는 창을 던진다. 관통당한 적은 120%의 데미지를 받습니다.";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 20;
        Unitdata.Add((int)unit.Job, unit);
        #endregion

        #region Unit10
        unit = new UnitData();
        unit.Name = "더블액스";
        unit.Char_Tip = "더블액스";
        unit.Job = Job.Unit10;
        unit.Grade = 1;
        unit.Piece = 0;
        unit.MaxPiece = 20;
        unit.Level = 1;
        unit.MaxHp = 150;
        unit.CurHp = unit.MaxHp;
        unit.Atk = 20f;
        unit.AtkDist = RangeDistance;
        unit.AtkDelay = 2.5f;
        unit.AtkType = "Melee";
        unit.AtkName = "CFX_Poof";
        unit.Skill_Name = "CFX4DrillAirHit(NOCOLLISION)";
        unit.Skill_Tip = "공격시 10%의 확률로 땅을 내려쳐 공격력의 250%데미지를 주고 기절 시킨다.";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
        Unitdata.Add((int)unit.Job, unit);
        #endregion

        #region Unit11
        unit = new UnitData();
        unit.Name = "엘프";
        unit.Char_Tip = "엘프";
        unit.Job = Job.Unit11;
        unit.Grade = 1;
        unit.Piece = 0;
        unit.MaxPiece = 20;
        unit.Level = 1;
        unit.MaxHp = 90;
        unit.CurHp = unit.MaxHp;
        unit.Atk = 12f;
        unit.AtkDist = RangeDistance;
        unit.AtkDelay = 2.5f;
        unit.AtkType = "Bow";
        unit.AtkName = "CFX_Hit_CWhite";
        unit.Skill_Name = "ArrowRoll";
        unit.Skill_Tip = "공격시 20%의 확률로 관퉁하는 화살로 공격한다. 관통당한 적은 150%의 데미지를 받습니다.";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 20;
        Unitdata.Add((int)unit.Job, unit);
        #endregion

        #region Unit12
        unit = new UnitData();
        unit.Name = "성기사";
        unit.Char_Tip = "성기사";
        unit.Job = Job.Unit12;
        unit.Grade = 1;
        unit.Piece = 0;
        unit.MaxPiece = 20;
        unit.Level = 1;
        unit.MaxHp = 150;
        unit.CurHp = unit.MaxHp;
        unit.Atk = 10f;
        unit.AtkDist = RangeDistance;
        unit.AtkDelay = 2.5f;
        unit.AtkType = "Melee";
        unit.AtkName = "CFX3_MagicAura_B_Runic";
        unit.Skill_Name = "CFX_Magical_Source";
        unit.Skill_Tip = "공격시 20%의 확률로 빛의 구체를 소환해 5초동안 공격력의 80%만큼 회복한다. ( 성기사의 평타는 공격력만큼 체력을 회복합니다. )";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 20;
        Unitdata.Add((int)unit.Job, unit);
        #endregion

        return Unitdata;
    }


}
