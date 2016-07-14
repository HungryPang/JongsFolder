﻿using UnityEngine;
using System.Collections;

public class HandleAnimalManager : MonoBehaviour {
    public SpriteScript handledAnimalSprite = null;
    public SpriteScript handledLikeFood     = null;
    public SpriteScript handledNormalFood   = null;
    public SpriteScript handledHateFood     = null;

    SpriteScript[] FoodArray = new SpriteScript[3];
    AnimalSystem.Animal handledAnimal = null;

    // Use this for initialization
    void Start () {
        FoodArray[0] = handledLikeFood;
        FoodArray[1] = handledNormalFood;
        FoodArray[2] = handledHateFood;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Handle(AnimalSystem.Animal animal, PlayGameResourcesMgr resourceMgr)
    {
        handledAnimal = animal;
        handledAnimalSprite.SetSprite(resourceMgr.animalSpriteArray[(int)animal.animalType]);

        int index = 0;
        foreach(SpriteScript spriteTarget in FoodArray)
        {
            if (FoodSystem.FoodTypes.eFoodNone != animal.canEatFood[index])
                spriteTarget.SetSprite(resourceMgr.foodSpriteArray[(int)animal.canEatFood[index]]);
            else
                spriteTarget.SetSprite(null);

            ++index;
        }
    }

    public bool canEatFood(FoodSystem.FoodTypes type)
    {
        if (null == handledAnimal) return false;
        return handledAnimal.CanEat(type);
    }
}