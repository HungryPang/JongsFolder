using UnityEngine;
using System.Collections;

public class MenuSystem : MonoBehaviour {
    public GameObject menuImage = null;
    MouseSystem mouse = null;

    Continue cont     = null;
    Quit quit         = null;
    exitMenu exitMenu = null;

    bool enable = false;
	// Use this for initialization
	void Start () {
        cont     = GetComponentInChildren<Continue>();
        quit     = GetComponentInChildren<Quit>();
        exitMenu = GetComponentInChildren<exitMenu>();
        mouse    = FindObjectOfType<MouseSystem>() as MouseSystem;

        OffMenu();
    }
	
	// Update is called once per frame
	void Update () {
        if (enable && Input.GetMouseButtonDown(0))
            CheckMenuClick(mouse);
    }

    public void OnMenu()
    {
        Time.timeScale = 0.0f;
        enable = true;
        _SetAble();

    }

    public void OffMenu()
    {
        Time.timeScale = 1.0f;
        enable = false;
        _SetAble();
    }

    void _SetAble()
    {
        menuImage.GetComponent<SpriteRenderer>().enabled = enable;
        cont.SetAble(enable);
        quit.SetAble(enable);
        exitMenu.SetAble(enable);
    }

    public void CheckMenuClick(MouseSystem mouse)
    {
        cont.CollideCheck(mouse);
        quit.CollideCheck(mouse);
        exitMenu.CollideCheck(mouse);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (false == mouse.isClick) return;
        if (false == enabled) return;
        if (collider.name == "Mouse")
            OnMenu();
    }

}
