using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private Player playerColor;
    private SpriteRenderer playerSR;

    private Color[] colors;

	// Use this for initialization
	void Start () {
        colors = new Color[4];
        // yellow
        colors[0] = new Color(245 / 255f, 222 / 255f, 22 / 255f, 1f);
        // pink
        colors[1] = new Color(244 / 255f, 5 / 255f, 132 / 255f, 1f);
        // cyan
        colors[2] = new Color(48 / 255f, 228 / 255f, 242 / 255f, 1f);
        // purple
        colors[3] = new Color(143 / 255f, 16 / 255f, 253 / 255f, 1f);
        playerColor = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerSR = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
		if(playerColor.activeColor == "yellow")
            playerSR.color = colors[0];
        if (playerColor.activeColor == "pink")
            playerSR.color = colors[1];
        if (playerColor.activeColor == "cyan")
            playerSR.color = colors[2];
        if (playerColor.activeColor == "purple")
            playerSR.color = colors[3];
    }
}
