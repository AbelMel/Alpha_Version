using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyObject : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerHealth playerHealth;
    private GameObject player;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy")
        {

            Cursor.lockState = CursorLockMode.None;
            Destroy(player);

            playerHealth.Dead();

            SceneManager.LoadScene("GameOver");


            Debug.Log("Dead");
        }
    }
}
