using Mirror;
using UnityEngine;

public class Ready : NetworkBehaviour
{

    [SyncVar] private bool igraci1 = false;
    [SyncVar] private bool igraci2 = false;
    public Vector3 teleportPosition = new Vector3(28.4f, 6.6f, -58.7f);
    public GameObject gameObject;

    public void ready1()
    {
        igraci1 = true;
        Debug.LogError("1: "+igraci1);
        Debug.LogError("2: "+igraci2);

        if(igraci1 && igraci2)
        {
            gameObject.transform.position = teleportPosition;
        }
    }

    public void unready1()
    {
        igraci1 = false;
        Debug.LogError("1: "+igraci1);
        Debug.LogError("2: "+igraci2);
    }

    public void ready2()
    {
        igraci2 = true;
        Debug.LogError("1: "+igraci1);
        Debug.LogError("2: "+igraci2);

        if (igraci1 && igraci2)
        {
            gameObject.transform.position = teleportPosition;
        }
    }

    public void unready2()
    {
        igraci2 = false;
        Debug.LogError("1: "+igraci1);
        Debug.LogError("2: "+igraci2);
    }

}
