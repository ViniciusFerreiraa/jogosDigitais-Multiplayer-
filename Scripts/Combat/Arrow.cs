using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {
    public GameObject containerSkills;
    public Skills skills;
    public float speed;
    private bool casted;

    void Start()
    {
        containerSkills = GameObject.FindGameObjectWithTag("CombatController");
        skills = containerSkills.GetComponent<Skills>();
        Cast();
    }

    void Update()
    {
        if (casted)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(skills.tempEnemy.transform.position.x + .7f, skills.tempEnemy.transform.position.y + .3f, skills.tempEnemy.transform.position.z), speed);
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
