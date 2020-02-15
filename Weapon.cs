using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int weapondamage;
    private int totaldamage;
    EnemyController enemyC;
    PlayerStats pstats;
    PlayerController PlayerC;
    EventActivator eventact;
    CapsuleCollider coll;
    // Start is called before the first frame update
    void Start()
    {
        //pstats = GetComponentInParent<PlayerStats>();
        //totaldamage = weapondamage += pstats.currentAttack;
        eventact = FindObjectOfType<EventActivator>();
        coll = GetComponent<CapsuleCollider>();
        resetSword();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Attack"))
        {
            coll.isTrigger = true;
            Invoke("resetSword", 0.5f);
        }
    }

    void resetSword()
    {
        coll.isTrigger = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "GolemBoss")
        {
            Destroy(other.gameObject);

        }
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            eventact.LoadScene();
            //enemyC.Damage(totaldamage);
        }
    }
}
