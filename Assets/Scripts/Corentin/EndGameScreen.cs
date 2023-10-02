using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameScreen : MonoBehaviour
{
    // fields
    [SerializeField] private WinVerificationInterogation _winVerificationInterogation;

    private bool _isOnScreen;

    [SerializeField] private GameObject _panelEndScreen;

    [SerializeField] private Button _boutonEnds;

    [SerializeField] ClipBoardInteraction _clipInteraction;

    private bool _fading;

    // Properties

    // Methods

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_winVerificationInterogation.WinCheck() && !_isOnScreen)
        {
            _isOnScreen = true;
            _panelEndScreen.SetActive(true);
            if (_clipInteraction.IsOpen)
            {
                _clipInteraction.CloseClipBoard();
            }

            Debug.Log("endgame");
            StartCoroutine(EndGameAfterCountdown());
        }
    }

    IEnumerator EndGameAfterCountdown()
    {
        bool endCountdown;
        endCountdown = false;

        while (!endCountdown)
        {
            endCountdown = true;

            yield return new WaitForSeconds(5);
        }

        _boutonEnds.onClick.Invoke();
        Debug.Log("endgameEnds");
    }
}
