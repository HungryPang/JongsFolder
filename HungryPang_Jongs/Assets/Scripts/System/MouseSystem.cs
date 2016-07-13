using UnityEngine;
using System.Collections;

public class MouseSystem : MonoBehaviour
{
    public Vector2 OffsetDrawPos;

    Camera mCamera;
    Vector2 mMouseWorldPos;
    public bool isClick = false;
    public bool processClick = true;

    public Vector2 mouseWorld
    {
        get { return mMouseWorldPos; }
    }


    Vector2 offOffset;
    // Use this for initialization
    void Start()
    {
        mCamera = GetComponentInParent<Camera>();
        Cursor.visible = false;
        offOffset = new Vector2(-1000, -1000);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetTouch(0).phase == TouchPhase.Began)
        //{
        //    mMouseWorldPos = mCamera.ScreenToWorldPoint(Input.GetTouch(0).position);
        //    transform.position = mMouseWorldPos + OffsetDrawPos;
        //}
        //else
        {
            mMouseWorldPos = mCamera.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mMouseWorldPos + OffsetDrawPos;
        }

        if (Input.GetMouseButtonDown(0))
            processClick = false;
        else if (Input.GetMouseButtonUp(0))
            processClick = true;

        //if (processClick) return;
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        if (false == processClick && Input.GetMouseButton(0))
        {
            isClick = true;
            //collider.offset = Vector2.zero;
        }
        else
        {
            isClick = false;
            //collider.offset = offOffset;
        }
        collider.enabled = isClick;
        print(processClick);
    }
}
