using UnityEngine;
using System.Collections;

public class PlayGameResourcesMgr : MonoBehaviour {
    public string foodSpritesName = null;
    public string animalSpritesName = null;

    Sprite[] mFoodSprites = null;
    public Sprite[] foodSpriteArray
    {
        get { return mFoodSprites; }
    }

    Sprite[] mAnimalSprites = null;
    public Sprite[] animalSpriteArray
    {
        get { return mAnimalSprites; }
    }


    // Use this for initialization
    void Start () {
        mFoodSprites   = Resources.LoadAll<Sprite>(foodSpritesName.ToString()) as Sprite[];
        mAnimalSprites = Resources.LoadAll<Sprite>(animalSpritesName.ToString()) as Sprite[];
    }

	// Update is called once per frame
	void Update () {
	
	}
}
