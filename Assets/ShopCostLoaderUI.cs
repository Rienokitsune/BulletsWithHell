using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopCostLoaderUI : MonoBehaviour
{
    [SerializeField] UpgradeShop shop;
    [SerializeField] UpgradeTypes.UpgradeType type;

    [SerializeField] Text cost;
    [SerializeField] Text level;
    [SerializeField] Button button;

    IEnumerator Start()
    {
        while (true)
        {
            updatePanel();
            yield return new WaitForSeconds(0.2f);
        }
       
    }

    public void updatePanel()
    {
        foreach(UpgradeShop.Upgrade upgrade in shop.upgrades)
        {
            if(upgrade.upgradeType == type)
            {
                button.interactable = true;

                if (upgrade.currentLevel == upgrade.maxLevel)
                {
                    button.interactable = false;
                    cost.text = "MAX";
                    level.text = upgrade.currentLevel.ToString();
                }else
                {
                    cost.text = upgrade.cost[upgrade.currentLevel].ToString();
                    level.text = upgrade.currentLevel.ToString();

                    if (upgrade.cost[upgrade.currentLevel] > shop.data.getSP())
                    {
                        button.interactable = false;
                    }else
                    {
                        button.interactable = true;
                    }
                }


                
            }
        }
    }

    public void Buy()
    {
        foreach (UpgradeShop.Upgrade upgrade in shop.upgrades)
        {
            if (upgrade.upgradeType == type)
            {
                shop.BuyUpgrade(type, upgrade.cost[upgrade.currentLevel]);
                updatePanel();
                return;
            }
        }
    }


    /*
     * if(upgrade.cost[upgrade.currentLevel] > shop.data.getSP())
                {
                    button.interactable = false;
                    cost.text = upgrade.cost[upgrade.currentLevel-1].ToString();
                    
                    level.text = upgrade.currentLevel.ToString();
                }
                else
                {
                    if(upgrade.cost.Length >= upgrade.currentLevel  )
                    {
                        button.interactable = true;
                        cost.text = upgrade.cost[upgrade.currentLevel].ToString();
                        level.text = upgrade.currentLevel.ToString();
                    }
                    else
                    {
                        button.interactable = false;
                        cost.text = "MAX";
                        level.text = (upgrade.currentLevel).ToString();
                    }
                    
                }*/
}
