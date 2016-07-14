using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace FoodSystem
{
    public enum FoodTypes
    {
        eFoodNone = -1,
        eFoodCheese = 0,
        eFoodAmond,
        eFoodApple,
        eFoodCorn,
        eFoodRice,
        eFoodMouse,
        eFoodLeaf,
        eFoodGrass, // 풀
        eFoodAcorn, // 도토리
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
        eFoodBarley,
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

        public FoodData HashFoodData(int type)
        {
            //MonoBehaviour.print(type + " // " + foodTypeList[type].type);
            return foodTypeList[type];
        }
        public FoodData HashFoodData(FoodTypes type)
        {
            return foodTypeList[(int)type];
        }

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
            for (int i = 0; i < (int)FoodTypes.eFoodTypesNum; ++i)
            {
                //foodTypeList[i].type = (FoodTypes)i;
                //MonoBehaviour.print(foodTypeList[i].type + " // " );
                foodTypeList[i] = new FoodData((FoodTypes)i, 1000);
            }
            foodTypeList[(int)FoodTypes.eFoodFire].score = 3000;
        }
    }
}

namespace AnimalSystem
{
    public enum AnimalTypes
    {
        eAnimalNone = -1,
        eAnimalMouse,
        eAnimalCow,
        eAnimalTiger,
        eAnimalDragon,
        eAnimalSnake,
        eAnimalHorse,
        eAnimalSheep,
        eAnimalMonkey,
        eAnimalChicken,
        eAnimalWolf,
        eAnimalTypesNum
    }

    public enum EatType
    {
        eEatNone = -1,
        eEatLike,
        eEatNormal,
        eEatHate,
        eEatTypeNum
    }

    public class Animal
    {
        public FoodSystem.FoodTypes[] canEatFood = new FoodSystem.FoodTypes[(int)EatType.eEatTypeNum];
        public AnimalTypes animalType = AnimalTypes.eAnimalNone;
        public AnimalTypes friendAnimal = AnimalTypes.eAnimalNone;

        public Animal(
            AnimalTypes myType,
            FoodSystem.FoodTypes like,
            FoodSystem.FoodTypes normal,
            FoodSystem.FoodTypes hate,
            AnimalTypes friend)
        {
            animalType = myType;

            canEatFood[(int)EatType.eEatLike]   = like;
            canEatFood[(int)EatType.eEatNormal] = normal;
            canEatFood[(int)EatType.eEatHate]   = hate;

            friendAnimal = friend;
        }

        public bool CanEat(FoodSystem.FoodTypes type)
        {
            foreach (FoodSystem.FoodTypes myType in canEatFood)
            {
                if (myType == type)
                {
                    //MonoBehaviour.print(myType + " vs " + type);
                    return true;
                }
            }
            //MonoBehaviour.print(type + "은 실패!");
            return false;
        }

    }

    public class AnimalManager
    {
        static AnimalManager pointer = null;
        Animal[] animalList = null;
        public Animal[] animalData
        {
            get { return animalList; }
        }

        public static AnimalManager getInstance()
        {
            if (null == pointer)
            {
                pointer = new AnimalManager();
                pointer.setting();
            }
            return pointer;
        }

        public void setting()
        {
            animalList = new Animal[(int)AnimalTypes.eAnimalTypesNum];
            // 쥐
            animalList[(int)AnimalTypes.eAnimalMouse] = new Animal(
                    AnimalTypes.eAnimalMouse,
                    FoodSystem.FoodTypes.eFoodCheese,
                    FoodSystem.FoodTypes.eFoodRice,
                    FoodSystem.FoodTypes.eFoodMouse,
                    AnimalTypes.eAnimalCow
                );
            // 소
            animalList[(int)AnimalTypes.eAnimalCow] = new Animal(
                AnimalTypes.eAnimalCow,
                FoodSystem.FoodTypes.eFoodGrass,
                FoodSystem.FoodTypes.eFoodHay,
                FoodSystem.FoodTypes.eFoodCow,
                AnimalTypes.eAnimalHorse
            );

            // 호랑이
            animalList[(int)AnimalTypes.eAnimalTiger] = new Animal(
                AnimalTypes.eAnimalTiger,
                FoodSystem.FoodTypes.eFoodCow,
                FoodSystem.FoodTypes.eFoodChicken,
                FoodSystem.FoodTypes.eFoodLeaf,
                AnimalTypes.eAnimalNone
                );

            // 용
            animalList[(int)AnimalTypes.eAnimalDragon] = new Animal(
                AnimalTypes.eAnimalDragon,
                FoodSystem.FoodTypes.eFoodFire,
                FoodSystem.FoodTypes.eFoodNone,
                FoodSystem.FoodTypes.eFoodNone,
                AnimalTypes.eAnimalNone
                );

            // 뱀
            animalList[(int)AnimalTypes.eAnimalSnake] = new Animal(
                AnimalTypes.eAnimalSnake,
                FoodSystem.FoodTypes.eFoodMouse,
                FoodSystem.FoodTypes.eFoodEgg,
                FoodSystem.FoodTypes.eFoodGrass,
                AnimalTypes.eAnimalDragon
                );

            // 말
            animalList[(int)AnimalTypes.eAnimalHorse] = new Animal(
                AnimalTypes.eAnimalHorse,
                FoodSystem.FoodTypes.eFoodCarrot,
                FoodSystem.FoodTypes.eFoodCorn,
                FoodSystem.FoodTypes.eFoodHorse,
                AnimalTypes.eAnimalNone
                );

            // 양
            animalList[(int)AnimalTypes.eAnimalSheep] = new Animal(
                AnimalTypes.eAnimalSheep,
                FoodSystem.FoodTypes.eFoodPaper,
                FoodSystem.FoodTypes.eFoodGrass,
                FoodSystem.FoodTypes.eFoodSheep,
                AnimalTypes.eAnimalNone
                );

            // 원숭이
            animalList[(int)AnimalTypes.eAnimalMonkey] = new Animal(
                AnimalTypes.eAnimalMonkey,
                FoodSystem.FoodTypes.eFoodBanana,
                FoodSystem.FoodTypes.eFoodCookedRice,
                FoodSystem.FoodTypes.eFoodGrass,
                AnimalTypes.eAnimalNone
                );

            // 닭
            animalList[(int)AnimalTypes.eAnimalChicken] = new Animal(
                AnimalTypes.eAnimalChicken,
                FoodSystem.FoodTypes.eFoodLarva,
                FoodSystem.FoodTypes.eFoodRice,
                FoodSystem.FoodTypes.eFoodEgg,
                AnimalTypes.eAnimalNone
                );

            // 늑대
            animalList[(int)AnimalTypes.eAnimalWolf] = new Animal(
                AnimalTypes.eAnimalWolf,
                FoodSystem.FoodTypes.eFoodSheep,
                FoodSystem.FoodTypes.eFoodMouse,
                FoodSystem.FoodTypes.eFoodFeed,
                AnimalTypes.eAnimalSheep
                );
        }
    }
}

public class GameSystem : MonoBehaviour {
    public MouseSystem mouse = null;
    public PlayGameResourcesMgr resourceMgr = null;
    public HandleAnimalManager handleMgr = null;

    public AnimalSlot[] animalSlotList = new AnimalSlot[4];

    public bool pigTime = false;

    FoodZone foodzone = null;
    int foodtypeNum = 0;

    // Use this for initialization
    LinkedList<FoodSystem.FoodTypes> foodlist = new LinkedList<FoodSystem.FoodTypes>();
    FoodSystem.FoodTypes[] foodZoneCanTypeArray = new FoodSystem.FoodTypes[12];

    void Awake()
    {
    }

    void Start () {
        handleMgr = FindObjectOfType(typeof(HandleAnimalManager)) as HandleAnimalManager;

        _InitAnimals();

        _InitFoodSystem();
        _InitFoodZone();
    }
	
	// Update is called once per frame
	void Update () {

    }
    void _InitAnimals()
    {
        int[] animalNumHash = new int[4];
        animalNumHash[0] = animalNumHash[1] = animalNumHash[2] = animalNumHash[3] = -1;
        int animalHashIndex = 0;

        int foodIndex = 0;
        foodtypeNum = 12;

        AnimalSystem.Animal[] animalist = AnimalSystem.AnimalManager.getInstance().animalData;
        foreach (AnimalSlot animal in animalSlotList)
        {
            int index = 0;
            while (true)
            {
                index = Random.Range(0, (int)AnimalSystem.AnimalTypes.eAnimalTypesNum - 1);

                if (index == animalNumHash[0]) continue;
                if (index == animalNumHash[1]) continue;
                if (index == animalNumHash[2]) continue;

                break;
            }
            animalNumHash[animalHashIndex++] = index;

            AnimalSystem.Animal ani = animalist[index];
            foreach (FoodSystem.FoodTypes types in ani.canEatFood)
            {
                if (FoodSystem.FoodTypes.eFoodNone != types)
                    foodZoneCanTypeArray[foodIndex++] = types;
            }

            if (null == ani) print("Null");
            animal.SetAnimal(ani, resourceMgr.animalSpriteArray[index]);
        }

        foodtypeNum = foodIndex + 1;
    }

    void _InitFoodSystem()
    {
        //foodtypeNum = (int)FoodSystem.FoodTypes.eFoodTypesNum - 1;
        for (int i = 0; i < 1000; ++i)
        {
            //FoodSystem.FoodTypes val = new FoodSystem.FoodTypes();
            //val = (FoodSystem.FoodTypes)Random.Range(0, foodtypeNum);
            FoodSystem.FoodTypes val = foodZoneCanTypeArray[Random.Range(0, foodtypeNum - 1)];
            foodlist.AddLast(val);
        }
    }
    void _InitFoodZone()
    {
        foodzone = GetComponentInChildren<FoodZone>();
        
        for (int x = 0; x < foodzone.zoneWidth; ++x)
        {
            for (int y = 0; y < foodzone.zoneHeight; ++y)
            {
                int index = (int)foodZoneCanTypeArray[Random.Range(0, foodtypeNum - 1)];
                foodzone.slotList[x, y].gameMgr = this;
                foodzone.slotList[x, y].settingData(resourceMgr.foodSpriteArray[index], 
                    FoodSystem.FoodManager.getInstance().HashFoodData(index));
            }
        }
    }

    public void changeFoodSlot(FoodSlot slot)
    {
        mouse.processClick = true;

        FoodSystem.FoodTypes val = slot.fooddata.type;
        foodlist.AddLast(val);

        int index = -1;
        while (true)
        {
            index = (int)foodlist.First.Value;
            foodlist.RemoveFirst();

            if (index != (int)val) break;

            foodlist.AddLast((FoodSystem.FoodTypes)index);
        }

        slot.settingData(resourceMgr.foodSpriteArray[index],
            FoodSystem.FoodManager.getInstance().HashFoodData(index));
    }

}
