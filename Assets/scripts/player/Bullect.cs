using UnityEngine;

public class Bullect : MonoBehaviour {
    public float Speed = 10f;

    public int Power = 1;

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    private void Update() {
    }

    private void FixedUpdate() {
        transform.Translate(transform.up * Speed * Time.deltaTime, Space.World);
    }


    private void OnTriggerEnter2D(Collider2D other) {
        //打击
        other.SendMessage("hint", Power);
        var objTag = other.tag;
        switch (objTag) {
            case "Wall":
                other.SendMessage("hint", Power);
                Destroy(gameObject);
                break;
            case "Steel":
                other.SendMessage("hint", Power);
                Destroy(gameObject);
                break;
            case "Heart":
                other.SendMessage("hint", Power);
                Destroy(gameObject);
                break;
            case "Grass":
                Debug.Log("击中Grass");
                break;
            case "River":
                Debug.Log("击中River");
                break;
            default:
                Debug.Log("正常飞行");
                break;
        }
    }
}