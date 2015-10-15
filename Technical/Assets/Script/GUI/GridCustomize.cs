using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GridCustomize : MonoBehaviour {

	// Use this for initialization
    public RectTransform parentRect;
    public GridLayoutGroup parentGrid;
    public int cellCount;
    public int cellSpace;
    public Vector2 cellSize;
    private Vector2 parentSize;

	void Start () {
        parentSize = parentRect.rect.size;
        cellSize = new Vector2();
        CalCellSize();
        ChangeCellSize();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CalCellSize()
    {
        cellSize.x = parentSize.x / cellCount - cellSpace / 2;
        cellSize.y = cellSize.x;
    }

    public void ChangeCellSize()
    {
        parentGrid.cellSize = cellSize;
        parentGrid.spacing = new Vector2(cellSpace, 0);
        parentGrid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        parentGrid.constraintCount = cellCount;
    }
}
