using UnityEngine;
using System.Collections;

public class MenuInterface : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetAble(bool value)
    {
        enabled = value;
        GetComponent<SpriteRenderer>().enabled = value;
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
