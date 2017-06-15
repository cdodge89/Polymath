using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardArranger : MonoBehaviour {
	char[] tileValues = new char[] {'0','1','2','3','4','5','6','7','8','9','+','-','*','/','^'};
	public GameObject tileObj;
	public float tileWidthInWorldUnits;
	public float screenWidthInWorldUnits;
	public float tileBufferInWorldUnits;
	private float tilesPerRow;

	private float distance;
	private Vector3 leftmost;
	private Vector3 rightmost;

	// tileValues[] = ['0','1','2','3','4','5','6','7','8','9','+','-','*','/','^'];

	// Use this for initialization
	void Start () {
		for (var i = 0; i < tileValues.Length; i++){
			distance = -1*Camera.main.transform.position.z;
			leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0f,0f,distance));
			rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1f,0f,distance));
			screenWidthInWorldUnits = (rightmost - leftmost).x;
			tileWidthInWorldUnits = tileObj.GetComponent<Renderer>().bounds.size.x;
			tileBufferInWorldUnits = tileWidthInWorldUnits/5;
			tilesPerRow = getTilesPerRow(tileWidthInWorldUnits, tileBufferInWorldUnits, screenWidthInWorldUnits);
			GameObject tile = Instantiate(tileObj, getTilePosition(transform.position, i, tilesPerRow), Quaternion.identity) as GameObject;
			Tile tileScript = tile.GetComponent<Tile>();
			tileScript.setValue(tileValues[i]);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private Vector3 getTilePosition (Vector3 v, float i, float tpr) {
		// I need to make this more generally useable to make responsive ui.
		return leftmost + new Vector3(i*tileWidthInWorldUnits+tileWidthInWorldUnits/2+(i/5),tileWidthInWorldUnits,0);
	}

	private float getTilesPerRow(float tileWidthInWorldUnits, float tileBufferInWorldUnits, float screenWidthInWorldUnits) {
		return Mathf.Floor(screenWidthInWorldUnits/(tileWidthInWorldUnits+tileBufferInWorldUnits));
	}
}
