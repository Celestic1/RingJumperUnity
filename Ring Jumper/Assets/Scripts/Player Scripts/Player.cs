using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float jump = 7f;
    [SerializeField]
    private Rigidbody2D myBody;

    private string[] colorNames;
    public string activeColor;

    private bool canJump = true;

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
        if (canJump)
        {
            if (Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.Space))
            {
                myBody.velocity = Vector2.up * jump;
            }
        }
	}
    public void GameOver()
    {
        StartCoroutine(Death());
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "star")
        {
            Destroy(target.gameObject);
        }
        if(target.tag == "color")
        {
            int randomColor = Random.Range(0, colorNames.Length);
            activeColor = colorNames[randomColor];
            Destroy(target.gameObject);
        }
    }

    IEnumerator Death()
    {
        transform.position = new Vector2(50, transform.position.y);
        myBody.isKinematic = true;
        canJump = false;
        yield return new WaitForSeconds(0.3f);
    }
}
