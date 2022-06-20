using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;

    private ScoreboardManager sbm;

    void Start()
    {
        sbm = (ScoreboardManager)FindObjectOfType(typeof(ScoreboardManager));
    }

    void Update()
    {
        transform.Rotate(0, 0, 80f * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            sbm.UpdateScore(coinValue);
            gameObject.SetActive(false);
        }
    }
}
