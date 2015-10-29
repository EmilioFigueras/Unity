using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Movimiento : MonoBehaviour {
		
	private int cont;
	public float speed;
	public Text countText;
	//public Text winText;
	
	public float force;
	private bool changeDir;
	private Vector3 dir;
	private Rigidbody rb;
	
	// Use this for initialization
	void Start () {
		changeDir = false;
		rb = GetComponent<Rigidbody>();
		dir = new Vector3 (0, 0, 0);
		cont = 0;
		SetCountText ();
		//winText.text = "";
	}
	void Update(){
		if (transform.position.y < -1) {
			this.transform.position= new Vector3(-8.4f,5.5f,-16.2f);
			rb.Sleep();
			dir= new Vector3(0,0,0);
		}
		if (Input.GetMouseButtonDown (0)) {
			rb.Sleep ();
			if(changeDir){
				dir= new Vector3(0,0,1);
				changeDir= false;
				
			}else{
				dir= new Vector3(1,0,0);
				changeDir=true;
			}
		}
	}
	// Update is called once per frame
	void FixedUpdate () {
		
		rb.MovePosition (transform.position + dir * Time.deltaTime * force);
	}

	public void OnCollisionEnter(Collision node)
	{
		if (node.gameObject.tag == "Destruye") {
			Destroy (node.gameObject);
			cont++;
			SetCountText ();
			
		}
		if (node.gameObject.tag == "Suelo") {
			Application.LoadLevel (Application.loadedLevelName);
			
		}
		if (node.gameObject.tag == "Final") {
			Application.LoadLevel ("Practica3_2");
			
		}
		if (node.gameObject.tag == "Final2") {
			Application.LoadLevel ("Practica3_1");
			
		}
	}

	void SetCountText(){
		countText.text = "Destruidos: " + cont.ToString();
	}

}
