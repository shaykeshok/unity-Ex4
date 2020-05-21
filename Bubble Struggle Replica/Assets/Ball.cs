using System;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class Ball : MonoBehaviour {

	public Vector2 startForce;

	public GameObject nextBall;

	public Rigidbody2D rb;
	public static int index=0;
	public static int level = 1;
	// Use this for initialization
	void Start () {
		rb.AddForce(startForce, ForceMode2D.Impulse);
		if (level == 2)
		{
			rb.AddForce(startForce, ForceMode2D.Impulse);
			rb.AddForce(startForce, ForceMode2D.Impulse);
			rb.AddForce(startForce, ForceMode2D.Impulse);
			rb.AddForce(startForce, ForceMode2D.Impulse);
		}
		if (level == 3)
		{
			rb.AddForce(startForce, ForceMode2D.Impulse);
			rb.AddForce(startForce, ForceMode2D.Impulse);
			rb.AddForce(startForce, ForceMode2D.Impulse);
			rb.AddForce(startForce, ForceMode2D.Impulse);
		}
	}

	public void Split ()
	{
		if (nextBall != null)
		{
			GameObject ball1 = Instantiate(nextBall, rb.position + Vector2.right / 4f, Quaternion.identity);
			GameObject ball2 = Instantiate(nextBall, rb.position + Vector2.left / 4f, Quaternion.identity);



			ball1.GetComponent<Ball>().startForce = new Vector2(2f, 5f);
			ball2.GetComponent<Ball>().startForce = new Vector2(-2f, 5f);
		}
		else
		{

			//Debug.Log(index);
			if (index == 7)
			{
				Debug.Log("end of level" + level);
				level++;
				index = 0;
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}else
				index++;
		}



		Destroy(gameObject);
	}

}
