using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    RectTransform rect;
    Upgrade[] upgrades;

    void Awake()
    {
        rect = GetComponent<RectTransform>();
        upgrades = GetComponentsInChildren<Upgrade>(true);
    }

    public void Show()
    {
        Next();
        rect.localScale = Vector3.one;
        Time.timeScale = 0.0f;
    }
    public void Hide()
    {
        rect.localScale = Vector3.zero;
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }

    void Next()
    {
        foreach (Upgrade upgrade in upgrades)
        {
            upgrade.gameObject.SetActive(false);
        }
        int[] ran = new int[3];

        while (true)
        {
            while (true)
            {
                ran[0] = Random.Range(0, upgrades.Length);
                ran[1] = Random.Range(0, upgrades.Length);
                ran[2] = Random.Range(0, upgrades.Length);
                if ((ran[0] != ran[1] && ran[1] != ran[2] && ran[0] != ran[2]))
                    break;
            }
            Upgrade rRp0 = upgrades[ran[0]];
            Upgrade rRp1 = upgrades[ran[1]];
            Upgrade rRp2 = upgrades[ran[2]];
            if (!rRp0.Upgraded && !rRp1.Upgraded && !rRp2.Upgraded)
                break;
        }

        for (int i = 0; i < ran.Length; i++)
        {
            Upgrade ranUpgrade = upgrades[ran[i]];
            ranUpgrade.gameObject.SetActive(true);
        }
    }
}
