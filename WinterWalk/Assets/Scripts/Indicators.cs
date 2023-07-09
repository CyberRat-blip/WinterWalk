using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Indicators : MonoBehaviour
{
    public Image healthBar, foodBar, waterBar, frozenBar;
    public static float healthAmount = 100;
    private float uiHealthAmount = 100;
    public float foodAmount = 100;
    private float uiFoodAmount = 100;
    public float waterAmount = 100;
    private float uiWaterAmount = 100;
    private float frozenAmount = 100;
    public static bool isGameOver;
    public GameObject bloodOverlay;



    public float secondsToEmptyFood = 60f;
    public float secondsToEmptyWater = 30f;
    public float secondToEmptyHelth = 60f;

    public float secondsToFrozen1 = 60f;
    public float secondsToFrozen2 = 10f;
    public float secondsToHelth = 60f;
    public float temp = 60f;

    private float changeFactor = 6f;
    public int isInFrozen = 0;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.fillAmount = healthAmount / 100;
        foodBar.fillAmount = foodAmount / 100;
        waterBar.fillAmount = waterAmount / 100;
        frozenBar.fillAmount = frozenAmount / 100;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            SceneManager.LoadScene("SampleScene");
        }
        if (isInFrozen == 6)
        {
            healthAmount -= 100 / secondsToFrozen1 * Time.deltaTime;
            frozenBar.fillAmount = temp / 100;
        }
        if (isInFrozen == 7)
        {
            healthAmount -= 100 / secondsToFrozen2 * Time.deltaTime;
        }
        if (isInFrozen == 8)
        {
            if (healthAmount <= 100)
            {
                healthAmount += 100 / secondsToHelth * Time.deltaTime;
            }
        }
        if (foodAmount > 0)
        {
            foodAmount -= 100 / secondsToEmptyFood * Time.deltaTime;
            //Интерполяция (Изменение ChangeFactor приведет к ускорению заполнения полоски. Вычисляется по формуле (a + (b-a) * t, где 0 <= t <= 1.))
            uiFoodAmount = Mathf.Lerp(uiFoodAmount, foodAmount, Time.deltaTime * changeFactor);
            foodBar.fillAmount = uiFoodAmount / 100;
        }
        else
        {
            uiFoodAmount = 0;
            foodBar.fillAmount = uiFoodAmount / 100;
        }
        if (waterAmount > 0)
        {
            waterAmount -= 100 / secondsToEmptyWater * Time.deltaTime;
            uiWaterAmount = Mathf.Lerp(uiWaterAmount, waterAmount, Time.deltaTime * changeFactor);
            waterBar.fillAmount = uiWaterAmount / 100;
        }
        else
        {
            uiWaterAmount = 0;
            waterBar.fillAmount = uiWaterAmount / 100;
        }

        if (foodAmount <= 0)
        {
            healthAmount -= 100 / secondsToEmptyFood * Time.deltaTime;
        }
        if (waterAmount <= 0)
        {
            healthAmount -= 100 / secondsToEmptyWater * Time.deltaTime;
        }
        //if (healthAmount <= 0)
        //    isGameOver = true;
        uiHealthAmount = Mathf.Lerp(uiHealthAmount, healthAmount, Time.deltaTime * changeFactor);
        healthBar.fillAmount = uiHealthAmount / 100;


    }
    public IEnumerator Damage(float damageAmount)
    {
        bloodOverlay.SetActive(true);
        healthAmount -= damageAmount;
        yield return new WaitForSeconds(1f);
        bloodOverlay.SetActive(false);
    }

    public void ChangeFoodAmount(float changeValue)
    {
        if (foodAmount + changeValue >= 100)
        {
            foodAmount = 100;
        }
        else
        {
            foodAmount += changeValue;
        }
    }
    public void ChangeWaterAmount(float changeValue)
    {
        if (waterAmount + changeValue >= 100)
        {
            waterAmount = 100;
        }
        else
        {
            waterAmount += changeValue;
        }
    }
    public void ChangeHealthAmount(float changeValue)
    {
        if (healthAmount + changeValue >= 100)
        {
            healthAmount = 100;
        }
        else
        {
            healthAmount += changeValue;
        }
    }
    public static void TakeDamage(int damageCount)
    {
        healthAmount -= damageCount;
    }

}
//Coroutine
//
