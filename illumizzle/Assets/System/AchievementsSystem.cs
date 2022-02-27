using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class AchievementsSystem : MonoBehaviour {

    #region [ 인스턴스 초기화 ]

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
