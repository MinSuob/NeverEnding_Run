using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    #region Singleton
    private static DataManager instance;
    public static DataManager Instance
    {
        get { return instance; }
    }

    private DataManager()
    {
        // do nothing;
    }

    #endregion

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
