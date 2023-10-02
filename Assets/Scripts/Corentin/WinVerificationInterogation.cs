using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinVerificationInterogation : MonoBehaviour
{
    //fields

    private string _weaponAnswer;
    private string _suspectAnswer;
    private string _placeAnswer;

    [SerializeField] private string _weapon;
    [SerializeField] private string _suspect;
    [SerializeField] private string _place;

    [SerializeField] private TextMeshProUGUI _infoWeapon;
    [SerializeField] private TextMeshProUGUI _infoSuspect;
    [SerializeField] private TextMeshProUGUI _infoPlace;

    [SerializeField] private ClipBoardInteraction _clipBoardInteraction;

    private bool _hasWinInterogation;

    [SerializeField] private SoundManagerInterrogationRoom _soundManagerInterrogationRoom;

    //properties


    //Methods
    public bool WinCheck()
    {
        if ((_weapon == _weaponAnswer) && (_suspect == _suspectAnswer) && (_place == _placeAnswer))
        {
            //Debug.Log("j'ai gagné");
            _hasWinInterogation = true;

            _clipBoardInteraction.CanChange = false;

            _infoWeapon.color = Color.green;
            _infoSuspect.color = Color.green;
            _infoPlace.color = Color.green;

            _soundManagerInterrogationRoom.CorrectClipSound();

            return true;
        }
        else
        {
            //Debug.Log("j'ai pas encore gagné");
            return false;
        }
    }

    private void Awake()
    {
        _weaponAnswer = "Poison";
        _suspectAnswer = "Max Archer";
        _placeAnswer = "Mansion";
    }

    private void OnValidate()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _hasWinInterogation = true;

        _weapon = _infoWeapon.text;
        _suspect = _infoSuspect.text;
        _place = _infoPlace.text;
        if(_hasWinInterogation)
        {
            WinCheck();
        }
    }
}
