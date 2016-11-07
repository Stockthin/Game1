using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour {
    public float enemyMaxHealth;
    float currentHealth;
    public GameObject enemyDeathFx;
    public Slider enemySlider;


	// Use this for initialization
	void Start () {
        currentHealth = enemyMaxHealth;
        enemySlider.maxValue = currentHealth;
        enemySlider.value = currentHealth;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void addDame(float Damage)
    {
        enemySlider.gameObject.SetActive(true);
        currentHealth -= Damage;
        enemySlider.value = currentHealth;
        if (currentHealth <= 0) makeDead();
        
    }
    void makeDead()
    {
        Destroy(gameObject);
        Instantiate(enemyDeathFx, transform.position, transform.rotation);
    }
}
