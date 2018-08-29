using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public float jump = 7f;
    [SerializeField]
    private Rigidbody2D myBody;

    private string[] colorsName;
    public string activeColor;

    public GameController gameController;
    
    void Awake()
    {
        colorsName = new string[4];
        colorsName[0] = "yellow";
        colorsName[1] = "pink";
        colorsName[2] = "cyan";
        colorsName[3] = "purple";

        activeColor = "";
    }

    void Start()
    {
        int randomColor = Random.Range(0, colorsName.Length);
        activeColor = colorsName[randomColor];
    }

    void Update () {
        if(transform.position.x != 50) { 

		if(Input.GetMouseButtonDown(0)|| Input.GetKeyDown(KeyCode.Space))
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
        if (target.tag == "star")
        {
            ScoreController.instance.AddScore();
            Destroy(target.gameObject);
        }

        if (target.tag == "color")
        {
            int randomColor = Random.Range(0, colorsName.Length);
            activeColor = colorsName[randomColor];
            Destroy(target.gameObject);
        }
    }

    IEnumerator Death()
    {
        gameController.GameOver();
        transform.position = new Vector2(50, transform.position.y);
        yield return new WaitForSeconds(10f);
    }
}
