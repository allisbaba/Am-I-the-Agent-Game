using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InventoryPanelController : MonoBehaviour
{

    private PlayerRaycast playerRaycast;
    public Text text;
    public GameObject canvas;
    public GameObject PuzzleCanvas;
    public GameObject KasaCanvas;
    public GameObject CanvasSecurity;
    public GameObject cableObj;
    private cable cable;
    public GameObject securityCam;
    
    public GameObject Security;
    private NPCSecurity NPCSecurity;
    
    public GameObject CameraForCams;
    public GameObject CameraForSecurity;
    public GameObject CameraForCEO;

    public int HowManyInfosNeedToCollect;  
    public int HowManyKeysNeedToCollect;

    public AudioSource Source;
    public AudioClip[] Clips;

    private GameObject _LookingObj;
    
    private int KeyCount = 0;   
    public int InfoCount = 0;    
    
    private bool SecurityOut = false;


    private void Start()
    {
        playerRaycast = GetComponent<PlayerRaycast>();
        NPCSecurity = Security.GetComponent<NPCSecurity>();
        cable = cableObj.GetComponent<cable>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;


    }

    private void Update()
    {
        canvas.transform.Find("InventoryPanel").Find("SlotKey").GetChild(0).GetComponent<Text>().text = (KeyCount).ToString() + "/" + HowManyKeysNeedToCollect;
        canvas.transform.Find("InventoryPanel").Find("SlotInfo").GetChild(0).GetComponent<Text>().text = (InfoCount).ToString() + "/" + HowManyInfosNeedToCollect;

         Looking();

        
        
        if(HowManyKeysNeedToCollect == 0)
        {
            canvas.transform.Find("InventoryPanel").Find("SlotKey").gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_LookingObj.CompareTag("Key"))
            {
                AddKeyToPanel(_LookingObj);
                _LookingObj = canvas;
            }
            if (_LookingObj.CompareTag("Info"))
            {

                AddInfoToPanel(_LookingObj);
                _LookingObj = canvas;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (playerRaycast.hit.collider.CompareTag("UnlockedDoor"))
            {
                Source.PlayOneShot(Clips[0]);
                _LookingObj.SetActive(false); 
            }

            if ((playerRaycast.hit.collider.CompareTag("SecurityDoor")) || (playerRaycast.hit.collider.CompareTag("LockedDoor")) || (playerRaycast.hit.collider.CompareTag("CEODoor")))
            {
                if (KeyCount <= 0)
                {
                    Source.PlayOneShot(Clips[1]);
                }
                else if (KeyCount > 0)
                {
                    if (!cable.isSwitched) //kameraya yakalanýyor
                    {
                        if (playerRaycast.hit.collider.CompareTag("SecurityDoor"))
                        {
                            if (SecurityOut)
                            {
                                text.text = "";
                                Source.PlayOneShot(Clips[0]);
                                _LookingObj.SetActive(false);  //Kapý açýlma anim
                                KeyCount--;
                                HowManyKeysNeedToCollect--;
                            }
                            else
                            {
                             _LookingObj.SetActive(false);
                            text.text = "";
                            CameraForSecurity.SetActive(true);
                            StartCoroutine(StartDelayBusted());

                            }
                           
                        }
                        else
                        {
                        _LookingObj.SetActive(false);  //sonra bak
                        text.text = "";
                        CameraForCams.SetActive(true);
                        StartCoroutine(StartDelayBusted());

                        }
                       
                       
                    }
                    else if (cable.isSwitched)
                    {
                        

                        text.text = "";
                        Source.PlayOneShot(Clips[0]);
                        _LookingObj.SetActive(false);  //Kapý açýlma anim
                        KeyCount--;
                        HowManyKeysNeedToCollect--;


                        if (playerRaycast.hit.collider.CompareTag("CEODoor") && (!(InfoCount == HowManyInfosNeedToCollect - 1)))
                        {
                            text.text = "";
                            CameraForCEO.SetActive(true);
                            StartCoroutine(StartDelayBusted());
                            
                        }


                    }

                }


            }
        }
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (_LookingObj.CompareTag("Break"))
            {
                SecurityOut = true;
                securityCam.SetActive(true);
                _LookingObj.tag = "Untagged";
                text.text = "";
                Source.PlayOneShot(Clips[8]);
                NPCSecurity.agentTransform();
                StartCoroutine(StartDelay());
                //securityCam.SetActive(false);
            }
            else if (_LookingObj.CompareTag("Switch"))
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                CanvasSecurity.SetActive(true);
                Time.timeScale = 0f;
            }
            else if (_LookingObj.CompareTag("Puzzle"))
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                PuzzleCanvas.SetActive(true);
                Time.timeScale = 0f;
            }

            else if ((_LookingObj.CompareTag("Safe")))
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                KasaCanvas.SetActive(true);
                Time.timeScale = 0f;
            }
           
        }



    }



    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Exit") && InfoCount == 8)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("LastScene");
        }
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(1.8f);
    }

    IEnumerator StartDelayBusted()
    {
       
        yield return new WaitForSeconds(1.5f);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("GameOver");

    }

    public void AddKeyToPanel(GameObject _triggeredObj)
    {
        if (KeyCount == 0)
        {
            canvas.transform.Find("InventoryPanel").Find("SlotKey").gameObject.SetActive(true);
            _triggeredObj.gameObject.SetActive(false);

            KeyCount++;

        }
        else if (KeyCount >= 1) //   || KeyCount < Keys.Length
        {

            _triggeredObj.gameObject.SetActive(false);
            
            KeyCount++;


        }
        Source.PlayOneShot(Clips[2]);
        text.text = "";
    }

    public void AddInfoToPanel(GameObject _triggeredObj)
    {
        if (InfoCount == 0)
        {
            canvas.transform.Find("InventoryPanel").Find("SlotInfo").gameObject.SetActive(true);
            _triggeredObj.gameObject.SetActive(false);
            InfoCount++;
        }
        else if (InfoCount >= 1)
        {
            _triggeredObj.gameObject.SetActive(false);
            InfoCount++;
        }

        Source.PlayOneShot(Clips[3]);
        text.text = "";
    }

    public void Looking()
    {

        if (playerRaycast.hit.collider != null && playerRaycast.hit.collider.tag != null)
        {
            if (playerRaycast.hit.collider.CompareTag("Key") )
            {
               text.text = "- Press F to pickup -";
               _LookingObj = playerRaycast.hit.collider.gameObject;
            }else if ((playerRaycast.hit.collider.CompareTag("Info")))
            {

                text.text = "- Press F to pickup -";
                _LookingObj = playerRaycast.hit.collider.gameObject;
            }
            else if ((playerRaycast.hit.collider.CompareTag("SecurityDoor")) || (playerRaycast.hit.collider.CompareTag("UnlockedDoor")) ||
                (playerRaycast.hit.collider.CompareTag("LockedDoor")) || (playerRaycast.hit.collider.CompareTag("CEODoor")))
            {
                text.text = "- Press R to open -";
                _LookingObj = playerRaycast.hit.collider.gameObject;
            }
            else if ((playerRaycast.hit.collider.CompareTag("Puzzle")) || (playerRaycast.hit.collider.CompareTag("Safe")) || (playerRaycast.hit.collider.CompareTag("Switch")))
            {
                text.text = "- Press Q to examine -";
                _LookingObj = playerRaycast.hit.collider.gameObject;
            }
            else if (playerRaycast.hit.collider.CompareTag("Break"))
            {
                text.text = "- Press Q to break -";
                _LookingObj = playerRaycast.hit.collider.gameObject;
            }
            else
            {
                 text.text = "";
                _LookingObj = canvas;

            }


        }
        else
        {
            text.text = "";
            _LookingObj = canvas;
        }
        
    }

   
}


