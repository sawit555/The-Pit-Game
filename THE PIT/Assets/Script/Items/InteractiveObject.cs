using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public float radius = 1f;
    public Transform player;
    public Transform interactItems;
    bool hasInteract = false;
    // Start is called before the first frame update
    void Start()
    {

    }


    void Update()
    {
        if (player != null)
        {
            float distance = Vector2.Distance(player.position, interactItems.position);
            if (distance <= radius && !hasInteract)
            {
                hasInteract = true;
                Interact();

            }
        }

    }

    public virtual void Interact()
    {
        Debug.Log("Item Active");
    }
}
