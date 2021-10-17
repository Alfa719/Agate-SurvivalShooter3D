using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItemScript : MonoBehaviour
{
    PlayerMovement moveSpeed;
    private void Start()
    {
        moveSpeed = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            moveSpeed.Run();
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
