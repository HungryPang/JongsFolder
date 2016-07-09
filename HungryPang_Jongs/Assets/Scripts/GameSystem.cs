using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace FoodSystem
{
    public enum FoodTypes
    {
        eFoodCheese = 0,
        eFoodAmond,
        eFoodApple,
        eFoodAnt,
        eFoodRice,
        eFoodMouse,
        eFoodLeaf,
        eFoodAcorn,
        eFoodHay, // 건초
        eFoodFeed,
        eFoodCow,
        eFoodChicken,
        eFoodFire,
        eFoodEgg,
        eFoodCarrot,
        eFoodHorse,
        eFoodPaper,
        eFoodSeed,
        eFoodSheep,
        eFoodBanana,
        eFoodBread,
        eFoodCookedRice, // 밥
        eFoodLarva, // 애벌래
        eFoodbarley,
        eFoodTypesNum
    }

    public struct FoodData
    {
        public FoodTypes type;
        public int score;

        public FoodData(FoodTypes typeVal, int scoreVal)
        {
            type = typeVal;
            score = scoreVal;
        }
    }

    public class FoodManager
    {
        static FoodManager pointer = null;
        FoodData[] foodTypeList = null;

        public static FoodManager getInstance()
        {
            if (null == pointer)
            {
                pointer = new FoodManager();
                pointer.setting();
            }
            return pointer;
        }

        public void setting()
        {
            foodTypeList = new FoodData[(int)FoodTypes.eFoodTypesNum];
            foodTypeList[(int)FoodTypes.eFoodCheese] = new FoodData(FoodTypes.eFoodCheese, 800);
        }
    }
}

public class GameSystem : MonoBehaviour {
    string[] resourcesNameHashArray = new string[10];
    FoodZone foodzone = null;
    int foodtypeNum = 0;
    // Use this for initialization

    LinkedList<FoodSystem.FoodTypes> foodlist;

	void Start () {
        for (int i = 0; i < 10; ++i)
        {                                                       
            resourcesNameHashArray[i] = "number_" + i;
        }

        foodtypeNum = 9; //(int)FoodSystem.FoodTypes.eFoodTypesNum - 1;
        for (int i = 0; i < 1000; ++i)
        {
            int val = Random.Range(0, foodtypeNum);
            foodlist.AddLast((FoodSystem.FoodTypes) val);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
