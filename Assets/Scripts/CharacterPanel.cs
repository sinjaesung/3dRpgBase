using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI health, level;
    [SerializeField] private Image healthFill, levelFill;
    [SerializeField] private Player player;

    //Stats
    private List<TextMeshProUGUI> playerStatTexts = new List<TextMeshProUGUI>();
    [SerializeField] private TextMeshProUGUI playerStatPrefab;
    [SerializeField] private Transform playerStatPanel;

    //Equipped Weapon
    [SerializeField] private Sprite defaultWeaponSprite;
    private PlayerWeaponController playerWeaponController;
    [SerializeField]
    private TextMeshProUGUI weaponStatPrefab;
    [SerializeField]
    private Transform weaponStatPanel;
    [SerializeField]
    private TextMeshProUGUI weaponNameText;
    [SerializeField]
    private Image weaponIcon;
    [SerializeField]
    private List<TextMeshProUGUI> weaponStatTexts = new List<TextMeshProUGUI>();

    private void Start()
    {
        playerWeaponController = player.GetComponent<PlayerWeaponController>();
        UIEventHandler.OnPlayerHealthChanged += UpdateHealth;
        UIEventHandler.OnStatsChanged += UpdateStats;
        UIEventHandler.OnItemEquipped += UpdateEquippedWeapon;
        UIEventHandler.OnPlayerLevelChange += UpdateLevel;
        InitializeStats();
    }

    void UpdateHealth(int currentHealth, int maxHealth)
    {
        Debug.Log("character update health!!!:" + currentHealth + "/" + maxHealth);

        this.health.text = currentHealth.ToString();
        this.healthFill.fillAmount = (float)currentHealth / (float)maxHealth;
    }
    void UpdateLevel()
    {
        Debug.Log("character update Level!!!");

        this.level.text = player.PlayerLevel.Level.ToString();
        this.levelFill.fillAmount = (float)player.PlayerLevel.CurrentExperience / (float)player.PlayerLevel.RequiredExperience;
    }

    void InitializeStats()
    {
        Debug.Log("character stat inits!");
        for(int i=0; i< player.characterStats.stats.Count; i++)
        {
            playerStatTexts.Add(Instantiate(playerStatPrefab));
            playerStatTexts[i].transform.SetParent(playerStatPanel);
        }
        UpdateStats();
    }

    void UpdateStats()
    {
        Debug.Log("character update stats!");
        for (int i = 0; i < player.characterStats.stats.Count; i++)
        {
            playerStatTexts[i].text = player.characterStats.stats[i].StatName + ": " + player.characterStats.stats[i].GetCalculatedStatValue().ToString();
        }
    }

    void UpdateEquippedWeapon(Item item)
    {
        weaponIcon.sprite = Resources.Load<Sprite>("UI/Icons/Items/" + item.ObjectSlug);
        weaponNameText.text = item.ItemName;

        for (int i = 0; i < item.Stats.Count; i++)
        {
            weaponStatTexts.Add(Instantiate(weaponStatPrefab));
            weaponStatTexts[i].transform.SetParent(weaponStatPanel);
            weaponStatTexts[i].text = item.Stats[i].StatName + ": " + item.Stats[i].GetCalculatedStatValue().ToString();
        }
    }

    public void UnequipWeapon()
    {
        if (playerWeaponController.EquippedWeapon != null)
        {
            weaponNameText.text = "-";
            weaponIcon.sprite = defaultWeaponSprite;
            for (int i = 0; i < weaponStatTexts.Count; i++)
            {
                weaponStatTexts[i].text = "";
            }
            playerWeaponController.UnequipWeapon();
        }
        else
        {
            Debug.Log("착용중 장비가 있을때만 장비해제가능");
        }
        playerWeaponController.equippedWeapon = null;
    }
}
