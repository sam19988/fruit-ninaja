using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bomb : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        blade b = collision.GetComponent<blade>();
        if (!b)
            return;
        FindObjectOfType<gameManager>().onBombHit();
    }
}
