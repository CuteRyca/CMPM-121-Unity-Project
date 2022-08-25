using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class Player : MonoBehaviour
{
    CharacterController characterController;

    public float speed;
    public float damage = 10f;
    public GameObject bullet;
    public GameObject bullet2;
    public int score;
    public Text scoreText;
    
    Camera m_MainCamera;
    public Camera m_CameraTwo;
    Animator anim;
    AudioSource audioSource;
    bool isPaused;
    GameObject[] pauseObjects;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        score = 0;
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        characterController = GetComponent<CharacterController>();
        //This gets the Main Camera from the Scene
        m_MainCamera = Camera.main;
        //This enables Main Camera
        m_MainCamera.enabled = true;
        //Use this to disable secondary Camera
        m_CameraTwo.enabled = false;

        anim = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
        pauseObjects = GameObject.FindGameObjectsWithTag("Pause");
        foreach (GameObject pauseObject in pauseObjects) 
        {
            pauseObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel")) 
        {
            if (isPaused)
            {
                Unpause();
            }else 
            {
                Pause();
            }
        }
        //rotate
        Vector3 cameraDirection = m_MainCamera.transform.forward;
        cameraDirection.y = 0;
        transform.LookAt(transform.position + cameraDirection);


        //move
        Vector3 movement = m_MainCamera.transform.right * Input.GetAxis("Horizontal") + m_MainCamera.transform.forward * Input.GetAxis("Vertical");
        movement = Vector3.ClampMagnitude(movement, 1);
        movement *= speed * Time.deltaTime;
        characterController.SimpleMove(movement);

        //animate
        if (movement.magnitude > 0)
        {
            anim.SetBool("isWalking", true);
        }
        else 
        {
            anim.SetBool("isWalking", false);
        }
        


        if (Input.GetKeyDown(KeyCode.L))
        {
            //Check that the Main Camera is enabled in the Scene, then switch to the other Camera on a key press
            if (m_MainCamera.enabled)
            {
                //Enable the second Camera
                m_CameraTwo.enabled = true;

                //The Main first Camera is disabled
                m_MainCamera.enabled = false;
            }
            //Otherwise, if the Main Camera is not enabled, switch back to the Main Camera on a key press
            else if (!m_MainCamera.enabled)
            {
                //Disable the second camera
                m_CameraTwo.enabled = false;

                //Enable the Main Camera
                m_MainCamera.enabled = true;
            }
        }
        
        if (Input.GetKeyDown("space")) 
        {
           audioSource.Play();
           Instantiate(bullet, transform.position + transform.forward * 2, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            Shoot();
        }
    }
    void Shoot() 
    {

        Ray ray = new Ray(transform.position, Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) 
        {
            Debug.Log(hit.transform.name);
            Instantiate(bullet2, transform.position + transform.forward, Quaternion.identity);
           
        } 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            
            score += 1;
            scoreText.text = "Score "+score;
        }
        if (other.gameObject.CompareTag("Enemy"))
        {

            score -= 1;
            scoreText.text = "Score " + score;
        }
    }

    void Pause() 
    {
        Cursor.lockState = CursorLockMode.Confined;
        isPaused = true;
        Time.timeScale = 0;
        foreach (GameObject pauseObject in pauseObjects)
        {
            pauseObject.SetActive(true);
        }
    }
    public void Unpause() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;
        Time.timeScale = 1;
        foreach (GameObject pauseObject in pauseObjects)
        {
            pauseObject.SetActive(false);
        }
    }
}
