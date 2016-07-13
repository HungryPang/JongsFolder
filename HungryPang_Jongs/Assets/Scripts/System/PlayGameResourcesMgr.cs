using UnityEngine;
using System.Collections;

public class PlayGameResourcesMgr : MonoBehaviour {
    public string foodSpritesName = null;

    Sprite[] mFoodSprites = null;
    public Sprite[] foodSpriteArray
    {
        get { return mFoodSprites; }
    } 

    // Use this for initialization
    void Start () {
        mFoodSprites = Resources.LoadAll<Sprite>(foodSpritesName.ToString()) as Sprite[];
    }

	
	// Update is called once per frame
	void Update () {
	
	}
}
