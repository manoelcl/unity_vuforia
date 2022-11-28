using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    Animator animator;
    public bool hitted;
    public bool dead;
    public bool attack;
    public float nextAttack;
    public bool walking;
    public int damage=2;
    public GameObject target;
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    // Update is called once per frame
    void Update()
    {
        if ((hitted || attack || !player) != true)
        {
            animator.SetBool("Walk", true);
            Vector3 direction = Vector3.Normalize(transform.position + player.transform.position);
            transform.LookAt(player.transform, transform.root.transform.up);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.001f);
        }
        else if (attack == true && Time.time > nextAttack)
        {

            animator.SetTrigger("Attack");
            if (target)
            {
                attackPlayer(target);
                nextAttack = Time.time + 3.0f;
            }
            
            

        }
        else if (hitted == true)
        {
            animator.SetBool("Walk", false);
        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }

    private void attackPlayer(GameObject player)
    {
       
         Debug.Log(player+" debugueando");
         player.GetComponent<Health>().ApplyDamage(damage);
        
    }

    public void Die()
    {
        animator.SetBool("Dead", true);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.gameObject.tag == "Player")
        {
            attack = true;
            target = other.gameObject;

        }
        else
        {
            target = null;
        }

    }
}
