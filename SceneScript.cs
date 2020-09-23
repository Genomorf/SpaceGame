using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    // меню пуск
    public void PlayGame()
    {
        SceneManager.LoadScene("1");
    }
}