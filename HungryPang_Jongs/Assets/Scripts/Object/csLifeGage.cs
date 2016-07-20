using UnityEngine;
using System.Collections;

public class csLifeGage : MonoBehaviour {

    float fLifeRate = 0.0f;
    public float fLifePoint = 0.0f;
    float fMaxPoint;

    public float fDecrease = 0.0f;
    GameSystem gameMgr = null;

    Vector3 vInitPos;

    void Awake(){
        fMaxPoint = fLifePoint;
        vInitPos = transform.position;
        gameMgr = FindObjectOfType(typeof(GameSystem)) as GameSystem;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        fLifePoint += fDecrease * Time.deltaTime;
        if(fLifePoint <= 0)
        {
            gameMgr.GameOver();
        }
        fLifeRate = fLifePoint / fMaxPoint;

        float fMyPos = Mathf.Lerp(8.0f, 0.0f, fLifeRate);
       //print(fMyPos);
        transform.position = vInitPos - new Vector3(fMyPos, 0.0f, 0.0f);
    }


}
