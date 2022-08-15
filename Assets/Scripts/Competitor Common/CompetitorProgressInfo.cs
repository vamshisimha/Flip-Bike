using UnityEngine;

public class CompetitorProgressInfo : MonoBehaviour
{
    private int _rank;
    public int Position
    {
        get
        {
            return _rank;
        }
        set
        {
            _rank = value;
        }
    }

    public float WorldPos_Z()  
    {
        return transform.position.z;
    }
}
