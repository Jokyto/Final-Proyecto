using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1 : MonoBehaviour
{
  
    public void DestoyDoor() 
    
    {
        Debug.Log("Door1 Recibio Unityevent desde totem 3");
        gameObject.SetActive(false);

    }
}
