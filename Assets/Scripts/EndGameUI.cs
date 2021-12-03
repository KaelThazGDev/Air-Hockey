using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameUI : MonoBehaviour
{
    [SerializeField] private Button RestartButton;
    [SerializeField] private Button ExitButton;

    void Start()
    {
        RestartButton.onClick.AddListener(GameManager.instance.NewGame);
        ExitButton.onClick.AddListener(GameManager.instance.ExitGame);
    }

    void Update()
    {
    }

}    