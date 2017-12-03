using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {

    private Transform myTrans;
    private Transform GunTrans;
    Camera cam;

	void Start ()
    {
        GunTrans = GetComponentInChildren<Transform>();
        myTrans = GetComponent<Transform>();
        cam = Camera.main;
	}
	void Update ()
    {
        //float angle = Vector2.Angle(myTrans.position, cam.ScreenToWorldPoint(Input.mousePosition));
        Vector2 mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(mousepos.y - myTrans.position.y, mousepos.x - myTrans.position.x);
        angle = Mathf.Rad2Deg * angle;
        myTrans.eulerAngles = new Vector3(0, 0, angle);

        if(angle < -90 || angle > 90)
        {
            GunTrans.localScale = new Vector2(1, -1);
        }
        else
        {
            GunTrans.localScale = new Vector2(1, 1);
        }
        Debug.Log(angle);
    }
}
