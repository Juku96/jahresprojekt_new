using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
	public void QuitGame () {
 		Application.Quit ();
 		Debug.Log("Game is quitting");
 		//Just to make sure its working
 	}
}
