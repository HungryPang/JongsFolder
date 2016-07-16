using UnityEngine;
using System.Collections;

public class PlayGameResourcesMgr : MonoBehaviour {
    public string foodSpritesName = null;
    public string animalSpritesName = null;
    public string EffectDustName = null;

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

    Sprite[] mDustSprite = null;
    public Sprite[] eDustSpriteArray
    {
        get { return mDustSprite; }
    }

    // Use this for initialization
    void Awake () {
        mFoodSprites   = Resources.LoadAll<Sprite>(foodSpritesName.ToString()) as Sprite[];
        mAnimalSprites = Resources.LoadAll<Sprite>(animalSpritesName.ToString()) as Sprite[];
        mDustSprite = Resources.LoadAll<Sprite>(EffectDustName.ToString()) as Sprite[];
    }

    void Start()
    {

    }

	// Update is called once per frame
	void Update () {
	
	}
}
