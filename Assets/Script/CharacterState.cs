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
        Unit11, // Elf
        Unit12,  // 성기사
        #endregion
        #region Grade 2
        Unit13,  // Sword2
        Unit14,  // Bow2
        Unit15,  // Poison2
        Unit16,  // Ice2
        Unit17,  // Fire2
        Unit18,  // Lightning2
        Unit19,  // Thief2
        Unit20,  // Tanker2
        Unit21,  // Spear2
        Unit22,  // Double Ex2
        Unit23, // Elf2
        Unit24, // 성기사2
        #endregion
        #region Grade 3
        Unit25,  // Sword3
        Unit26,  // Tanker2
        Unit27   // Double Ex3
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
