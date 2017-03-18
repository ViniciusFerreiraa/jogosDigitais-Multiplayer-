using UnityEngine;
using System.Collections;

public class EnemySpell : MonoBehaviour {
    public GameObject containerPlayer;
    public float speed;
    private bool casted;

    void Start()
    {
        containerPlayer = GameObject.FindGameObjectWithTag("Player");
        Invoke("Cast", 2);
    }

    void Update()
    {
        if (casted)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(containerPlayer.transform.position.x, containerPlayer.transform.position.y + 0.5f, containerPlayer.transform.position.z), speed);
        }
    }

    void Cast()
    {
        casted = true;
        Invoke("DestroySpell", 2);
    }

    void DestroySpell()
    {
        Destroy(this.gameObject);
    }
}
