using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public bool isGr1;
    public bool isGr2;
    public bool isGr3;
    public bool isGr4;

    public bool isIc1;
    public bool isIc2;
    public bool isIc3;
    public bool isIc4;

    public bool isDe1;
    public bool isDe2;
    public bool isDe3;
    public bool isDe4;

    public bool isMo1;
    public bool isMo2;
    public bool isMo3;
    public bool isMo4;

    public bool isSIH1;
    public bool isSIH2;
    public bool isSIH3;
    public bool isSIH4;

    string talking;

    public GameObject playerIcon;
    public GameObject GrassEIcon;
    public GameObject IceEIcon;
    public GameObject DesertEIcon;
    public GameObject MountainEIcon;
    public GameObject SIH1Icon;
    public GameObject SIH2Icon;
    public GameObject SIH3Icon;
    public GameObject SIH4Icon;

    public GameObject logPanel;
    public Text speech;

    Battle Ba;
    moving Mo;

    // Start is called before the first frame update
    void Start()
    {
        Ba = GameObject.Find("Manager").GetComponent<Battle>();
        Mo = GameObject.Find("Player").GetComponent<moving>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BoxOn()
    {
        logPanel.SetActive(true);
    }

    public void Leave()
    {
        logPanel.SetActive(false);
        Mo.inAction = false;

        #region Icons off

        GrassEIcon.SetActive(false);
        IceEIcon.SetActive(false);
        DesertEIcon.SetActive(false);
        MountainEIcon.SetActive(false);
        SIH1Icon.SetActive(false);
        SIH2Icon.SetActive(false);
        SIH3Icon.SetActive(false);
        SIH4Icon.SetActive(false);

        #endregion
    }

    public void WhoIsIt()
    {
        #region GrassEnemy
        if (isGr1 == true)
        {
            GrassEIcon.SetActive(true);
        }

        if (isGr2 == true)
        {
            GrassEIcon.SetActive(true);
        }

        if (isGr3 == true)
        {
            GrassEIcon.SetActive(true);
        }

        if (isGr4 == true)
        {
            GrassEIcon.SetActive(true);
        }
        #endregion

        #region IceEnemy
        if (isIc1 == true)
        {
            IceEIcon.SetActive(true);
        }

        if (isIc2 == true)
        {
            IceEIcon.SetActive(true);
        }

        if (isIc3 == true)
        {
            IceEIcon.SetActive(true);
        }

        if (isIc4 == true)
        {
            IceEIcon.SetActive(true);
        }
        #endregion

        #region DesertEnemy
        if (isDe1 == true)
        {
            DesertEIcon.SetActive(true);
        }

        if (isDe2 == true)
        {
            DesertEIcon.SetActive(true);
        }

        if (isDe3 == true)
        {
            DesertEIcon.SetActive(true);
        }

        if (isDe4 == true)
        {
            DesertEIcon.SetActive(true);
        }
        #endregion

        #region MountainEnemy
        if (isMo1 == true)
        {
            MountainEIcon.SetActive(true);
        }

        if (isMo2 == true)
        {
            MountainEIcon.SetActive(true);
        }

        if (isMo3 == true)
        {
            MountainEIcon.SetActive(true);
        }

        if (isMo4 == true)
        {
            MountainEIcon.SetActive(true);
        }
        #endregion

        #region SIH
        if (isSIH1 == true)
        {
            SIH1Icon.SetActive(true);
        }

        if (isSIH2 == true)
        {
            SIH2Icon.SetActive(true);
        }

        if (isSIH3 == true)
        {
            SIH3Icon.SetActive(true);
        }

        if (isSIH4 == true)
        {
            SIH4Icon.SetActive(true);
        }
        #endregion

    }

    public void Fight()
    {
        Ba.Begin();
    }

    public void TalkShit()
    {
        speech.text = talking;
    }

    private static Dialog _instance;

    public static Dialog Instance
    {
        get
        {
            if (!_instance) _instance = FindAnyObjectByType<Dialog>();
            return _instance;
        }
    }
}
