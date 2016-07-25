using UnityEngine;
using System.Collections;

public class HandleAnimalManager : MonoBehaviour {
    public SpriteScript handledAnimalSprite = null;
    public SpriteScript handledLikeFood     = null;
    public SpriteScript handledNormalFood   = null;
    public SpriteScript handledHateFood     = null;

    SpriteScript[] FoodArray = new SpriteScript[3];
    AnimalSystem.Animal handledAnimal = null;
    public AnimalSlot handleAnimalSlot = null;

    public csLifeGage LifeGage = null;
    GameSystem gameMgr = null;

    // Use this for initialization
    void Start () {
        FoodArray[0] = handledLikeFood;
        FoodArray[1] = handledNormalFood;
        FoodArray[2] = handledHateFood;

        //LifeGage = GetComponent<csLifeGage>();
        

        //Handle(handleAnimalSlot, gameMgr.resourceMgr);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Handle(AnimalSlot slot, PlayGameResourcesMgr resourceMgr)
    {

        handleAnimalSlot = slot;
        handledAnimal    = slot.myAnimal;
        handledAnimalSprite.SetSprite(resourceMgr.animalSpriteArray[(int)handledAnimal.animalType]);

        int index = 0;
        foreach(SpriteScript spriteTarget in FoodArray)
        {
            if (FoodSystem.FoodTypes.eFoodNone != handledAnimal.canEatFood[index])
            {
                //print(LifeGage);

                spriteTarget.SetSprite(resourceMgr.foodSpriteArray[(int)handledAnimal.canEatFood[index]]);
            }
            else
                spriteTarget.SetSprite(null);

            ++index;
        }
    }

    public bool canEatFood(FoodSystem.FoodTypes type)
    {
        if (null == handledAnimal) return false;
        //print("클릭!!");
        return handledAnimal.CanEat(type);
    }

    public void InitHandleAnimal(AnimalSlot slot)
    {
        //
        gameMgr = FindObjectOfType(typeof(GameSystem)) as GameSystem;
        FoodArray[0] = handledLikeFood;
        FoodArray[1] = handledNormalFood;
        FoodArray[2] = handledHateFood;

        //print(gameMgr);
        Handle(slot, gameMgr.resourceMgr);
    }
}
