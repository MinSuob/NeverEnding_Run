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
        unit.Atk = 10f;
        unit.AtkDist = MeleeDistance;
        unit.AtkDelay = 1f;
        unit.AtkType = "Melee";
        unit.Skill_Name = "전방베기";
        unit.Skill_Tip = "전방에 있는 적 모두를 벤다.";
        unit.SkillDist = unit.AtkDist;
        unit.Cool = 5f;
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
        unit.Skill_Name = "더블 샷";
        unit.Skill_Tip = "두개의 화살을 발사한다.";
        unit.SkillDist = unit.AtkDist;
        unit.Cool = 3f;
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
        unit.Skill_Name = "포이즌 포그";
        unit.Skill_Tip = "중간 범위의 독 안개를 펼친다.";
        unit.SkillDist = unit.AtkDist;
        unit.Cool = 5f;
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
        unit.Skill_Name = "아이스 볼트";
        unit.Skill_Tip = "공격에 맞은 적을 얼린다.";
        unit.SkillDist = unit.AtkDist;
        unit.Cool = 2f;
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
        unit.Skill_Name = "파이어 볼트";
        unit.Skill_Tip = "공격에 맞은 적에게 화상을 입힌다.";
        unit.SkillDist = unit.AtkDist;
        unit.Cool = 2f;
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
        unit.Skill_Name = "썬더 볼트";
        unit.Skill_Tip = "공격에 맞은 적에게서 전기가 옮겨다녀 주변의 적들을 공격한다.";
        unit.SkillDist = unit.AtkDist;
        unit.Cool = 2f;
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
        unit.Skill_Name = "썬더 볼트"; // 수정
        unit.Skill_Tip = "공격에 맞은 적에게서 전기가 옮겨다녀 주변의 적들을 공격한다."; // 수정
        unit.SkillDist = unit.AtkDist;
        unit.Cool = 2f;
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
        unit.Skill_Name = "급소 찌르기";
        unit.Skill_Tip = "급소를 공격해 치명타를 입힌다.";
        unit.SkillDist = unit.AtkDist;
        unit.Cool = 5f;
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
        unit.Skill_Name = "회복";
        unit.Skill_Tip = "체력을 회복한다.";
        unit.SkillDist = unit.AtkDist;
        unit.Cool = 5f;
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
        unit.Skill_Name = "창 던지기";
        unit.Skill_Tip = "관통하는 창을 던진다.";
        unit.SkillDist = unit.AtkDist;
        unit.Cool = 5f;
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
        unit.Skill_Name = "대지 가르기";
        unit.Skill_Tip = "땅을 내려쳐 적들을 기절 시킨다.";
        unit.SkillDist = unit.AtkDist;
        unit.Cool = 5f;
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
        unit.Skill_Name = "애로우 롤";
        unit.Skill_Tip = "관퉁하는 화살로 공격한다.";
        unit.SkillDist = unit.AtkDist;
        unit.Cool = 2.5f;
        Unitdata.Add((int)unit.Job, unit);
        #endregion

        return Unitdata;
    }


}
