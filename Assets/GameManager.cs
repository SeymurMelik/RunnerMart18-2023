using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject Score;
    public GameObject Coin;
    bool on = true;

    public void ToggleSwitch()
    {
        on = !on;
        if (on)
        {
            Score.SetActive(true);
            Coin.SetActive(true);
        }
        else if (!on)
        {
            Coin.SetActive(false);
            Score.SetActive(false);
        }
    }
}
