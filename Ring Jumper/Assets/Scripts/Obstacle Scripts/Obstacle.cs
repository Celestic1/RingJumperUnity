using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    private Player player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
    void OnTriggerEnter2D(Collider2D target)
    {
        if(player.activeColor != this.tag)
        {
            player.GameOver();
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
