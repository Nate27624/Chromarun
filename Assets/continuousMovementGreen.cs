using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;



public class continuousMovementGreen : MonoBehaviour

{

    public XRNode inputSource;

    public float gravity = -9.81f;

    public LayerMask groundLayer;

    public float additionalHeight = 0.2f;

    private GameObject player;



    private float fallingSpeed;

    private XRRig rig;

    private Vector2 inputAxis;

    private CharacterController character;

    public float speed;

    public int startGame = 1;

    public int gameType;

    private int playerDifficulty;
    // Start is called before the first frame update
    void Start()

    {
        playerDifficulty = PlayerPrefs.GetInt("playerDifficulty");

        if (playerDifficulty == 0)
        {
            PlayerPrefs.SetInt("playerDifficulty", 3);
            PlayerPrefs.Save();
            playerDifficulty = 3;
        }
        //speed = PlayerPrefs.GetInt("speed");
        character = GetComponent<CharacterController>();
        character.detectCollisions = false;

        rig = GetComponent<XRRig>();

        player = GameObject.Find("OVRCameraRig");


    }



    // Update is called once per frame




    private void Update()

    {

        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);

        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);

        if (player.transform.position.y < -300)
        {
            player.transform.position = new Vector3(0, 5, 0);
        }

        CapsuleFollowHeadset();



        if (startGame == 1)
        {

            Quaternion headYaw = Quaternion.Euler(0, rig.cameraGameObject.transform.eulerAngles.y, 0);

            Vector3 direction = headYaw * new Vector3(0, 0, 1);



            character.Move(direction * Time.fixedDeltaTime * (speed));
        }




        //gravity

        bool isGrounded = CheckIfGrounded();

        if (isGrounded)

            fallingSpeed = 0;

        else

            fallingSpeed += gravity * Time.fixedDeltaTime;

        character.Move(Vector3.up * fallingSpeed * Time.fixedDeltaTime);

    }



    void CapsuleFollowHeadset()

    {

        character.height = rig.cameraInRigSpaceHeight + additionalHeight;

        Vector3 capsuleCenter = transform.InverseTransformPoint(rig.cameraGameObject.transform.position);

        character.center = new Vector3(capsuleCenter.x, character.height / 2 + character.skinWidth, capsuleCenter.z);

    }

    bool CheckIfGrounded()

    {

        //tells us if on ground

        Vector3 rayStart = transform.TransformPoint(character.center);

        float rayLength = character.center.y + 0.01f;

        bool hasHit = Physics.SphereCast(rayStart, character.radius, Vector3.down, out RaycastHit hitInfo, rayLength, groundLayer);

        return hasHit;

    }





}

