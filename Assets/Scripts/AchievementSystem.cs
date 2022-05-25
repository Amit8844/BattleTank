using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementSystem : SingletonGeneric<AchievementSystem>
{
    [SerializeField] private AchievementHolder achievementSOList;
    [SerializeField] private CanvasRenderer AchievementPanel;
    [SerializeField] private Text AchievementName;
    [SerializeField] private Text AchievementInfo;
    private int currentBulletFiredAchivementLevel;
    private int currentEnemiesKilledAchievementLevel;

    private int count = 0 ;
    public int Killed = 0;
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;



    void Start()
    {
        currentBulletFiredAchivementLevel = 0;
        currentEnemiesKilledAchievementLevel = 0;
        EventHandler.Instance.OnEnemyDeath += EnemyDeathCountCheck;

        text1 = FindObjectOfType<TextMeshProUGUI>();
    }

    public void BulletsFiredCountCheck(int bulletCount)
    {
        count = bulletCount;
        text1.text = "Fired :- " + count;
        for (int i = 0; i < achievementSOList.bulletsFiredAchievementSO.achievements.Length; i++)
        {
            if (i != currentBulletFiredAchivementLevel) continue;

            if(achievementSOList.bulletsFiredAchievementSO.achievements[i].requirement == bulletCount)
            {
                UnlockAchievement(achievementSOList.bulletsFiredAchievementSO.achievements[i].name, achievementSOList.bulletsFiredAchievementSO.achievements[i].info);
                currentBulletFiredAchivementLevel = i + 1;
            }
            break;
        }
    }

    public void EnemyDeathCountCheck()
    {
        Killed = TankService.Instance.tankController.TankModel.EnemiesKilled;
        text1.text = "Killed:- " + Killed; 
        for (int i = 0; i < achievementSOList.enemiesKilledAchievementSO.achievements.Length; i++)
        {
            if (i != currentEnemiesKilledAchievementLevel) continue;

            if(achievementSOList.enemiesKilledAchievementSO.achievements[i].requirement == TankService.Instance.tankController.TankModel.EnemiesKilled)
            {
                UnlockAchievement(achievementSOList.enemiesKilledAchievementSO.achievements[i].name, achievementSOList.enemiesKilledAchievementSO.achievements[i].info);
                currentEnemiesKilledAchievementLevel = i + 1;
            }
            break;
        }
    }

    private async void UnlockAchievement(string AchievementName, string AchievementInfo)
    {
        this.AchievementName.text = AchievementName;
        this.AchievementInfo.text = AchievementInfo;
        AchievementPanel.gameObject.SetActive(true);
        await new WaitForSeconds(5);
        AchievementPanel.gameObject.SetActive(false);
    }


    private void OnDisable()
    {
        EventHandler.Instance.OnEnemyDeath -= EnemyDeathCountCheck;
    }

}
