using UnityEngine;
using System.Collections;

public class MenuInterface : MonoBehaviour {
    protected SpriteRenderer spriteRenderer = null;
	// Use this for initialization
	void Start () {
        InterfaceStart();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    protected void InterfaceStart()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetAble(bool value)
    {
        enabled = value;
       if (spriteRenderer) spriteRenderer.enabled = value;
        GetComponent<BoxCollider2D>().enabled = value;
    }

    public virtual void Collide()
    {
    }

    public void CollideCheck(MouseSystem mouse)
    {
        if (GetComponent<BoxCollider2D>().OverlapPoint(mouse.GetComponent<Transform>().position))
            Collide();
    }
}
