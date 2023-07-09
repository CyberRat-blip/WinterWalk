using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeScript : MonoBehaviour
{
    private int HelthPoint = 100;
    public Animator animator;
    public Slider healthBar;
    public static bool switchVisible = false;
    float timer;
    bool switchTimer = false;
    bool switcherSpawn = false;
    [SerializeField] public Behaviour SpawnScript;
    //public GameObject[] spawnItem;
    //public List<Transform> spawnPoints;


    private void Start()
    {
        SpawnScript.enabled = false;
    }
    void Update()
    {
        healthBar.value = HelthPoint;
        if(switchTimer == true)
        {
            TimeToDespawn();
        }
        
    }

    public void TakeDamage(int meleDamageAmount)
    {
        HelthPoint -= meleDamageAmount;
        if (HelthPoint <= 0)
        {
            animator.SetTrigger("Falling");
           // GetComponent<Collider>().enabled = false;
            healthBar.gameObject.SetActive(false);
           // RandomSpawn.treeFall = true;
            switchTimer = true;
            switcherSpawn = true;
            SpawnScript.enabled = true;
        }
        
    }
    public void TimeToDespawn()
    {
        timer += Time.deltaTime;
        if(timer >= 5)
        {
            VisibleScript.fallTree(switchVisible);
        }
    }
    //void SpawnBalls()
    //{
    //    for (int i = 0; i < spawnItem.Length; i++)
    //    {
    //        var spawn = Random.Range(0, spawnPoints.Count);
    //        Instantiate(spawnItem[i], spawnPoints[spawn].transform.position, Quaternion.identity);
    //        spawnPoints.RemoveAt(spawn);
    //    }
    //}
}
