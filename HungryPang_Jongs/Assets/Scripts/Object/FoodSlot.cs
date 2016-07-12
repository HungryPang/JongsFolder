using UnityEngine;
using System.Collections;
//using FoodSystem;
public class FoodSlot : MonoBehaviour {
    public GameSystem gameMgr = null;

    FoodSystem.FoodData myFoodData;
    public FoodSystem.FoodData fooddata
    {
        get { return myFoodData; }
        set { myFoodData = value; }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void settingData(Sprite sprite, int data)
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (false == gameMgr.mouse.isClick) return;
        if (collider.name == "Mouse")
            _ButtonDown();
    }

    void _ButtonDown()
    {
        gameMgr.changeFoodSlot(this);
    }
}
