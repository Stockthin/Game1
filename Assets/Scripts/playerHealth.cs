using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour {
    public float fullHealth;
    float currentHealth;
    playerController controlMovement;
    public GameObject DeathFX;
    public Slider healthSlider;
    public Image damageScreen;
    bool damaged = false;
    Color damagedColor = new Color(0f, 0f, 0f, 0.5f);
    float smoothColour = 5f;
    public AudioClip playerHurt;
    AudioSource playerAS;
    
    // Use this for initialization
    void Start () {
        currentHealth = fullHealth;
        controlMovement = GetComponent<playerController>();
        healthSlider.maxValue = fullHealth;
        healthSlider.value = fullHealth;
        damaged = false;
        playerAS = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update () {
        if (damaged)
        {
            damageScreen.color = damagedColor;

        }
        else
        {
            damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, smoothColour * Time.deltaTime);
        }
        damaged = false;
	
	}
    public void addDame(float Damage)
    {
        if (Damage <= 0) return;
        currentHealth -= Damage;
        //playerAS.clip = playerHurt;
        //playerAS.Play();
        playerAS.PlayOneShot(playerHurt);
        healthSlider.value = currentHealth;
        damaged = true;
        if (currentHealth <= 0)
        {
           
            makeDeath();
        }
    }
    public void addHealth(float healthAmount)
    {
        currentHealth += healthAmount;
        if (currentHealth > fullHealth) currentHealth = fullHealth;
        healthSlider.value = currentHealth;
    }
    public void makeDeath()
    {
        Instantiate(DeathFX, transform.position, transform.rotation);
        Destroy(gameObject);
        
    }
}
