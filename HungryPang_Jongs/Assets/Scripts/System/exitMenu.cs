using UnityEngine;
using System.Collections;

public class exitMenu : MenuInterface {
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

    public override void Collide()
    {
        if (false == enabled) return;
        Time.timeScale = 1.0f;
        if (Time.timeScale >= 1.0f)
            GetComponentInParent<MenuSystem>().OffMenu();
    }
}
