using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDistanceBox : MonoBehaviour
{
    UnitFsm unitfsm;

    [HideInInspector] public BoxCollider2D DistanceSize;

    private List<string> DeckData = new List<string>();

    bool TriggerOn;

    private void Start()
    {
        DeckData = DataManager.Instance.GetDeckData();

        unitfsm = gameObject.transform.parent.gameObject.GetComponent<UnitFsm>();
        DistanceSize = gameObject.GetComponent<BoxCollider2D>();

        ReSize();
    }

    private void OnTriggerEnter2D(Collider2D Enemy)
    {
        if (Enemy.tag == "Enemy")
        {
            if (unitfsm.Fight_On == false)
            {
                unitfsm.Fight_On = true;
                unitfsm.StartCoroutine(unitfsm.Attack(Enemy));
                DistanceSize.offset = new Vector2(5f, 0.1f);
            }
        }   
        
    }

    public void ReSize()
    {
        int MySlotNum = DeckData.FindIndex(num => num.Contains(unitfsm.job.ToString()));
        BoxSize(MySlotNum);
    }

    void BoxSize(int SlotNum)
    {
        UnitData unit = DataManager.Instance.GetUnitData(unitfsm.job);
        switch (SlotNum)
        {
            case 0:
                if (unit.AtkType == "Melee")
                {
                    DistanceSize.offset = new Vector2(-0.5f, 0.1f);
                    DistanceSize.size = new Vector2(0.5f, 1);
                }
                else
                {
                    DistanceSize.offset = new Vector2(-1.4f, 0.1f);
                    DistanceSize.size = new Vector2(2.2f, 1);
                }
                break;
            case 1:
                DistanceSize.offset = new Vector2(-1.7f, 0.1f);
                DistanceSize.size = new Vector2(2.8f, 1);
                break;
            case 2:
                DistanceSize.offset = new Vector2(-2.05f, 0.1f);
                DistanceSize.size = new Vector2(3.4f, 1);
                break;
            case 3:
                
                DistanceSize.offset = new Vector2(-2.3f, 0.1f);
                DistanceSize.size = new Vector2(4, 1);
                break;
            case 4:
                
                DistanceSize.offset = new Vector2(-2.65f, 0.1f);
                DistanceSize.size = new Vector2(4.6f, 1);
                break;
        }
    }
}
