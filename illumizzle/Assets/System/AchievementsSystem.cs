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

    //public CGameID m_GameID;
    //public AppId_t appId;

    //private void Start() {
    //    appId = SteamUtils.GetAppID();
    //    m_GameID = new CGameID(SteamUtils.GetAppID());
    //}

    public void ClearAchievement(string achID) {
        //if (SteamManager.Initialized) {
        //    SteamUserStats.SetAchievement(achID);
        //    SteamUserStats.StoreStats();
        //}
    }
}
