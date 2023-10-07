using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showAndHidePanel(GameObject uiPanel)
    {
        if (uiPanel.activeSelf)
        {
            uiPanel.gameObject.SetActive(false);
        }
        else
        {
            uiPanel.gameObject.SetActive(true);
        }
    }
}
