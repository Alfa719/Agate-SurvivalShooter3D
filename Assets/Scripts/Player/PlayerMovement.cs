using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;
    int floorMask;
    float camRayLength = 100f;

    private void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        Turning();
        Animating(h, v);
    }
    //Berjalan
    public void Move(float h, float v)
    {
        //Set nilai var movement
        movement.Set(h, 0f, v);

        //Normalisasi
        movement = movement.normalized * speed * Time.deltaTime;

        //Move dengan rigidbody
        playerRigidbody.MovePosition(transform.position + movement);
    }
    //Arah lihat
    void Turning()
    {
        //Masukan posisi mouse di ray
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Raycast floorhit
        RaycastHit floorHit;

        //buat raycast
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            //Mendapatkan vector dari posisi player dan posisi floorHit
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            //Mendapatkan look rotation baru ke hit position
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            //Rotasi player
            playerRigidbody.MoveRotation(newRotation);
        }
    }
    //set kondisi animasi
    public void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
        //Debug.Log(walking);
    }
    public void Run()
    {
        StartCoroutine(SetSpeed(3));
    }

    IEnumerator SetSpeed(int value)
    {
        speed += value;
        yield return new WaitForSeconds(5);
        speed = 6f;
    }
}
