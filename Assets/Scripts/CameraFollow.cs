using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform Player;
    [SerializeField]
    private float LerpAmount, MaxSpeed, XOffset, YOffset;

    private Transform myTrans;
    private Rigidbody2D RB;
    private Vector2 velocity;
    private bool XTrigger = false, YTrigger = false;
    float XTimer = 0, YTimer = 0;

    void Start()
    {
        myTrans = GetComponent<Transform>();
        RB = GetComponent<Rigidbody2D>();
    }

	void FixedUpdate()
    {
        float posY = myTrans.position.y;
        float posX = myTrans.position.x;
        if (XTrigger)
        {
            posX = Mathf.SmoothDamp(myTrans.position.x, Player.position.x + XOffset, ref velocity.x, LerpAmount* XTimer, MaxSpeed, Time.deltaTime);
        }
        if (YTrigger)
        {
            posY = Mathf.SmoothDamp(myTrans.position.y, Player.position.y + YOffset, ref velocity.y, LerpAmount* YTimer, MaxSpeed, Time.deltaTime);
        }
        myTrans.position = new Vector3(posX, posY, myTrans.position.z);
    }

    public void ToggleX(bool state)
    {
        XTrigger = state;
        //print("x");
    }

    public void ToggleY(bool state)
    {
        YTrigger = state;
        //print("y");
    }

    private void Update()
    {
        if (XTrigger)
        {
            Mathf.Clamp01(XTimer += Time.deltaTime/2);
        }
        else
        {
            XTimer = 0f;
        }
        if (YTrigger)
        {
            Mathf.Clamp01(YTimer += Time.deltaTime/2);
        }
        else
        {
            YTimer = 0f;
        }

    }
}
