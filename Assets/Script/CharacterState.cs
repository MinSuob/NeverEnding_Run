using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState
{
    public enum AttType
    {

    }

    public enum Job
    {
        #region Grade 1
        Unit0,  // Sword
        Unit1,  // Bow
        Unit2,  // Poison
        Unit3,  // Ice
        Unit4,  // Fire
        Unit5,  // Lightning
        Unit6,  // Adventurer
        Unit7,  // Thief
        Unit8,  // Tanker
        Unit9,  // Spear
        Unit10, // Double Ax
        Unit11  // Elf
        #endregion
    }

    public enum EnemyJob
    {
        // 고블린
        //0
        GoblinBasic,
        //1
        GoblinSword,
        GoblinSwordShield,
        GoblinAx,
        GoblinBow,
        GoblinMagicon,
        //2
        GoblinAxShield,
        GoblinDoubleAx,
        //Boss
        GoblinKing,

        // 스켈레톤
        //0
        SkeletonBasic,
        //1
        SkeletonSpear0,
        SkeletonBow,
        SkeletonMagicon,
        //2
        SkeletonSpear1,
        //Boss
        SkeletonHorse, // 둘 중에
        SkeletonKing,  // 하나 보스로 아니면 새로
    }

}
