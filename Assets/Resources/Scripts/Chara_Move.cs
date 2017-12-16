using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]//キャラクターコントローラがアタッチされていることを保証

public class Chara_Move : MonoBehaviour
{
    lifeManager lifemanager;

    #region variables
    CharacterController _controller;
    Transform _transform;
    Transform player;
    Animator anim;

    [SerializeField]
    bool isGrounded = true;

    bool before_isGrounded = true;
    [SerializeField]
    bool isJumping = false;
    [SerializeField]
    bool isSpring = false;
    [SerializeField]
    bool isdamage = false;
    bool istoge = false;

    public bool isClear = false;
    bool CLeff = false;

    [SerializeField]
    bool isGameOver = false;
    [SerializeField]
    bool GOeff = false;

    float knockbackTime;
    Vector3 knockbackDirection;
    float knockbackSpeed;

    float BlinkTime = 3.5f;
    Vector3 playerPos;
    bool blink = false;

    #region movement variables
    public float speed = 8f;
    public float gravity = 100f;
    Vector3 moveDirection;
    float maxRotSpeed = 200.0f;
    float minTime = 0.1f;
    float _Velocity;
    public float JumpHeight = 2000;

    float range;

    bool isCorouting;
    #endregion
    #region delegate variable
    delegate void DelFunc();
    delegate IEnumerator DelEnum();
    DelFunc _delFunc;
    DelEnum _delEnum;
    bool del;

    public static int life;

    bool goaleffectflag = false;


    #endregion
    #endregion


    // Use this for initialization
    void Start()
    {
        anim = GameObject.Find("model_player").GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();
        _transform = GetComponent<Transform>();//_controllerでコントローラーを制御
        lifemanager = GameObject.Find("lifeManager").GetComponent<lifeManager>(); 


        range = 30f;
        life = GameParameter.instance._LIFE;

        //animation ["RotateWait"].wrapMode = WrapMode.Once;
        _delEnum = null;
        del = true;
        isCorouting = false;
        isClear = false;
        goaleffectflag = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (GameParameter.instance.isMenu) return;
        hitcheck();

        // Debug.Log(istoge);
        if (!isClear && !isGameOver)
        {
            Move();
        }
        if (life <= 0)
        {
            life = 0;
            isGameOver = true;
        }

        if (isGameOver && !GOeff)
        {
            if (GameParameter.instance.isGlobal)
            {
                GetAllStageData.Instance.GetSelectStageData.missCount++;
                GetAllStageData.Instance.SendDeathPoint(transform.position);
            }
			if (GameParameter.instance.isEdit)
            {
                GameObject obj = Instantiate(Resources.Load<GameObject>("Prefabs/missEffect"));
            }
            else
            {
                GameObject obj = Instantiate(Resources.Load<GameObject>("Prefabs/missEffect_retry"));
                obj.GetComponent<missEffect>().backSceneName = GameParameter.instance.isGlobal ? "gameGlobalScene" : "gameScene";
            }
            GOeff = true;
        }
        else if (isClear && !CLeff)
        {
            Instantiate(Resources.Load<GameObject>("Prefabs/goalEffect"));
            CLeff = true;
			if (GameParameter.instance.isGlobal) GetAllStageData.Instance.GetSelectStageData.clearCount++;
            if (!goaleffectflag)
            {
                if (GameParameter.instance.goalEffectID != -1)
                {
                    Instantiate(Resources.Load<GameObject>("Prefabs/goalEffect_" + GameParameter.instance.goalEffectID.ToString()), transform.position, Quaternion.identity);
                }
                    goaleffectflag = true;
            }
            Invoke("Clear_Trans",3.0f);
        }

        if (isdamage)
        {
            if (knockbackTime < 0 )//anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            {
               // anim.Play("chara_damage");
                isdamage = false;
            }
        }
        
    }

    void Move()
    {
        moveDirection.z = 0;
        if (Input.GetButton("Horizontal"))
        {
            if (!isJumping)
            {
                anim.SetBool("isJumping", false);
                anim.SetBool("isRunning", true);
                //anim.Play("chara_run");
            }
            transform.rotation = Quaternion.LookRotation(transform.position +
           (Vector3.right * Input.GetAxisRaw("Horizontal"))
           - transform.position);
        }
        
        float y = moveDirection.y;
        moveDirection = new Vector3(Input.GetAxis("Horizontal"),0, 0);
        moveDirection *= speed * GameParameter.instance._SPD;
        moveDirection.y += y;

        if (moveDirection.y <= 0)
        {
            isSpring = false;
            isJumping = false;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
                anim.SetBool("isRunning", false);
            
            moveDirection.x = 0;
        }

        if (_controller.isGrounded)
        {
            if (!istoge)
            {
                if (!isSpring)
                {
                    moveDirection.y = 0;
                }
                anim.SetBool("isDamage", false);
            }
            else
            {
                //moveDirection.y = JumpHeight * GameParameter._JMP;
                istoge = false;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                isJumping = true;
                anim.SetBool("isJumping", true);
                //anim.Play("chara_jump");
                moveDirection.y = JumpHeight * GameParameter.instance._JMP;
                GameObject.Find("SE").GetComponent<AudioSource>().PlayOneShot(GameParameter.instance.JumpSE);
            }

             anim.SetBool("isJumping", false);
             isJumping = false;
             isSpring = false;
        }
        else
        {
            anim.SetBool("isJumping", true);
            anim.SetBool("isRunning", false);
            //anim.Play("chara_jump");
        }

        moveDirection.y -= gravity * GameParameter.instance._GRV * Time.deltaTime;
        _controller.Move(moveDirection * Time.deltaTime);

        if (knockbackTime > 0)
        {
            knockbackTime -= Time.deltaTime;
            gameObject.transform.position -= knockbackDirection * knockbackSpeed * Time.deltaTime;
        }
    }

    RaycastHit hit;
    void hitcheck()
    {

        //足元方向
        Debug.DrawRay(transform.position + (Vector3.up * 10f), Vector3.down * 30f);
        if (Physics.Raycast(transform.position + Vector3.up * 10f, Vector3.down, out hit, 30))
        {


            if (hit.collider.tag == "enemy")
            {
                if (GameParameter.instance.AttackEffectID != -1)
                {
                    Instantiate(Resources.Load<GameObject>("Prefabs/damageEffect_" + GameParameter.instance.AttackEffectID), hit.point, Quaternion.identity);
                }
                    Destroy(hit.collider.gameObject);
            }

            if (hit.collider.tag == "Spring")
            {
                moveDirection.y = JumpHeight * GameParameter.instance._JMP * 1.5f;
                isSpring = true;
                isJumping = true;
                hit.collider.gameObject.GetComponent<springManager>().PlayBoyon();
                GameObject.Find("SE").GetComponent<AudioSource>().PlayOneShot(GameParameter.instance.SpringSE);
            }

            if (hit.collider.tag == "Toge")
            {
                istoge = true;
                if (istoge)
                {
                    if (!isGameOver)
                    {
                        if (GameParameter.instance.DamageEffectID != -1)
                        {
                            Instantiate(Resources.Load<GameObject>("Prefabs/damageEffect_" + GameParameter.instance.DamageEffectID), hit.point, Quaternion.identity);
                        }
                        anim.SetBool("isDamage", true);
                        //anim.Play("chara_damage");
                        if (life > 0)
                        {
                            lifemanager.GetDamage();
                        }
                        moveDirection.y = JumpHeight * GameParameter.instance._JMP;
                        //istoge = false;
                        GameObject.Find("SE").GetComponent<AudioSource>().PlayOneShot(GameParameter.instance.DamageSE);
                    }
                }
            }
            if(hit.collider.tag == "Object")
            {
                before_isGrounded = isGrounded;
                isGrounded = true;
                if (before_isGrounded == false && isGrounded == true) GameObject.Find("SE").GetComponent<AudioSource>().PlayOneShot(GameParameter.instance.StepSE);
            }
        }
        else
        {
            isGrounded = false;
        }

        //正面方向
        Debug.DrawRay(transform.position + (Vector3.up * 35f), transform.forward * 30f);
        if (Physics.Raycast(transform.position + Vector3.up * 35f, transform.forward, out hit, 30))
        {
            if (hit.collider.tag == "enemy")
            {
                if (!isGameOver)
                {
                    if (GameParameter.instance.DamageEffectID != -1)
                    {
                        Instantiate(Resources.Load<GameObject>("Prefabs/damageEffect_" + GameParameter.instance.DamageEffectID), hit.point, Quaternion.identity);
                    }
                    anim.SetBool("isDamage", true);
                    lifemanager.GetDamage();
                    isdamage = true;
                    knockbackTime = 0.5f;
                    knockbackDirection = (hit.collider.gameObject.transform.position - gameObject.transform.position).normalized;
                    knockbackDirection.y = 0;
                    knockbackSpeed = 250f;
                    GameObject.Find("SE").GetComponent<AudioSource>().PlayOneShot(GameParameter.instance.DamageSE);
                }
            }
        }

        //背面方向判定
        if (Physics.Raycast(transform.position + Vector3.up * 35f, -transform.forward, out hit, 30))
        {
            if (hit.collider.tag == "enemy")
            {
                if (!isGameOver)
                {
                    if (GameParameter.instance.DamageEffectID != -1)
                    {
                        Instantiate(Resources.Load<GameObject>("Prefabs/damageEffect_" + GameParameter.instance.DamageEffectID), hit.point, Quaternion.identity);
                    }

                    anim.SetBool("isDamage", true);
                    lifemanager.GetDamage();
                    isdamage = true;
                    knockbackTime = 0.5f;
                    knockbackDirection = (hit.collider.gameObject.transform.position - gameObject.transform.position).normalized;
                    knockbackDirection.y = 0;
                    knockbackSpeed = 250f;
                    GameObject.Find("SE").GetComponent<AudioSource>().PlayOneShot(GameParameter.instance.DamageSE);
                }
            }
        }
        //頭上方向判定
        Debug.DrawRay(transform.position + (Vector3.up * 50f), transform.up * 30f);
        if (Physics.Raycast(transform.position, transform.up, out hit, 30))
        {
            if (hit.collider.tag == "enemy")
            {
                if (!isGameOver)
                {
                    if (GameParameter.instance.DamageEffectID != -1)
                    {
                        Instantiate(Resources.Load<GameObject>("Prefabs/damageEffect_" + GameParameter.instance.DamageEffectID), hit.point, Quaternion.identity);
                    }

                    anim.SetBool("isDamage", true);
                    lifemanager.GetDamage();
                    isdamage = true;
                    knockbackTime = 0.5f;
                    knockbackDirection = -transform.forward;
                    knockbackDirection.y = 0;
                    knockbackSpeed = 250f;
                    GameObject.Find("SE").GetComponent<AudioSource>().PlayOneShot(GameParameter.instance.DamageSE);
                }
            }
        }
        /*
        int enemy = 1 << LayerMask.NameToLayer("enemy");
        int toge = 1 << LayerMask.NameToLayer("toge");
        int spring = 1 << LayerMask.NameToLayer("spring");

        //足元方向判定
        RaycastHit hit;
        if (Physics.SphereCast( // マスクで指定した対象がヒットしたらtrueを返す
                                transform.position + Vector3.up * 0.5f, // 発射点
                                0.1f, // 飛ばす球体の半径
                                -Vector3.up, // 飛ばす方向
                                out hit, // ヒットした対象が入る(hit.collider.gameObjectでゲームオブジェクトを取得できる)
                                10f, // 射程
                                toge) // 対象のレイヤーマスク
            ) {
                istoge = true;
                if (istoge)
                {
                anim.SetBool("isDamage", true);
                //anim.Play("chara_damage");
                if (life > 0) {
                    lifemanager.GetDamage();
                }
                moveDirection.y = JumpHeight * GameParameter._JMP;
                //istoge = false;
                GameObject.Find("SE").GetComponent<AudioSource>().PlayOneShot(GameParameter.DamageSE);

            }
        }
        

        if (Physics.SphereCast( // マスクで指定した対象がヒットしたらtrueを返す
                        transform.position + Vector3.up * 0.5f, // 発射点
                        0.1f, // 飛ばす球体の半径
                        -Vector3.up, // 飛ばす方向
                        out hit, // ヒットした対象が入る(hit.collider.gameObjectでゲームオブジェクトを取得できる)
                        10f, // 射程
                        enemy) // 対象のレイヤーマスク
    )
        {
            Destroy(hit.collider.gameObject);
        }

        if (!isSpring)
        {
            if (Physics.SphereCast( // マスクで指定した対象がヒットしたらtrueを返す
                                    transform.position + Vector3.up * 1, // 発射点
                                    5f, // 飛ばす球体の半径
                                    -Vector3.up, // 飛ばす方向
                                    out hit, // ヒットした対象が入る(hit.collider.gameObjectでゲームオブジェクトを取得できる)
                                    15f, // 射程
                                    spring) // 対象のレイヤーマスク
                )
            {
                moveDirection.y = JumpHeight * GameParameter._JMP * 1.5f;
                isSpring = true;
                isJumping = true;
                hit.collider.gameObject.GetComponent<springManager>().PlayBoyon();
                GameObject.Find("SE").GetComponent<AudioSource>().PlayOneShot(GameParameter.SpringSE);
            }
        }
        //正面方向判定
        if (Physics.SphereCast( // マスクで指定した対象がヒットしたらtrueを返す
                      transform.position + Vector3.up * 25f, // 発射点
                      1f, // 飛ばす球体の半径
                      Vector3.right, // 飛ばす方向
                      out hit, // ヒットした対象が入る(hit.collider.gameObjectでゲームオブジェクトを取得できる)
                      25f, // 射程
                      enemy) // 対象のレイヤーマスク
           )
        {
            anim.SetBool("isDamage", true);
            lifemanager.GetDamage();
            isdamage = true;
            knockbackTime = 0.5f;
            knockbackDirection = (hit.collider.gameObject.transform.position - gameObject.transform.position).normalized;
            knockbackDirection.y = 0;
            knockbackSpeed = 5f;
            GameObject.Find("SE").GetComponent<AudioSource>().PlayOneShot(GameParameter.DamageSE);
        }

        //背面方向判定
        if (Physics.SphereCast( // マスクで指定した対象がヒットしたらtrueを返す
                      transform.position + Vector3.up * 25f, // 発射点
                      1f, // 飛ばす球体の半径
                      -Vector3.right, // 飛ばす方向
                      out hit, // ヒットした対象が入る(hit.collider.gameObjectでゲームオブジェクトを取得できる)
                      25f, // 射程
                      enemy) // 対象のレイヤーマスク
           )
        {
            anim.SetBool("isDamage", true);
            lifemanager.GetDamage();
            isdamage = true;
            knockbackTime = 0.5f;
            knockbackDirection = (hit.collider.gameObject.transform.position - gameObject.transform.position).normalized;
            knockbackDirection.y = 0;
            knockbackSpeed = -5f;
            GameObject.Find("SE").GetComponent<AudioSource>().PlayOneShot(GameParameter.DamageSE);
        }
        */
    }

    
    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Goal")
        {
            isClear = true;
            transform.eulerAngles = new Vector3(0, 180, 0);
            anim.SetBool("isClear", true);
            //anim.Play("Chara_clearDance");

        }
        if (hit.gameObject.name == "GameOverLine")
        {
            isGameOver = true;
            lifemanager.GetDamage();
            lifemanager.life = 0;
        }
    }

  void Clear_Trans()
    {
		if (GameParameter.instance.isGlobal) {
			//GameParameter.instance.isGlobal = false;
			GetAllStageData.Instance.SendCouneter (() => {
                Application.LoadLevel("selectGlobalScene");
            });
		}
		else if (GameParameter.instance.isEdit)
        {
            Application.LoadLevel("editorScene");
        }
        else
        {
            Application.LoadLevel("selectScene");
        }
    }

    void LoadNext()
    {
        GetAllStageData.Instance.stageID++;
        Application.LoadLevel(Application.loadedLevelName);
    }

    public bool GetisClear()
    {
        return isClear;
    }
    public bool GetisGameOver()
    {
        return isGameOver;
    }
}