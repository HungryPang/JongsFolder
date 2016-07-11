using UnityEngine;
using System.Collections;
//using FoodSystem;
public class FoodSlot : MonoBehaviour {
    FoodSystem.FoodData myFoodData;
    public FoodSystem.FoodData fooddata
    {
        get { return myFoodData; }
        set { myFoodData = value; }
    }


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void settingData(int data)
    {
        string test = "num_lst";
        Sprite[] sprite = Resources.LoadAll<Sprite>(test.ToString()) as Sprite[];
        if (null == sprite) print(test);
        GetComponent<SpriteRenderer>().sprite = sprite[data];
    }
}
