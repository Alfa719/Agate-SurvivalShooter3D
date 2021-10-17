using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItemScript : MonoBehaviour
{
    PlayerHealth health;
    void Start()
    {
        health = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            health.Heal(10);
            Destroy(this.gameObject);
        }
        StartCoroutine(RemoveItem(this.gameObject));
        
    }
    IEnumerator RemoveItem(GameObject Item)
    {
        yield return new WaitForSeconds(5);
        Destroy(Item);
    }
}
