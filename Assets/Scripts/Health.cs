using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    public int MaxHealth = 100;
    public int CurrentHealth;
    public Slider slider;
    public GameObject gameOverPanel;
    
    void Start()
    {
        CurrentHealth = MaxHealth;
        if (slider != null)
        {
            slider.maxValue = MaxHealth;
            slider.value = CurrentHealth;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyDamage(int damage)
    {
        CurrentHealth = CurrentHealth - damage;
        if (slider != null)
        {
            slider.value = CurrentHealth;
            Debug.Log("OK DEBERIA EJECUTAR " + CurrentHealth +" "+ damage);
        }

        if (CurrentHealth < 1)
        {
            if (gameObject.tag == "Enemy")
            {
                gameObject.GetComponent<EnemyMove>().Die();
                StartCoroutine("DestroyObject");
            }
            else
            {
                Destroy(this.gameObject);
                gameOverPanel.SetActive(true);
            }
        }
    }
    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(4.0f);
        Destroy(this.gameObject);
    }
}
