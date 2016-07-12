using UnityEngine;
using System.Collections;

public class FoodZone : MonoBehaviour {
    public FoodSlot slot;
    public int zoneWidth = 8;
    public int zoneHeight = 8;

    public FoodSlot[,] slotList = null;

    // Use this for initialization
    void Awake()
    {
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        Vector2 pos = transform.position;
        Vector2 size = Vector2.Scale(collider.size * 0.5f, transform.localScale);
        Vector2 offset = pos - size + new Vector2(0.5f, 0.5f);
        Vector2 pitch = new Vector2(size.x / zoneWidth, size.y / zoneHeight) * 2;

        Vector2 temp = new Vector2();
        slotList = new FoodSlot[zoneWidth, zoneHeight];

        for (int x = 0; x < zoneWidth; ++x)
        {
            for (int y = 0; y < zoneHeight; ++y)
            {
                FoodSlot newSlot = Instantiate(slot);
                temp.x = pitch.x * x;
                temp.y = pitch.y * y;
                newSlot.transform.parent = transform;
                newSlot.transform.position = offset + temp;
                slotList[x, y] = newSlot;
            }
        }

    }
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
