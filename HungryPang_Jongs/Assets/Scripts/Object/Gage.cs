using UnityEngine;
using System.Collections;

public class Gage : MonoBehaviour {
    public float increaseGagePerSecond = -10.0f;
    public float value = 100.0f;
    public float maxValue = 100.0f;
    public bool isMax = false;
    public float rateOfGage { get { return value / maxValue; } }

    protected Vector3 initScale;
    protected Vector3 nowScale;

    GameSystem gameMgr = null;

    // Use this for initialization
    void Start () {
        //value = maxValue;
        value = 0;

        gameMgr = GetComponentInParent<GameSystem>();
        nowScale = initScale = transform.localScale;
        transform.localScale = new Vector3(0.0f, initScale.y, initScale.z);
    }
	
	// Update is called once per frame
	void Update () {
        //GageFluctuation(Time.deltaTime * increaseGagePerSecond);

        float fPercent = value / maxValue;
        nowScale.x = fPercent * initScale.x;
        
        if(gameMgr.pigTime || nowScale.x < transform.localScale.x)
            transform.localScale = nowScale;
        else
            iTween.ScaleTo(this.gameObject, iTween.Hash("x", nowScale.x, "time", 1.0f, "easetype", iTween.EaseType.easeOutElastic));
        
    }

    public void GageFluctuation(float delta)
    {
        value += delta;
        value = Mathf.Clamp(value, 0, maxValue);
    }

    public void MaxGage()
    {
        //GetComponent<SpriteRenderer>().color = Color.cyan;
        isMax = true;
    }

    public void MinGage()
    {
        //GetComponent<SpriteRenderer>().color = Color.white;
        isMax = false;
    }
}
