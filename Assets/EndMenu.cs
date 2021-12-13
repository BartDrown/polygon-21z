using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenu : MonoBehaviour
{
    [SerializeField] GameObject endMenuUI;
    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<GameManager>().gameHasEnded) endMenuUI.SetActive(true);
    }
}
