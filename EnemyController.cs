using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : EnemyManager
{
    private string key_Health = "Health";
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Attacking()
    {
        StartCoroutine(AttackCoroutine());
    }

    private IEnumerator AttackCoroutine()
    {
        AttackFlag = true;
        yield return new WaitForSeconds(1f);
        AttackFlag = false;
    }

    public GameObject Damage(int damage)
    {
        if (Health - damage <= 0)
        {
            anim.SetInteger(key_Health, 0);
            DropTreasure();
            Destroy(gameObject);
            return gameObject;
        }
        Health -= damage;
        anim.SetTrigger("Damage");
        return null;
    }

    /// <summary>
    /// クリスタルドロップ
    /// </summary>
    private void DropTreasure()
    {
        string path = "Prefabs/GoldBar" + treasure;
        GameObject cry = Instantiate(Resources.Load<GameObject>(path), transform);
        cry.transform.localPosition = new Vector3(0, 0, 0);
        cry.transform.SetParent(transform.parent);
        Debug.Log(transform.position);
        Debug.Log("local" + transform.localPosition);
        cry.transform.localScale = new Vector3(1, 1, 1);
        cry.GetComponent<CapsuleCollider>().enabled = false;
    }
}