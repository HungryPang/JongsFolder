using UnityEngine;
using System.Collections;
using AnimalSystem;

public class AnimalSlot : MonoBehaviour {
    public Animal myAnimal = null;
    HandleAnimalManager handleMgr = null;
    GameSystem gameMgr = null;
	// Use this for initialization
	void Start () {
        handleMgr = GetComponentInParent<HandleAnimalManager>();
        gameMgr = FindObjectOfType(typeof(GameSystem)) as GameSystem;
    }
	
	// Update is called once per frame
	void Update () {
	
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
        handleMgr.Handle(myAnimal, gameMgr.resourceMgr);
    }
}
