using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundaries : MonoBehaviour {

    public GameObject Camera;
    public string MethodName;
    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.name == "Player")
        {
            Camera.SendMessage(MethodName,true);
            //print(MethodName);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            Camera.SendMessage(MethodName,false);
            //print(MethodName);
        }
    }
}
