using UnityEngine;
using System.Collections;

public class Continue : MenuInterface {

    void Awake()
    {
        InterfaceStart();
    }
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
    }

    public override void Collide()
    {
        if (false == enabled) return;
        Time.timeScale = 1.0f;
        if (Time.timeScale >= 1.0f)
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
