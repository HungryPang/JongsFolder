using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {
    public int nextSceneNum = 1;
	// Use this for initialization
	void Start () {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneNum);

    }

    // Update is called once per frame
    void Update () {
    }
}
