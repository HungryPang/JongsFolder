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

    // Use this for initialization
    void Start () {
        //value = maxValue;
        value = 0;

        nowScale = initScale = transform.localScale;
        //transform.rotation = Quaternion.identity;
    }
	
	// Update is called once per frame
	void Update () {
        GageFluctuation(Time.deltaTime * increaseGagePerSecond);

        float t = rateOfGage;
        nowScale.x = t * initScale.x;
        transform.localScale = nowScale;
    }

    public void GageFluctuation(float delta)
    {
        value += delta;

        value = Mathf.Clamp(value, 0, maxValue);

        //if (value == maxValue) MaxGage();
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
