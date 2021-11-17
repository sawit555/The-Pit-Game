using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int space = 8;
    public List<Items> items = new List<Items>();

    public static Inventory instance;
    void Start()
    {
        
    }
    private void Awake()
    {
        instance = this;
    }
    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallback;
    public void Add(Items item)
    {
        if (item.showInventory)
        {
            if(items.Count >= space)
            {
                return;
            }
            items.Add(item);
            if (OnItemChangedCallback != null)
            {
                OnItemChangedCallback.Invoke();
            }
        }
    }
    public void Remove(Items item)
    {
        items.Remove(item);
    }
    void Update()
    {
        
    }
}
