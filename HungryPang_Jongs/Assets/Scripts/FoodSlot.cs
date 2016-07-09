using UnityEngine;
using System.Collections;
//using FoodSystem;
public class FoodSlot : MonoBehaviour {
    int a;
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
}
