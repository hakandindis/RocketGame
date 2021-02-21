using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Buttons : MonoBehaviour
{
    public GameObject canvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Stop();
        }
    }

    public void Stop()
    {
        Time.timeScale = 0f;
        canvas.SetActive(true);
    }
    public void Restart()
    {

        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    
}
