using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour {
    public float Speed = 3f;

//    public Sprite IconLeft;
//    public Sprite IconUp;
//    public Sprite IconRight;
//    public Sprite IconDown;

    public Transform ShootPosition; //子弹发射位置
    public GameObject Bullect;

    //方向
    private Dir _dir = Dir.Up;


    private SpriteRenderer _sp;


    private bool _canShoot = true;

    private Animator moveAnim;


    private void Awake() {
        _sp = GetComponent<SpriteRenderer>();

        moveAnim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }

    private void FixedUpdate() {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");
        Move(h, v);
        Shoot();
    }


    private void Move(float h, float v) {
        if (h != 0f || v != 0f) {
            moveAnim.SetBool("isMoving",true);
        }
        else {
            moveAnim.SetBool("isMoving",false);
        }

        //切换图片
        if (h > 0) //right
        {
            transform.eulerAngles = new Vector3(0, 0, -90); //由欧拉角直接指定
            //改变方向
            _dir = Dir.Right;
            //设置图片
        }
        else if (h < 0) {
            _dir = Dir.Left;
            transform.eulerAngles = new Vector3(0, 0, 90); //由欧拉角直接指定
        }


        if (v > 0) {
            _dir = Dir.Up;
            transform.eulerAngles = new Vector3(0, 0, 0); //由欧拉角直接指定
        }
        else if (v < 0) {
            _dir = Dir.Down;
            transform.eulerAngles = new Vector3(0, 0, 180); //由欧拉角直接指定
        }

        transform.Translate(Vector2.right * h * Speed * Time.deltaTime, Space.World);
        transform.Translate(Vector2.up * v * Speed * Time.deltaTime, Space.World);
    }

    private void Shoot() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (_canShoot) {
                Instantiate(Bullect, ShootPosition.position, ShootPosition.rotation);
                _canShoot = false;
                StartCoroutine(WaitShoot());
            }
        }
    }

    private enum Dir {
        Left,
        Up,
        Right,
        Down
    }

    private IEnumerator WaitShoot() {
        yield return new WaitForSeconds(.45f);
        _canShoot = true;
    }
}