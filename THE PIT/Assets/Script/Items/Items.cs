using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Items : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool showInventory = true;
   
    public void Use()
    {
        if(name == "Book")
        {
            PlayerMovement.instance.ShowNote();
        }
    }
}
