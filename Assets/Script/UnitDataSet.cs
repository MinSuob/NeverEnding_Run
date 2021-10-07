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
        unit.Atk = 10;
        unit.AtkDist = MeleeDistance;
        unit.AtkDelay = 1f;
        unit.AtkType = "Melee";
        unit.AtkName = "CFX_Poof";
        unit.Skill_Name = "CFX4AuraBubbleC";
        unit.Skill_Tip = "전체 체력의 50% 즉시 회복, 10초간 공격력이 100% 상승";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
        unit.LevelUpGold = 5;
        unit.GradeUpDia = 100;
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
        unit.Skill_Tip = "모든 적들에게 공격력의 80% 데미지";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
        unit.LevelUpGold = 5;
        unit.GradeUpDia = 100;
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
        unit.Skill_Tip = "독가스에 중독시켜 3초동안 매 초 마다 공격력의 100% 데미지";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 20;
        unit.LevelUpGold = 5;
        unit.GradeUpDia = 100;
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
        unit.AtkDelay = 2.1f;
        unit.AtkType = "Magic";
        unit.AtkName = "CFX4HitPaintC(Cyan)";
        unit.Skill_Name = "IceSpear";
        unit.Skill_Tip = "얼음 기둥을 소환해 공격력의 150% 데미지, 2초간 빙결";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 20;
        unit.LevelUpGold = 5;
        unit.GradeUpDia = 100;
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
        unit.Skill_Tip = "불 기둥을 소환해 3초동안 매 초 마다 50% 데미지 ( 폭발데미지 공격력의 100% 데미지 )";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
        unit.LevelUpGold = 5;
        unit.GradeUpDia = 100;
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
        unit.AtkDelay = 2.1f;
        unit.AtkType = "Magic";
        unit.AtkName = "CFX_ElectricityBall";
        unit.Skill_Name = "Spark";
        unit.Skill_Tip = "스파크를 날려 공격력의 100% 데미지, 2초간 기절";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 20;
        unit.LevelUpGold = 5;
        unit.GradeUpDia = 100;
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
        unit.Skill_Tip = "5초동안 매 초 마다 전체 체력의 10% 회복, 공격력의 50% 데미지";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
        unit.LevelUpGold = 5;
        unit.GradeUpDia = 100;
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
        unit.AtkDelay = 0.7f;
        unit.AtkType = "Melee";
        unit.AtkName = "CFX4HitPow";
        unit.Skill_Name = "CFX2_Blood";
        unit.Skill_Tip = "모든 적들에게 공격력의 50% 데미지";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
        unit.LevelUpGold = 5;
        unit.GradeUpDia = 100;
        Unitdata.Add((int)unit.Job, unit);
        #endregion

        #region Unit8
        unit = new UnitData();
        unit.Name = "방패병";
        unit.Char_Tip = "방패병";
        unit.Job = Job.Unit8;
        unit.Grade = 1;
        unit.Piece = 0;
        unit.MaxPiece = 20;
        unit.Level = 1;
        unit.MaxHp = 150;
        unit.CurHp = unit.MaxHp;
        unit.Atk = 10f;
        unit.AtkDist = MeleeDistance;
        unit.AtkDelay = 1f;
        unit.AtkType = "Melee";
        unit.AtkName = "CFX_Poof";
        unit.Skill_Name = "VenomSpell";
        unit.Skill_Tip = "공격력의 200%만큼 즉시 회복";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
        unit.LevelUpGold = 5;
        unit.GradeUpDia = 100;
        Unitdata.Add((int)unit.Job, unit);
        #endregion

        #region Unit9
        unit = new UnitData();
        unit.Name = "사냥꾼";
        unit.Char_Tip = "사냥꾼";
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
        unit.Skill_Tip = "관통하는 창을 던진다. 공격력의 100% 데미지";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 20;
        unit.LevelUpGold = 5;
        unit.GradeUpDia = 100;
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
        unit.Skill_Tip = "땅을 내려쳐 공격력의 150% 데미지, 2초간 기절";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
        unit.LevelUpGold = 5;
        unit.GradeUpDia = 100;
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
        unit.Skill_Tip = "관퉁하는 화살로 공격한다. 공격력의 120% 데미지";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 20;
        unit.LevelUpGold = 5;
        unit.GradeUpDia = 100;
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
        unit.Skill_Tip = "5초동안 매 초 마다 전체 체력의 20% + 공격력의 100%만큼 체력 회복";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 20;
        unit.LevelUpGold = 5;
        unit.GradeUpDia = 100;
        Unitdata.Add((int)unit.Job, unit);
        #endregion

        #region Unit13
        unit = new UnitData();
        unit.Name = "기사";
        unit.Char_Tip = "기사";
        unit.Job = Job.Unit13;
        unit.Grade = 2;
        unit.Piece = 0;
        unit.MaxPiece = 20;
        unit.Level = 1;
        unit.MaxHp = 300;
        unit.CurHp = unit.MaxHp;
        unit.Atk = 25;
        unit.AtkDist = MeleeDistance;
        unit.AtkDelay = 1.1f;
        unit.AtkType = "Melee";
        unit.AtkName = "CFX_Poof";
        unit.Skill_Name = "BattleGear-Sword";
        unit.Skill_Tip = "빛의 검을 소환해 공격력의 500% 데미지, 2초간 기절";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
        unit.LevelUpGold = 500;
        unit.GradeUpDia = 300;
        Unitdata.Add((int)unit.Job, unit);
        #endregion

        #region Unit14
        unit = new UnitData();
        unit.Name = "헌터";
        unit.Char_Tip = "헌터";
        unit.Job = Job.Unit14;
        unit.Grade = 2;
        unit.Piece = 0;
        unit.MaxPiece = 20;
        unit.Level = 1;
        unit.MaxHp = 220;
        unit.CurHp = unit.MaxHp;
        unit.Atk = 20;
        unit.AtkDist = RangeDistance;
        unit.AtkDelay = 2f;
        unit.AtkType = "Bow";
        unit.AtkName = "CFX3_Hit_Misc_B_Gravity";
        unit.Skill_Name = "ArrowRain";
        unit.Skill_Tip = "화살들이 하늘에서 쏟아져 3초동안 매 초 마다 공격력의 150% 데미지";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
        unit.LevelUpGold = 500;
        unit.GradeUpDia = 300;
        Unitdata.Add((int)unit.Job, unit);
        #endregion

        #region Unit15
        unit = new UnitData();
        unit.Name = "포이즌";
        unit.Char_Tip = "포이즌";
        unit.Job = Job.Unit15;
        unit.Grade = 2;
        unit.Piece = 0;
        unit.MaxPiece = 20;
        unit.Level = 1;
        unit.MaxHp = 220;
        unit.CurHp = unit.MaxHp;
        unit.Atk = 20;
        unit.AtkDist = RangeDistance;
        unit.AtkDelay = 2;
        unit.AtkType = "Magic";
        unit.AtkName = "CFX_Virus";
        unit.Skill_Name = "CFX2_EnemyDeathSkull";
        unit.Skill_Name2 = "CFX2_BatsCloud";
        unit.Skill_Tip = "중독시키는 박쥐를 소환 3초동안 매 초 마다 공격력의 200% 데미지";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
        unit.LevelUpGold = 500;
        unit.GradeUpDia = 300;
        Unitdata.Add((int)unit.Job, unit);
        #endregion

        #region Unit16
        unit = new UnitData();
        unit.Name = "아이스";
        unit.Char_Tip = "아이스";
        unit.Job = Job.Unit16;
        unit.Grade = 2;
        unit.Piece = 0;
        unit.MaxPiece = 20;
        unit.Level = 1;
        unit.MaxHp = 220;
        unit.CurHp = unit.MaxHp;
        unit.Atk = 18;
        unit.AtkDist = RangeDistance;
        unit.AtkDelay = 2;
        unit.AtkType = "Magic";
        unit.AtkName = "CFX2_Big_Splash(NoCollision)";
        unit.Skill_Name = "IceSpear2";
        unit.Skill_Tip = "전방으로 얼음송곳을 날린다. 3초동안 매 초 마다 공격력의 100% 데미지";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
        unit.LevelUpGold = 500;
        unit.GradeUpDia = 300;
        Unitdata.Add((int)unit.Job, unit);
        #endregion

        #region Unit17
        unit = new UnitData();
        unit.Name = "파이어";
        unit.Char_Tip = "파이어";
        unit.Job = Job.Unit17;
        unit.Grade = 2;
        unit.Piece = 0;
        unit.MaxPiece = 20;
        unit.Level = 1;
        unit.MaxHp = 220;
        unit.CurHp = unit.MaxHp;
        unit.Atk = 22;
        unit.AtkDist = RangeDistance;
        unit.AtkDelay = 2;
        unit.AtkType = "Magic";
        unit.AtkName = "CFX4HitB(Orange)";
        unit.Skill_Name = "Fireball";
        unit.Skill_Tip = "메테오를 떨어트린다. 공격력의 400% 데미지, 2초간 기절";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
        unit.LevelUpGold = 500;
        unit.GradeUpDia = 300;
        Unitdata.Add((int)unit.Job, unit);
        #endregion

        #region Unit18
        unit = new UnitData();
        unit.Name = "라이트닝";
        unit.Char_Tip = "라이트닝";
        unit.Job = Job.Unit18;
        unit.Grade = 2;
        unit.Piece = 0;
        unit.MaxPiece = 20;
        unit.Level = 1;
        unit.MaxHp = 220;
        unit.CurHp = unit.MaxHp;
        unit.Atk = 20;
        unit.AtkDist = RangeDistance;
        unit.AtkDelay = 2;
        unit.AtkType = "Magic";
        unit.AtkName = "CFX2_SparksHit_BSphere";
        unit.Skill_Name = "CFX3_Hit_Electric_A_Ground";
        unit.Skill_Name2 = "CFX3_Hit_Electric_C_Air";
        unit.Skill_Tip = "스파크를 터트린다. 공격력의 300% 데미지, 2초간 기절";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
        unit.LevelUpGold = 500;
        unit.GradeUpDia = 300;
        Unitdata.Add((int)unit.Job, unit);
        #endregion

        #region Unit19
        unit = new UnitData();
        unit.Name = "시프";
        unit.Char_Tip = "시프";
        unit.Job = Job.Unit19;
        unit.Grade = 2;
        unit.Piece = 0;
        unit.MaxPiece = 20;
        unit.Level = 1;
        unit.MaxHp = 250;
        unit.CurHp = unit.MaxHp;
        unit.Atk = 20;
        unit.AtkDist = MeleeDistance;
        unit.AtkDelay = 1f;
        unit.AtkType = "Melee";
        unit.AtkName = "CFX3_Hit_Misc_D";
        unit.Skill_Name = "Shuriken";
        unit.Skill_Tip = "3초동안 지속되는 표창을 던진다. 매 초 마다 공격력의 150% 데미지";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
        unit.LevelUpGold = 500;
        unit.GradeUpDia = 300;
        Unitdata.Add((int)unit.Job, unit);
        #endregion

        #region Unit20
        unit = new UnitData();
        unit.Name = "탱커";
        unit.Char_Tip = "탱커";
        unit.Job = Job.Unit20;
        unit.Grade = 2;
        unit.Piece = 0;
        unit.MaxPiece = 20;
        unit.Level = 1;
        unit.MaxHp = 500;
        unit.CurHp = unit.MaxHp;
        unit.Atk = 30;
        unit.AtkDist = MeleeDistance;
        unit.AtkDelay = 1f;
        unit.AtkType = "Melee";
        unit.AtkName = "CFX3_Hit_SmokePuff";
        unit.Skill_Name = "Butterfly";
        unit.Skill_Tip = "5초동안 매 초 마다 공격력의 150%만큼 체력 회복";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
        unit.LevelUpGold = 500;
        unit.GradeUpDia = 300;
        Unitdata.Add((int)unit.Job, unit);
        #endregion

        #region Unit21
        unit = new UnitData();
        unit.Name = "창병";
        unit.Char_Tip = "창병";
        unit.Job = Job.Unit21;
        unit.Grade = 2;
        unit.Piece = 0;
        unit.MaxPiece = 20;
        unit.Level = 1;
        unit.MaxHp = 350;
        unit.CurHp = unit.MaxHp;
        unit.Atk = 40;
        unit.AtkDist = MeleeDistance;
        unit.AtkDelay = 1.5f;
        unit.AtkType = "Melee";
        unit.AtkName = "CFX_Poof";
        unit.Skill_Name = "CFX3_ResurrectionLight_Circle";
        unit.Skill_Tip = "10초동안 공격력 300% 증가";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
        unit.LevelUpGold = 500;
        unit.GradeUpDia = 300;
        Unitdata.Add((int)unit.Job, unit);
        #endregion

        #region Unit22
        unit = new UnitData();
        unit.Name = "도살자";
        unit.Char_Tip = "도살자";
        unit.Job = Job.Unit22;
        unit.Grade = 2;
        unit.Piece = 0;
        unit.MaxPiece = 20;
        unit.Level = 1;
        unit.MaxHp = 500;
        unit.CurHp = unit.MaxHp;
        unit.Atk = 60;
        unit.AtkDist = MeleeDistance;
        unit.AtkDelay = 2.5f;
        unit.AtkType = "Melee";
        unit.AtkName = "CFX3_Hit_SmokePuff";
        unit.Skill_Name = "CFX2_RockHit";
        unit.Skill_Tip = "땅을 내려쳐 공격력의 300% 데미지, 2초간 기절";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
        unit.LevelUpGold = 500;
        unit.GradeUpDia = 300;
        Unitdata.Add((int)unit.Job, unit);
        #endregion

        #region Unit23
        unit = new UnitData();
        unit.Name = "엘프(남)";
        unit.Char_Tip = "엘프(남)";
        unit.Job = Job.Unit23;
        unit.Grade = 2;
        unit.Piece = 0;
        unit.MaxPiece = 20;
        unit.Level = 1;
        unit.MaxHp = 250;
        unit.CurHp = unit.MaxHp;
        unit.Atk = 45;
        unit.AtkDist = RangeDistance;
        unit.AtkDelay = 2.5f;
        unit.AtkType = "Bow";
        unit.AtkName = "CFX3_Hit_Misc_B_Gravity";
        unit.Skill_Name = "BattleGear-Arrow";
        unit.Skill_Tip = "관퉁하는 빛의 화살로 공격한다. 공격력의 250% 데미지";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
        unit.LevelUpGold = 500;
        unit.GradeUpDia = 300;
        Unitdata.Add((int)unit.Job, unit);
        #endregion

        #region Unit24
        unit = new UnitData();
        unit.Name = "성녀";
        unit.Char_Tip = "성녀";
        unit.Job = Job.Unit24;
        unit.Grade = 2;
        unit.Piece = 0;
        unit.MaxPiece = 20;
        unit.Level = 1;
        unit.MaxHp = 400;
        unit.CurHp = unit.MaxHp;
        unit.Atk = 35;
        unit.AtkDist = MeleeDistance;
        unit.AtkDelay = 2.5f;
        unit.AtkType = "Melee";
        unit.AtkName = "CFX3_Hit_Light_C_Air";
        unit.Skill_Name = "YellowFairyDust";
        unit.Skill_Tip = "5초동안 매 초 마다 공격력의 200%만큼 체력 회복";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
        unit.LevelUpGold = 500;
        unit.GradeUpDia = 300;
        Unitdata.Add((int)unit.Job, unit);
        #endregion

        #region Unit25
        unit = new UnitData();
        unit.Name = "워리어";
        unit.Char_Tip = "워리어";
        unit.Job = Job.Unit25;
        unit.Grade = 3;
        unit.Piece = 0;
        unit.MaxPiece = 20;
        unit.Level = 1;
        unit.MaxHp = 1200;
        unit.CurHp = unit.MaxHp;
        unit.Atk = 150;
        unit.AtkDist = MeleeDistance;
        unit.AtkDelay = 1f;
        unit.AtkType = "Melee";
        unit.AtkName = "CFX4SparksExplosionB";
        unit.Skill_Name = "BladeStorm";
        unit.Skill_Tip = "빛의 검들을 소환해 공격력의 1500% 데미지";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
        unit.LevelUpGold = 50000;
        unit.GradeUpDia = 1000;
        Unitdata.Add((int)unit.Job, unit);
        #endregion

        #region Unit26
        unit = new UnitData();
        unit.Name = "거인";
        unit.Char_Tip = "거인";
        unit.Job = Job.Unit26;
        unit.Grade = 3;
        unit.Piece = 0;
        unit.MaxPiece = 20;
        unit.Level = 1;
        unit.MaxHp = 1500;
        unit.CurHp = unit.MaxHp;
        unit.Atk = 300;
        unit.AtkDist = MeleeDistance;
        unit.AtkDelay = 2f;
        unit.AtkType = "Melee";
        unit.AtkName = "CFX_MagicPoof";
        unit.Skill_Name = "Explosion9";
        unit.Skill_Tip = "바닥을 내리찍어 공격력의 1000% 데미지";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
        unit.LevelUpGold = 50000;
        unit.GradeUpDia = 1000;
        Unitdata.Add((int)unit.Job, unit);
        #endregion

        #region Unit27
        unit = new UnitData();
        unit.Name = "자이언트";
        unit.Char_Tip = "자이언트";
        unit.Job = Job.Unit27;
        unit.Grade = 3;
        unit.Piece = 0;
        unit.MaxPiece = 20;
        unit.Level = 1;
        unit.MaxHp = 1500;
        unit.CurHp = unit.MaxHp;
        unit.Atk = 250;
        unit.AtkDist = MeleeDistance;
        unit.AtkDelay = 2.5f;
        unit.AtkType = "Melee";
        unit.AtkName = "CFX3_Hit_SmokePuff";
        unit.Skill_Name = "Explosion8";
        unit.Skill_Tip = "바닥을 내리찍어 공격력의 2000% 데미지";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
        unit.LevelUpGold = 50000;
        unit.GradeUpDia = 1000;
        Unitdata.Add((int)unit.Job, unit);
        #endregion

        return Unitdata;
    }


}
