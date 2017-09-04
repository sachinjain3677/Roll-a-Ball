using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
    public Text countText;
    public Text winText;
    public Text restartText;
    public int count;
    public int startWait;


    private Rigidbody rb;
    private bool gameOver;
  

    

	void Start(){
        StartCoroutine(WaitStart());
        rb = GetComponent<Rigidbody> ();
        count = 0;
        SetCountText();
        winText.text = "";
        restartText.text = "";
        
    }


    private void Update()
    {
        if (gameOver) {
            if (Input.GetKeyDown(KeyCode.R)) {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
    
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement*speed);
	}

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Pick Up")) {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }


    IEnumerator WaitStart() {
        yield return new WaitForSeconds(startWait);
    }


    void SetCountText() {
        countText.text = "Count: " + count.ToString();
        if (count >= 12) {
            winText.text = "YOU WIN!";
            restartText.text = "Press 'R' to restart";
            gameOver = true;
        }
    }
}
