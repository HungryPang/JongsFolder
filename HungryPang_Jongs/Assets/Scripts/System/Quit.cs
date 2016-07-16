using UnityEngine;
using System.Collections;

public class Quit : MenuInterface {
    void Awake()
    {
        InterfaceStart();
    }
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
    }

    public override void Collide()
    {
        Application.Quit();
    }
}
