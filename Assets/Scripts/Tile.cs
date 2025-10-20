using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int Xcoord;
    public int Ycoord;

    public bool isAlive;
    public bool nextState;

    public int State;

    [SerializeField] private Color _baseColor;
    [SerializeField] private Color _state4, _state3, _state2, _state1, _state0;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;

    public void Init()
    {
        _renderer.color = _baseColor;
        isAlive = false;
        nextState = false;
        State = 0;
    }

    public void TurnAction()
    {
        if (nextState)
        {
            State = 40;
            isAlive = true;
        }
        else if (!nextState && State > 0)
            State--;



        if (State != 40)
            isAlive = false;

        nextState = false;
        ChangeStateColor();
    }
    void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }
   
    void OnMouseExit()
    {
        _highlight.SetActive(false);
    }

    private void OnMouseDown()
    {
        isAlive = !isAlive;
        ChangeStateColor();
        Debug.Log("Clicked on tile. X: " + Xcoord.ToString() + " Y: " +Ycoord.ToString());
    }

    private void ChangeStateColor()
    {
        if (State == 40)
            _renderer.color = _state4;
        else if (State <= 39 && State >20)
            _renderer.color = _state3;
        else if (State <= 20 && State >10)
            _renderer.color = _state2;
        else if (State <= 10 && State >0)
            _renderer.color = _state1;
        else if (State == 0)
            _renderer.color = _state0;

        /*
        switch (State)
        {
            case 4:
                _renderer.color = _state4;
                break;
            case 3:
                _renderer.color = _state3;
                break;
            case 2:
                _renderer.color = _state2;
                break;
            case 1:
                _renderer.color = _state1;
                break;
            case 0:
                _renderer.color = _state0;
                break;
        }
        */
    }
}