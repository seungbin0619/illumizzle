using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestController : MonoBehaviour{

    //public string sceneName;
    //public void MoveScene() {
    //    SceneManager.LoadScene(sceneName);
    //}

    //public void ExitGame() {
    //    Application.Quit();
    //}

    public void SceneReload() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(gameObject.scene.name);
        SFXSystem.instance.PlaySound(13);
    }
}
