using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BlackHoleSkillController : MonoBehaviour
{
    [SerializeField] private GameObject hotKeyPrefab;
    [SerializeField] private List<KeyCode> keyCodeList;

    public float maxSize;
    public float growSpeed;
    public float shrinkSpeed;
    private float blackholeTimer;

    private bool canGrow = true;
    private bool canShrink;
    private bool canCreateHotKeys = true;
    private bool cloneAttackReleased;
    private bool playerCanDesapair = true;

    private int amountOfAttacks = 4;
    private float cloneattackCooldown = .3f;
    private float cloneAttackTimer;
    private float radiusClonesAttack = .5f;

    private List<Transform> targets = new List<Transform>();
    private List<GameObject> createHotKey = new List<GameObject>();

    public bool playerCanExitState {  get; private set; }

    public void SetUpBlackHole(float _maxSize, float _growSpeed, float _shrinkSpeed, int _amountOfAttacks, float _cloneAttackCooldown, float _blackholeDuration)
    {
        maxSize = _maxSize;
        growSpeed = _growSpeed;
        shrinkSpeed = _shrinkSpeed;
        amountOfAttacks = _amountOfAttacks;
        cloneattackCooldown = _cloneAttackCooldown;

        blackholeTimer = _blackholeDuration;

        if (SkillManager.instance.clone.crystalInsteadOfClone)
        {
            playerCanDesapair = false;
        }
    }

    private void Update()
    {
        cloneAttackTimer -= Time.deltaTime;
        blackholeTimer -= Time.deltaTime;

        if (blackholeTimer < 0)
        {
            blackholeTimer = Mathf.Infinity;

            if (targets.Count > 0)
            {
                ReleaseCloneAttack();
            }
            else
            {
                FinishBlackholeAbillity();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ReleaseCloneAttack();
        }

        CloneAttackLogic();

        if (canGrow && !canShrink)
        {
            //lerp allows transform from one condition or one size slownly
            transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(maxSize, maxSize), growSpeed * Time.deltaTime);
        }

        if (canShrink)
        {
            transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(-1, -1), shrinkSpeed * Time.deltaTime);

            if (transform.localScale.x < 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void ReleaseCloneAttack()
    {
        if (targets.Count <= 0)
        {
            return;
        }

        DestroyHotKeys();
        cloneAttackReleased = true;
        canCreateHotKeys = false;

        if (playerCanDesapair)
        {
            playerCanDesapair = false;
            PlayerManager.instance.player.fx.MakeTransparent(true);
        }
    }

    private void CloneAttackLogic()
    {
        if (cloneAttackTimer < 0 && cloneAttackReleased && amountOfAttacks > 0)
        {
            cloneAttackTimer = cloneattackCooldown;

            int randomIndex = UnityEngine.Random.Range(0, targets.Count);

            float xOffset;

            if (UnityEngine.Random.Range(0, 100) > 50)
            {
                xOffset = radiusClonesAttack;
            }
            else
            {
                xOffset = -radiusClonesAttack;
            }

            if (SkillManager.instance.clone.crystalInsteadOfClone)
            {
                SkillManager.instance.crystal.CreateCrystal();
                SkillManager.instance.crystal.CurrentCrystalChooseRandomTarget();
            }

            else
            { 
            SkillManager.instance.clone.CreateClone(targets[randomIndex], new Vector3(xOffset, 0));
            }

            amountOfAttacks--;

            if (amountOfAttacks <= 0)
            {
                Invoke("FinishBlackholeAbillity", 1);
            }
        }
    }

    private void FinishBlackholeAbillity()
    {
        DestroyHotKeys();
        playerCanExitState = true;
        canShrink = true;
        cloneAttackReleased = false;       
    }

    private void DestroyHotKeys()
    {
        if (createHotKey.Count <= 0)
        {
            return;
        }
        for (int i = 0; i < createHotKey.Count; i++)
        {
            Destroy(createHotKey[i]);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() != null)
        {
            collision.GetComponent<Enemy>().FreezeTime(true);
            CreateHotKey(collision);
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if(collision.GetComponent<Enemy>() != null)
    //     {
    //        collision.GetComponent <Enemy>().FreezeTime(false);
    //     }
    //}
    
    // THIS CODE IS THE SAME OF THE COMMENTED CODE ABOVE
    private void OnTriggerExit2D(Collider2D collision) => collision.GetComponent<Enemy>()?.FreezeTime(false);

    private void CreateHotKey(Collider2D collision)
    {
        if (keyCodeList.Count <= 0)
        {
            Debug.LogWarning("Not enough hot keys in a key code list!");
            return;
        }

        if (!canCreateHotKeys)
            return;

        GameObject newHotKey = Instantiate(hotKeyPrefab, collision.transform.position + new Vector3(0, 2), Quaternion.identity);
        createHotKey.Add(newHotKey);

        KeyCode choosenKey = keyCodeList[UnityEngine.Random.Range(0, keyCodeList.Count)];
        keyCodeList.Remove(choosenKey);

        BlackholeHotKeyController newHotKeyScript = newHotKey.GetComponent<BlackholeHotKeyController>();

        newHotKeyScript.SetupHotKey(choosenKey, collision.transform, this);
    }

    public void AddEnemyToList(Transform _enemyTransform) => targets.Add(_enemyTransform);

}

