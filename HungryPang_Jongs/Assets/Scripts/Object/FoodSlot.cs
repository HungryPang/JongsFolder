using UnityEngine;
using System.Collections;
//using FoodSystem;
public class FoodSlot : MonoBehaviour {
    public GameSystem gameMgr = null;

    Sprite[] m_ArrEffectDust = null;
    bool bombing = false;
    float bombTime = 0.0f;

    bool bEffectStart = false;
    float fEffectTime = 0.0f;
    Vector3 initScale;
    float bombAnimTime = 0.15f;
    float effectAnimTime = 0.35f;

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
        gameMgr = GetComponentInParent<GameSystem>();
        m_ArrEffectDust = gameMgr.resourceMgr.eDustSpriteArray;
    }
	
	// Update is called once per frame
	void Update () {
        if (bombing)
        {
            bombTime += Time.deltaTime;
            float scaleValue = Mathf.Sin(Mathf.Deg2Rad * (bombTime * 90.0f));
            transform.localScale = new Vector3(initScale.x + scaleValue, initScale.y + scaleValue, 1.0f);

            if (bombAnimTime < bombTime)
            {
                _EffectTime();
            }
        }
        else if(bEffectStart)
        {
            fEffectTime += Time.deltaTime;
            float fFrameSpeed = m_ArrEffectDust.Length;
            int nFrame = (int)((fEffectTime * fFrameSpeed) / effectAnimTime);

            if (nFrame >= m_ArrEffectDust.Length)
            {
                _BombEnd();
            }
            else
                GetComponent<SpriteRenderer>().sprite = m_ArrEffectDust[nFrame];

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

    void _EffectTime()
    {
        bEffectStart = true;
        bombing = false;
        bombTime = 0.0f;
        transform.localScale = initScale;
    }
    void _BombEnd()
    {
        fEffectTime = 0.0f;
        bEffectStart = false;
        GetComponent<SpriteRenderer>().sortingOrder = 0;

        gameMgr.changeFoodSlot(this);
    }
}
