using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damageToGive;
    private int currentDamage;
    public GameObject damageNumber;

    private PlayerStats thePlayerStats;

    // Start is called before the first frame update
    void Start()
    {
        thePlayerStats = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            currentDamage = damageToGive = damageToGive - thePlayerStats.currentDefense;
            if(currentDamage < 0)
            {
                currentDamage = 0;
            }

           // other.gameObject.GetComponent<HealthManager>().HurtPlayer(currentDamage, direction);

            var clone = (GameObject)Instantiate(damageNumber, other.transform.position, Quaternion.Euler(Vector3.zero));
            //clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;


            //Vector3 hitDirection = other.transform.position - transform.position;
           // hitDirection = hitDirection.normalized;
            //FindObjectOfType<HealthManager>().HurtPlayer(damageToGive, hitDirection);
        }
    }
}
