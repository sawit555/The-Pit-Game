using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausemenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject inventory;
    public bool isPause;

    public static Pausemenu instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        pauseMenu.SetActive(false);
        inventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {
                ResumeGame();
            }
            else if(!isPause)
            {
                PauseGame();
            }
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isPause)
            {
                InventoryHide();
            }
            else if (!isPause)
            {
                InventoryShow();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPause = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPause = false;
    }

    public void InventoryShow()
    {
        inventory.SetActive(true);
        isPause = true;
    }

    public void InventoryHide()
    {
        inventory.SetActive(false);
        isPause = false;
    }


    public GameObject Panel;
    public void panelClose()
    {
        Panel.SetActive(false);
    }
}
