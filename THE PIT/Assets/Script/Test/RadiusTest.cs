using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiusTest : MonoBehaviour
{
    public float radius = 3f;
    public Transform InteractItem;

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(InteractItem.position, radius);
    }
}
