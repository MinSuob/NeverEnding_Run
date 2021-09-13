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
        unit.Skill_Tip = "공격 시 10%의 확률로 10초동안 공격력이 상승하고 체력이 50% 회복됩니다.";
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
        unit.Skill_Tip = "공격 시 10%의 확률로 범위안에 모든적들에게 공격력의 80%데미지 화살을 날린다.";
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
        unit.AtkDelay = 2.1f;
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
        unit.Skill_Tip = "공격 시 10% 확률로 불의기둥을 소환한다.\n( 1초마다 공격력의 100%데미지로 공격합니다. ( 폭발 데미지 150% ))";
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
        unit.AtkDelay = 2.1f;
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
        unit.Skill_Tip = "공격 시 10%의 확률로 공격력의 200%만큼 체력을 회복한다.";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
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
        unit.Skill_Tip = "공격력의 500%의 빛의 검을 소환 합니다.";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
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
        unit.Skill_Tip = "공격력의 500%의 화살들이 하늘에서 내리칩니다.";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
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
        unit.Skill_Tip = "공격력의 600%의 박쥐를 소환합니다.";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
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
        unit.Skill_Tip = "공격력의 200%의 데미지로 3초동안 공격합니다.";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
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
        unit.Skill_Tip = "공격력의 800%의 메테오를 소환합니다.";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
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
        unit.Skill_Tip = "공격력의 400%의 스파크를 터트립니다.";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
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
        unit.Skill_Tip = "공격력의 300%의 데미지를 3초동안 주는 표창을 던집니다.";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
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
        unit.Skill_Tip = "1초마다 공격력의 150%만큼 회복합니다.";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
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
        unit.Skill_Tip = "10초동안 공격력을 2배 올려줍니다.";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
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
        unit.Skill_Tip = "땅을 내려쳐 공격력의 500%데미지를 주고 2초동안 기절 시킨다."; ;
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
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
        unit.Skill_Tip = "관퉁하는 빛의 화살로 공격한다. 관통당한 적은 300%의 데미지를 받습니다.";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
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
        unit.Skill_Tip = "1초마다 공격력의 150%를 회복시켜주는 정령을 5초간 소환한다.";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
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
        unit.Skill_Tip = "빛의 검들을 소환하여 1500%의 데미지를 줍니다.";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
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
        unit.Skill_Tip = "바닥을 내리찍어 폭발을 일으킨다.";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
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
        unit.Skill_Tip = "바닥을 내리찍어 폭발을 일으킨다.";
        unit.SkillDist = unit.AtkDist;
        unit.SkillOdds = 10;
        Unitdata.Add((int)unit.Job, unit);
        #endregion

        return Unitdata;
    }


}
