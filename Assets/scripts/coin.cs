using System.Runtime.CompilerServices;
using UnityEngine;

public class coin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            PlayerScript player = gameObject.GetComponent<PlayerScript>();
            if (player == null) return;
            player.AddCoin(1);
        }    
        }
}
