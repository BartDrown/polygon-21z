using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class KillCounter : MonoBehaviour
{
    private TMP_Text textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        this.textMeshPro =  this.gameObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateKillCounter(int value){
        Debug.Log(value);
        this.textMeshPro.text = value.ToString();
    }
}
