using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool isAlive;  // Flag to indicate if the cell is alive or dead

    void Start()
    {
        // Add any initialization code for the cell behavior
    }

    void Update()
    {
        // Add any update code for the cell behavior
    }

    public void SetCellState(bool state)
    {
        isAlive = state;
        // Implement visual changes or logic based on the cell's state
    }
}
