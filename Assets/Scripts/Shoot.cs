using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public ParticleSystem fireparticles;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        ShootFire();
    }
    public void ShootFire()
    {
        //fireparticles.
        RaycastHit hit;
        if (Physics.Raycast(fireparticles.transform.position, fireparticles.transform.forward, out hit, 2f))
        {
            if (hit.collider.tag == "Enemy")
            {
                hit.collider.gameObject.GetComponent<Health>().ApplyDamage(1);
                Debug.Log("acierto");
                Debug.DrawRay(fireparticles.transform.position, fireparticles.transform.forward * 22f, Color.red);
            }
        }
        else
        {
            Debug.Log("disparo");
            Debug.DrawRay(fireparticles.transform.position, fireparticles.transform.forward * 22f, Color.white);
        }

    }
}
