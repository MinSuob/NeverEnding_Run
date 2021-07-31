using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataSet : MonoBehaviour
{
    public static UserData DataLoad()
    {
        UserData Userdata = new UserData();
        Userdata.UserName = Social.localUser.userName;
        Userdata.Gold = 0;
        Userdata.Diamond = 0;
        Userdata.Stage = 1;
        Userdata.SFX_Volume = 0.5f;
        Userdata.Music_Volume = 0.5f;


        return Userdata;
    }
}
