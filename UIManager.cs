using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private PlayerStats thePS;
    public HealthManager theHealthMan;

    public Slider healthBar;
    public Text levelText;

    public int currentGold;
    public Text goldText;

    private static bool UIExists;

    // Start is called before the first frame update
    void Start()
    {
        if(!UIExists)
        {
            UIExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        thePS = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = theHealthMan.maxHealth;
        healthBar.value = theHealthMan.currentHealth;
        levelText.text = "Lvl: " + thePS.currentLevel;
    }

    public void AddGold(int goldToAdd)
    {
        currentGold += goldToAdd;
        goldText.text = "Gold : " + currentGold;
    }
}
