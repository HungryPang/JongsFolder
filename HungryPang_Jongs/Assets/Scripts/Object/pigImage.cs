using UnityEngine;
using System.Collections;

public class pigImage : MonoBehaviour {
    public Gage pigTimeGage = null;
    public Vector3 initPos;
    public Vector3 endPos;
    GameSystem gameMgr = null;

    Vector3 initScale;
	// Use this for initialization
	void Start () {
        //initPos = transform.position;
        gameMgr = GetComponentInParent<GameSystem>();
        initScale = transform.localScale;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(initPos, endPos, pigTimeGage.rateOfGage);

        if (gameMgr.pigTime)
        {
            initScale.x = 1;
            transform.localScale = initScale;
        }
        else
        {
            initScale.x = -1;
            transform.localScale = initScale;
        }

    }
}
