using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerStorage;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        int layerId = LayerMask.NameToLayer("Player");
        if (collision.gameObject.layer == layerId && !collision.isTrigger)
        {
            playerStorage.initialValue = playerPosition;
            SceneManager.LoadScene(sceneToLoad);
        }
    }
    // Update is called once per frame

}
