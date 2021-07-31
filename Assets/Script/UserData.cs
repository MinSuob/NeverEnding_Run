using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData
{
    // 유저 기본 데이터 ( 골드, 다이아, 볼륨등 )
    private string username;

    private long gold;
    private int diamond;

    private int stage;

    private float sfx_volume;   // 효과음
    private float music_volume; // 배경음

    private void saveData(string name, object value)
    {

    }

    public string UserName
    {
        get
        {
            return username;
        }
        set
        {
            username = value;
            saveData("UserName", value);
        }
    }

    public long Gold
    {
        get
        {
            return gold;
        }
        set
        {
            gold = value;
            saveData("Gold", value);
        }
    }

    public int Diamond
    {
        get
        {
            return diamond;
        }
        set
        {
            diamond = value;
            saveData("Diamond", value);
        }
    }

    public int Stage
    {
        get
        {
            return stage;
        }
        set
        {
            stage = value;
            saveData("Stage", value);
        }
    }

    public float SFX_Volume
    {
        get
        {
            return sfx_volume;
        }
        set
        {
            sfx_volume = value;
            saveData("SFX_Volume", value);
        }
    }

    public float Music_Volume
    {
        get
        {
            return music_volume;
        }
        set
        {
            music_volume = value;
            saveData("Music_Volume", value);
        }
    }
}
