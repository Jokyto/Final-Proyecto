using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2 : MonoBehaviour
{

    public void DestoyDoor() 
    
    {
        Debug.Log("Door2 Recibio Unityevent desde totem 3");
        gameObject.SetActive(false);

    }
}
