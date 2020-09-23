using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// здоровья коробля справа вверху
public class HealthUIscript : MonoBehaviour
{

    public Sprite spriteHealth1;
    public Sprite spriteHealth2;
    public Sprite spriteHealth3;
    public Sprite spriteHealth0;

    void Update()
    {
        // обновляем спрайт просто по количеству здоровья
        switch (PlayerScript.GetPlayerHealth())
        {
            case 3:
                gameObject.GetComponent<Image>().overrideSprite = spriteHealth3;
                break;
            case 2:
                gameObject.GetComponent<Image>().overrideSprite = spriteHealth2;
                break;
            case 1:
                gameObject.GetComponent<Image>().overrideSprite = spriteHealth1;
                break;
            case 0:
                gameObject.GetComponent<Image>().overrideSprite = spriteHealth0;
                break;
        }
        
    }
} 
