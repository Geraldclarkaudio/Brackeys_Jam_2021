using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _goldText, _livesText;

    public void UpdateGoldDisplay(int gold)
    {
        _goldText.text = "Gold: " + gold.ToString();
    }

    public void UpateLivesDisplay(int lives)
    {
        _livesText.text = "Health: " + lives.ToString();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
