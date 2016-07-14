using UnityEngine;
using System.Collections;

public class SpriteScript : MonoBehaviour {

    Sprite basicSprite = null;
    void Awake()
    {
        basicSprite = GetComponent<SpriteRenderer>().sprite;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetSprite(Sprite sprite)
    {
        if (sprite)
            GetComponent<SpriteRenderer>().sprite = sprite;
        else
            GetComponent<SpriteRenderer>().sprite = basicSprite;
       
    }
}
