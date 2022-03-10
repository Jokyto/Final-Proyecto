using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Dictionary<string, int> player_inventory = new Dictionary<string, int>();
    public Dictionary<int, string> re_arrange = new Dictionary<int, string>();
    public Dictionary<int, GameObject> grabable_dictionary = new Dictionary<int, GameObject>();
    int space_one = 0;
    int space_two = 1;
    int space_three = 2;
    int inventory_position = 0;
    int max_inventory_position = 3;
    int new_position = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { leave_item(0); };
        if (Input.GetKeyDown(KeyCode.Alpha2)) { leave_item(1); };
        if (Input.GetKeyDown(KeyCode.Alpha3)) { leave_item(2); };
    }
    
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Grabable_item"))
        {
            if(inventory_position != max_inventory_position)
            {
                Debug.Log(name + "Trigger con" + other.gameObject.name);
                GameObject grabable_item = other.gameObject;
                grabable_item.SetActive(false);
                if (player_inventory.ContainsKey(other.gameObject.name))
                {
                    player_inventory[other.gameObject.name] += 1;
                }
                else
                {
                    re_arrange.Add(inventory_position,other.gameObject.name);
                    grabable_dictionary.Add(inventory_position,grabable_item);
                    player_inventory.Add(other.gameObject.name, 1);
                    inventory_position += 1;
                }
                show_dictionary_updated();
            }
            else
            {
                Debug.Log("Can't carry more items!! Please leave one behind");
            }
        }
    }

    private void leave_item(int position)
    {
        grabable_dictionary[position].SetActive(true);
        if (inventory_position == 0)
        {
            re_arrange.Remove(inventory_position);
            grabable_dictionary.Remove(inventory_position);  
            player_inventory.Clear();
        }
        else
        {
            grabable_dictionary.Remove(position);
            grabable_dictionary.Add(position,null);
            player_inventory.Remove(re_arrange[position]);
            re_arrange.Remove(position);
            re_arrange.Add(position,"Changed");
            inventory_position -= 1;
            if(position != (max_inventory_position - 1))
            {
                for (var i = 0; i < (inventory_position + 1); i++)
                {
                    if (re_arrange[i] != "Changed")
                    {
                        re_arrange[new_position] = re_arrange[i];
                        grabable_dictionary[new_position] = grabable_dictionary[i];
                        new_position +=1;
                    }
                }
                re_arrange.Remove(inventory_position);
                grabable_dictionary.Remove(inventory_position);          
                new_position = 0;
            }
            else
            {
                grabable_dictionary.Remove(position);
                re_arrange.Remove(position);
            }
         
        }
        show_dictionary_updated();  
    }
    private void show_dictionary_updated() 
    {
        //IDictionaryEnumerator myEnumerator = player_inventory.GetEnumerator();

        //while (myEnumerator.MoveNext())
        //{
        //    Debug.Log(myEnumerator.Key + " --> " + myEnumerator.Value);
        //}
        foreach (var item in player_inventory)
        {
            Debug.Log("Player_inventory" + item);
        }

        foreach (var item in re_arrange)
        {
            Debug.Log("Re_arrage" + item);
        }
        foreach (var item in grabable_dictionary)
        {
            Debug.Log("grabable_dictionary" + item);
        }        
    }
    
}

