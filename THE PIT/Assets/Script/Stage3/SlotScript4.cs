using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotScript4 : MonoBehaviour, IDropHandler
{
    [SerializeField] public int id;
    [SerializeField] public int id2;
    public static bool check;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.GetComponent<DragAndDrop>().id == id || eventData.pointerDrag.GetComponent<DragAndDrop>().id2 == id2)
            {
                Debug.Log("Pass");
                check = true;
            }
            else
            {
                Debug.Log("Out");
                check = false;
            }
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = this.GetComponent<RectTransform>().anchoredPosition;
        }
    }
}
