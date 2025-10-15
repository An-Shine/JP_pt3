using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class PlayerContorller : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    AudioSource playerAudio;
    Animator playerAnim;
    readonly int Jump_TRIG = Animator.StringToHash("Jump_trig");
    readonly int DEATH_BOOL = Animator.StringToHash("Death_b");
    readonly int DEATH_TYPE = Animator.StringToHash("DeathType_int");

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);       //그때그때 필요한 audio 파일 불러와서 실행
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }      
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool(DEATH_BOOL, true);
            playerAnim.SetInteger(DEATH_TYPE, 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
