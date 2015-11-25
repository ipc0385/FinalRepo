using UnityEngine;
using System.Collections;

public class Cells : MonoBehaviour
{
    [SerializeField]
    private GameObject Up;
    [SerializeField]
    private GameObject Forward;
    [SerializeField]
    private GameObject Back;
    [SerializeField]
    private GameObject Down;


    //==============================================
    private bool occupied = false;

    public bool isOccupied
    {
        get
        {
            if (transform.childCount == 0)
                return false;
            else return true;
        }
    }

    //public bool isOccupied() 
    //{
    //    return occupied;
    //}

    public void ChangeOccupancy()
    {
        if (occupied == true) occupied = false;
        if (occupied == false) occupied = true;
    }

    // ===============================================
    public GameObject GetUp(int x) 
    {
        if (x != 0)
        {
            x--;
            return Up.GetComponent<Cells>().GetUp(x);

        }
        else
        {
            return gameObject;
        }
    }

    public GameObject GetDown(int x)
    {
        if (x != 0)
        {
            x--;
            return Down.GetComponent<Cells>().GetDown(x);

        }
        else
        {
            return gameObject;
        }
    }
    public GameObject GetForward(int x)
    {
        if (x != 0)
        {
            x--;
            return Forward.GetComponent<Cells>().GetForward(x);

        }
        else
        {
            return gameObject;
        }
    }
    public GameObject GetBack(int x)
    {
        if (x != 0)
        {
            x--;
            return Back.GetComponent<Cells>().GetBack(x);

        }
        else
        {
            return gameObject;
        }
    }

    // ===== Check is the tile exists =======================
    // I reccomend running this before trying to get a tile.
    public bool UpExists(int x)
    {
        if (x > 1)
        {
            x--;
            return Up.GetComponent<Cells>().UpExists(x);

        }
        else
        {
            if (Up != null) return true;
            else return false;
        }
    }

    public bool DownExists(int x)
    {
        if (x > 1)
        {
            x--;
            return Down.GetComponent<Cells>().DownExists(x);

        }
        else
        {
            if (Down != null) return true;
            else return false;
        }
    }
    public bool ForwardExists(int x)
    {
        if (x > 1)
        {
            x--;
            return Forward.GetComponent<Cells>().ForwardExists(x);

        }
        else
        {
            if (Forward != null) return true;
            else return false;
        }
    }
    public bool BackExists(int x)
    {
        if (x > 1)
        {
            x--;
            return Back.GetComponent<Cells>().BackExists(x);

        }
        else
        {
            if (Back != null) return true;
            else return false;
        }
    }

    //==============================================================



    /*
    public void Begin_Turn()
    //begins a turn
    {
        Debug.Log("Begin_Turn unimplemented");
    }

    public void End_Turn()
    //ends a turn
    {
        Debug.Log("End_Turn unimplemented");
    }

    public Cells[] neighbors
    //gets the neightbors of the cell
    {
        get
        {
            Debug.Log("neighbors unimplemented");
            return null;
        }
    }

    public static Cells[] cellPlayerRangedCells
    //gets all the ranged cells on the player's side
    {
        get
        {
            Debug.Log("cellPlayerRangedCells unimplemented");
            return null;
        }
    }

    public static Cells[] cellEnemyRangedCells
    //gets all the ranged cells on the enemy's side
    {
        get
        {
            Debug.Log("cellEnemyRangedCells unimplemented");
            return null;
        }
    }

    public static Cells[] cellPlayerMeleeCells
    //gets all the melee cells on the player's side
    {
        get
        {
            Debug.Log("cellPlayerMeleeCells unimplemented");
            return null;
        }
    }

    public static Cells[] cellEnemyMeleeCells
    //gets all the melee cells on the enemy's side
    {
        get
        {
            Debug.Log("cellEnemyMeleeCells unimplemented");
            return null;
        }
    }
   */
   


}
