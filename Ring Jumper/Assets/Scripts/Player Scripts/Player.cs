using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float jump = 7f;
    [SerializeField]
    private Rigidbody2D myBody;

    private string[] colorNames;
    public string activeColor;

    void Awake()
    {
        colorNames = new string[4];
        colorNames[0] = "yellow";
        colorNames[1] = "pink";
        colorNames[2] = "cyan";
        colorNames[3] = "purple";

        activeColor = "";
    }

	// Use this for initialization
	void Start () {
        int randomColor = Random.Range(0, colorNames.Length);
        activeColor = colorNames[randomColor];
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.Space))
        {
            myBody.velocity = Vector2.up * jump;
        }
	}
}
