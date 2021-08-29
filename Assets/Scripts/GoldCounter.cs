using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCounter : MonoBehaviour
{
    private Player player;
    private UIManager uIManager;
    public int gold;

   
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        uIManager = GetComponent<UIManager>();
    }

    public void Count()
    {
        gold = gold + 5;
       
        uIManager.UpdateGoldDisplay(gold);
    }

}
