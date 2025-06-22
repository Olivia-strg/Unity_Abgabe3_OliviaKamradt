using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour

{

    [SerializeField] public int collectableCount = 7;
    [SerializeField] public int maxSunflower = 7;
    [SerializeField] public UInterface uiManager;

    [SerializeField] public float timer = 0f;        // zählt die Zeit hoch in Sekunden
    [SerializeField] public TMP_Text timerText;      // zeigt es im TextMeshPro-Feld an



    public void AddOne()
    {
        collectableCount++;
        uiManager.ChangeNumberText(collectableCount);
        Debug.Log("Gesammelt" + collectableCount + " / " + maxSunflower);


        if (collectableCount >= maxSunflower)
        {
            uiManager.WinPanelOn();
            uiManager.GameLevelPanelOff();
            Debug.Log("Voller Energie");

        }
    }


    void Update()
    {
        // Zeit erhöht sich
        timer += Time.deltaTime;

        // Anzeige aktualisiert
        if (timerText != null)
        {
            timerText.text = timer.ToString("F2") + " s";
        }
    }




}
