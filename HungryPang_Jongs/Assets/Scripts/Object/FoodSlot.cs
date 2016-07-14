using UnityEngine;
using System.Collections;
//using FoodSystem;
public class FoodSlot : MonoBehaviour {
    public GameSystem gameMgr = null;

    bool bombing = false;
    float bombTime = 0.0f;
    Vector3 initScale;
    public float bombAnimTime = 0.5f;

    FoodSystem.FoodData myFoodData;
    public FoodSystem.FoodData fooddata
    {
        get { return myFoodData; }
        set { myFoodData = value; }
    }

    // Use this for initialization
    void Start () {
        initScale = transform.localScale;
        GetComponent<SpriteRenderer>().sortingOrder = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (bombing)
        {
            bombTime += Time.deltaTime;
            float scaleValue = Mathf.Sin(Mathf.Deg2Rad * (bombTime * 90.0f));
            transform.localScale = new Vector3(initScale.x + scaleValue, initScale.y + scaleValue, 1.0f);

            if (bombAnimTime < bombTime)
                _BombEnd();
        }
	}

    public void settingData(Sprite sprite, FoodSystem.FoodData data)
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
        myFoodData = data;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (gameMgr.gameOver) return;
        if (bombing) return;
        if (false == gameMgr.mouse.isClick) return;
        if (collider.name == "Mouse")
            _ButtonDown();
    }

    void _ButtonDown()
    {
        if (gameMgr.pigTime || gameMgr.handleMgr.canEatFood(myFoodData.type))
            _BombStart();
    }

    void _BombStart()
    {
        bombing = true;
        GetComponent<SpriteRenderer>().sortingOrder = 1;
        gameMgr.PlayerEatFood(fooddata);
    }

    void _BombEnd()
    {
        bombTime = 0.0f;
        bombing = false;
        GetComponent<SpriteRenderer>().sortingOrder = 0;
        transform.localScale = initScale;

        gameMgr.changeFoodSlot(this);
    }
}
