using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text gameText;

	private enum States {cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, freedom};
	private States myState;
	
	// Use this for initialization
	void Start () {
		myState = States.cell;
		gameText.text = "Welcome to Prison Escape!";
	}
	
	// Update is called once per frame
	void Update () {
		print(myState);
		if(myState == States.cell) 				{Cell();} 
		else if (myState == States.sheets_0)	{Sheets0();} 
		else if (myState == States.sheets_1)	{Sheets1();}
		else if (myState == States.lock_0)		{Lock0();}
		else if (myState == States.lock_1)		{Lock1();}
		else if (myState == States.mirror)		{Mirror();}
		else if (myState == States.cell_mirror)	{CellMirror();}
		else if (myState == States.freedom)		{Freedom();}
	}
	
	void Cell(){
		gameText.text = "You find yourself in a prison cell, and you want to escape. There are " +
						"some dirty sheets on the bed, a mirror on the wall, and a door " +
						"is locked from the outside!\n\n" + 
						"Press S to View Sheets, M to view the Mirror, and L to view the Lock";
				
		if (Input.GetKeyDown(KeyCode.S))		{myState = States.sheets_0;}
		else if (Input.GetKeyDown(KeyCode.M))		{myState = States.mirror;}
		else if (Input.GetKeyDown(KeyCode.L))		{myState = States.lock_0;}
	}
	
	void Sheets0(){
		gameText.text = "You can't believe you sleep in these things. Sure it's " +
						"time somebody changed them. The pleasures of prison life. I guess!\n\n" + 
						"Press R to Return to your cell";
		
		if (Input.GetKeyDown(KeyCode.R))		{myState = States.cell;}
	}
	
	void Sheets1(){
		gameText.text = "Holding a mirror in your hand doesn't make the sheets look " +
						"any better!\n\n" + 
						"Press R to Return to your cell";
		
		if (Input.GetKeyDown(KeyCode.R))		{myState = States.cell_mirror;}
	}
	
	void Lock0(){
		gameText.text = "You have no idea what the lock combination is. " +
						"You wish you could pick the lock!\n\n" + 
						"Press R to Return to your cell";
		
		if (Input.GetKeyDown(KeyCode.R))		{myState = States.cell;}
	}
	
	void Lock1(){
		gameText.text = "You carefully put the mirror through the bars, and turn it around " +
						"so you can see the lock. You can make out fingerprints around the buttons."+
						"You press the dirty buttons and hear a click!\n\n" + 
						"Press O to Open, or R to Return to your cell";
		
		if (Input.GetKeyDown(KeyCode.O))		{myState = States.freedom;}
		else if (Input.GetKeyDown(KeyCode.R))	{myState = States.cell_mirror;}
	}
	
	void Mirror ()
	{
		gameText.text = "The dirty old mirror on the wall seems lose \n\n" + 
						"Press T to Take the mirror, or R to Return to your cell";
		
		if (Input.GetKeyDown(KeyCode.T))		{myState = States.cell_mirror;}
		else if (Input.GetKeyDown(KeyCode.R))	{myState = States.cell;}
	}

	void CellMirror ()
	{
		gameText.text = "You are still in your cell, and you STILL want to escape! " + 
						"There are some dirty sheets on the bed, a mark where the mirror was, " +
						"and that pesky door is still there, and firmly locked!\n\n" +
						"Press S to view Sheets, or L to view Lock";
		
		if (Input.GetKeyDown(KeyCode.S))		{myState = States.sheets_1;}
		else if (Input.GetKeyDown(KeyCode.L))	{myState = States.lock_1;}
	}

	void Freedom ()
	{
		gameText.text = "You are FREE!\n\n" + 
						"Press P to Play again";
		
		if (Input.GetKeyDown(KeyCode.P))		{myState = States.cell;}
	}
	
}
