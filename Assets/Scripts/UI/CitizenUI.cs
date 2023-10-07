using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CitizenUI : MonoBehaviour
{
    public TextMeshProUGUI CitizenText;

    [SerializeField] private GameObject GameManager;

    [SerializeField] private float citizenNum;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        citizenNum = GameManager.GetComponent<GameManager>().getCitizen();

        CitizenText.text = $"{citizenNum}  People";
    }
}
