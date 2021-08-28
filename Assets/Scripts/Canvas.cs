using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject rules;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        rules.SetActive(false);
    }

    public void LoadRules()
    {
        mainMenu.SetActive(false);
        rules.SetActive(true);
    }

    public void BackButton()
    {
        rules.SetActive(false);
        mainMenu.SetActive(true);
    }
}
