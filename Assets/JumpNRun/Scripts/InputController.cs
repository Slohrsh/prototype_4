using UnityEngine;

public class InputController : MonoBehaviour {

    public Movable movable;
    public float WalkSpeed = 6f;
    public float RunSpeed = 12f;
    public float JumpForce = 5f;
    public GameManager gameManager;

    private float move;
    
    // Use this for initialization
    void Start () {
        movable = GetComponent<Movable>();
		if(movable == null)
        {
            Debug.LogError("Movable Controller not found");
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        move = 0;
        if(!gameManager.isGameOver)
        {
            if (gameManager.view == View.ThirdPerson)
            {
                move = Input.GetAxis("Horizontal");
            }
            else
            {
                move = Input.GetAxis("Vertical");
                if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                {
                    movable.Rotate(-1);
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                {
                    movable.Rotate(1);
                }
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                move *= RunSpeed;
            }
            else
            {
                move *= WalkSpeed;
            }

            if (Input.GetButtonDown("Jump"))
            {
                movable.Jump(JumpForce);
            }
        }
        movable.Move(move);
    }
}
