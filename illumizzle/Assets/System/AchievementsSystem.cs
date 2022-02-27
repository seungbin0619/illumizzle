using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class AchievementsSystem : MonoBehaviour {

    #region [ �ν��Ͻ� �ʱ�ȭ ]

    public static AchievementsSystem instance;

    private void Awake() {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    #endregion 

    public void ClearAchievement(string achID) {
        SteamUserStats.SetAchievement(achID);
        SteamUserStats.StoreStats();
    }

}
