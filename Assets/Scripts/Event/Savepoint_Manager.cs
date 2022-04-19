using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Savepoint_Manager : MonoBehaviour
{
    [SerializeField] List<Transform> Savepoint = new List<Transform>();

    private void Start() 
    {
        foreach (Transform savepoint in transform)
        {
            Debug.Log(savepoint.name);
            Savepoint.Add(savepoint);
        }
    }

    public void Find_savepoint(string name)
    {
        int index_point = Savepoint.FindIndex(item => item.name == name);
        GameManager.instance.last_sp = index_point;
    }
    public Transform get_savepoint(int index)
    {
        return Savepoint[index];
    }
 
}
