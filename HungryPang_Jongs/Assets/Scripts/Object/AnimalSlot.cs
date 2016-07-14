using UnityEngine;
using System.Collections;
using AnimalSystem;

public class AnimalSlot : MonoBehaviour {
    public Animal myAnimal = null;
    HandleAnimalManager handleMgr = null;
    GameSystem gameMgr            = null;
    hpGage hpSystem               = null;

    public void DecreaseHungryValue (float value)
    {
        hpSystem.GageFluctuation(-1 * value);
    }
	// Use this for initialization
	void Start () {
        hpSystem = GetComponentInChildren<hpGage>();
        handleMgr = GetComponentInParent<HandleAnimalManager>();
        gameMgr = FindObjectOfType(typeof(GameSystem)) as GameSystem;
    }
	
	// Update is called once per frame
	void Update () {
        if (hpSystem.isGameOver)
        {
            gameMgr.GameOver();
        }
    }

    public void SetAnimal(Animal animal, Sprite sprite)
    {
        myAnimal = animal;
        GetComponent<SpriteRenderer>().sprite = sprite;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (false == gameMgr.mouse.isClick) return;
        if (collider.name == "Mouse")
            _ButtonDown();
    }

    void _ButtonDown()
    {
        handleMgr.Handle(this, gameMgr.resourceMgr);
    }
}
