using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StageManager : MonoBehaviour
{
    #region Singleton
    private static StageManager instance;
    public static StageManager Instance
    {
        get { return instance; }
    }
    #endregion

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Stage Num
    int CurStage;

    // Stage Max Enemy Count
    int EnemyMaxCount = 30;
    // Stage Cur Enemy Count
    int EnemyCurCount = 0;

    // Stage Enemy 스텟 상승률 함수

    // Stage Reward

    [SerializeField] private Transform TrEnemy;


    private void Start()
    {
        DataManager dm = DataManager.Instance;

        StartCoroutine(EnemyRepawn());

        CurStage = dm.GetCurStage();

    }

    void StageStart()
    {
        

        MaxCountUp(CurStage);
    }

    void MaxCountUp(int Stage)
    {
        if (Stage >= 100)
        {
            if (Stage % 100 == 0)
            {
                EnemyMaxCount++;
            }
        }
    }



    IEnumerator EnemyRepawn()
    {
        DataManager dm = DataManager.Instance;

        for (int i = 0; i < 10; i++)
        {
            int RandomRepawn = Random.Range(0, EnemyMaxCount);

            if (RandomRepawn >= 0 && RandomRepawn <= EnemyMaxCount / 2)
            {
                GameObject EnemyPrefab = Resources.Load<GameObject>("SPUM/SPUM_Units/SPUM_Enemy/" + dm.GetEnemyData(0).Job);
                GameObject CurEnemy = null;
                CurEnemy = Instantiate(EnemyPrefab, TrEnemy);
                CurEnemy.transform.localPosition = new Vector3(0, Random.Range(-0.4f, 0.35f), 11);
            }
            if (RandomRepawn > EnemyMaxCount / 2 && RandomRepawn <= EnemyMaxCount / 1.1f)
            {
                GameObject EnemyPrefab = Resources.Load<GameObject>("SPUM/SPUM_Units/SPUM_Enemy/" + dm.GetEnemyData((CharacterState.EnemyJob)Random.Range(1,6)).Job);
                GameObject CurEnemy = null;
                CurEnemy = Instantiate(EnemyPrefab, TrEnemy);
                CurEnemy.transform.localPosition = new Vector3(0, Random.Range(-0.4f, 0.35f), 12);
            }
            if (RandomRepawn > EnemyMaxCount / 1.1f && RandomRepawn <= EnemyMaxCount)
            {
                GameObject EnemyPrefab = Resources.Load<GameObject>("SPUM/SPUM_Units/SPUM_Enemy/" + dm.GetEnemyData((CharacterState.EnemyJob)Random.Range(6, 8)).Job);
                GameObject CurEnemy = null;
                CurEnemy = Instantiate(EnemyPrefab, TrEnemy);
                CurEnemy.transform.localPosition = new Vector3(0, Random.Range(-0.4f, 0.35f), 13);
            }

            yield return new WaitForSeconds(Random.Range(1, 1.5f));

        }


    }
}