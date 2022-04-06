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

    public CGameID m_GameID;
    public AppId_t appId;

#if !UNITY_EDITOR
    private void Start() {
        appId = SteamUtils.GetAppID();
        m_GameID = new CGameID(SteamUtils.GetAppID());
    }
#endif

    public void ClearAchievement(string achID) {
#if UNITY_EDITOR
        return;
#endif
        if (SteamManager.Initialized) {
            SteamUserStats.SetAchievement(achID);
            SteamUserStats.StoreStats();
        }
    }

}
