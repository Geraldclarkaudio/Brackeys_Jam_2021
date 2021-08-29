using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private Player player;

    [SerializeField]
    private Text _goldText, _livesText;

    [SerializeField]
    private Image[] healthbars;

    private void Start()
    {

        player = GameObject.Find("Player").GetComponent<Player>();
        
        if(gameObject!= null)
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void UpdateGoldDisplay(int gold)
    {
        _goldText.text = gold.ToString();
       
    }

    public void UpateLivesDisplay(int lives)
    {
       // _livesText.text = lives.ToString();

        for (int i = 0; i <= lives; i++)
        {
            if(i == lives)
            {
                healthbars[i].enabled = false;
            }
        }
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
