using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class Buttons : NetworkBehaviour
{

    public PlayerScript playerScript;

    public void ZapocniVideo() {
        Debug.LogError("PRITISNUO ZAPOCNI VIDEO");
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        playerScript = networkIdentity.GetComponent<PlayerScript>();
        playerScript.CmdVideoPritisni();
    }

    public void Pritisni1()
    {
        Debug.LogError("PRITISNUO 1");
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        playerScript = networkIdentity.GetComponent<PlayerScript>();
        playerScript.CmdPritisni1();

    }

    public void Pritisni2()
    {
        Debug.LogError("PRITISNUO 2");
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        playerScript = networkIdentity.GetComponent<PlayerScript>();
        playerScript.CmdPritisni2();

    }

    public void Otpusti1()
    {
        Debug.LogError("OTPUSTIO 1");
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        playerScript = networkIdentity.GetComponent<PlayerScript>();
        playerScript.CmdOtpusti1();

    }

    public void Otpusti2()
    {
        Debug.LogError("OTPUSTIO 2");
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        playerScript = networkIdentity.GetComponent<PlayerScript>();
        playerScript.CmdOtpusti2();

    }

    public void Pritisni()
    {
        Debug.LogError("PRITISNUO 3");
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        playerScript = networkIdentity.GetComponent<PlayerScript>();
        playerScript.CmdPritisni();
    }

    public void Otpusti()
    {
        Debug.LogError("OTPUSTIO 3");
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        playerScript = networkIdentity.GetComponent<PlayerScript>();
        playerScript.CmdOtpusti();
    }

    public void PritisniDS()
    {
        Debug.LogError("PRITISNUO 4");
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        playerScript = networkIdentity.GetComponent<PlayerScript>();
        playerScript.CmdPritisniDS();
    }

    public void OtpustiDS()
    {
        Debug.LogError("OTPUSTIO 4");
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        playerScript = networkIdentity.GetComponent<PlayerScript>();
        playerScript.CmdOtpustiDS();
    }

    public void Pritisni5()
    {
        Debug.LogError("PRITISNUO 5");
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        playerScript = networkIdentity.GetComponent<PlayerScript>();
        playerScript.CmdPritisni5();

    }

    public void Pritisni6()
    {
        Debug.LogError("PRITISNUO 6");
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        playerScript = networkIdentity.GetComponent<PlayerScript>();
        playerScript.CmdPritisni6();

    }

    public void Otpusti5()
    {
        Debug.LogError("OTPUSTIO 5");
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        playerScript = networkIdentity.GetComponent<PlayerScript>();
        playerScript.CmdOtpusti5();

    }

    public void Otpusti6()
    {
        Debug.LogError("OTPUSTIO 6");
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        playerScript = networkIdentity.GetComponent<PlayerScript>();
        playerScript.CmdOtpusti6();

    }

    public void Click1()
    {
        Debug.LogError("Click1");
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        playerScript = networkIdentity.GetComponent<PlayerScript>();
        playerScript.CmdClick1();
    }

    public void Click2()
    {
        Debug.LogError("Click2");
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        playerScript = networkIdentity.GetComponent<PlayerScript>();
        playerScript.CmdClick2();
    }

    public void Unclick1()
    {
        Debug.LogError("Unclick1");
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        playerScript = networkIdentity.GetComponent<PlayerScript>();
        playerScript.CmdUnclick1();
    }

    public void Unclick2()
    {
        Debug.LogError("Unclick2");
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        playerScript = networkIdentity.GetComponent<PlayerScript>();
        playerScript.CmdUnclick2();
    }

    public void Click3()
    {
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        playerScript = networkIdentity.GetComponent<PlayerScript>();
        playerScript.CmdClick3();
    }

    public void Click4()
    {
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        playerScript = networkIdentity.GetComponent<PlayerScript>();
        playerScript.CmdClick4();
    }

    public void Unclick3()
    {
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        playerScript = networkIdentity.GetComponent<PlayerScript>();
        playerScript.CmdUnclick3();
    }

    public void Unclick4()
    {
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        playerScript = networkIdentity.GetComponent<PlayerScript>();
        playerScript.CmdUnclick4();
    }

}
