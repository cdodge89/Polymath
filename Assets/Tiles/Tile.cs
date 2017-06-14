using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
	public char value;
	private int slot;

	// Use this for initialization
	protected virtual void Start () {
		
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		Debug.Log("parent tile");
	}

	//METHODS
	public char getValue () {
		return value;
	}

	public int getSlot () {
		return slot;
	}

	public void setSlot (int s) {
		slot = s;
	}

	public void setValue (char v) {
		value = v;
	}
}
