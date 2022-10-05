using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class WorkRefer : MonoBehaviour
{
    public RectTransform contentRectTransform;
    public Button workbutton;
    Image btnImage;
    Button obj;
    public GameObject detail;  //�ڍ׉�ʂ̃v���n�u
    GameObject detailHold;
    public Transform parentTran;
    EventSystem eventSystem;
    GameObject selectedObj;  //���I�����Ă���{�^���̃C���f�b�N�X�����o��
    string index; //���Ԗڂ̃{�^����
    GameObject objpict; //�摜�擾�p
    Sprite wwsp;

    private void Start()
    {
        //��i���̐������{�^���𐶐�
        for (int i = 0; i < ButtonMission.WorkStr.Count; i++)
        {
            obj = Instantiate(workbutton, contentRectTransform);  //�I�u�W�F�N�g�̐���
            btnImage = obj.gameObject.GetComponent<Image>();
            //btnImage.sprite =   //���C�u��������摜���擾���ݒ�
            //���X�g�̃C���f�b�N�X���擾���邽�߂�sprite�f�[�^�̖��O�ɐ��������蓖�Ă�
            btnImage.sprite.name = i.ToString();   
            Button btn = obj.GetComponent<Button>();
            btn.onClick.AddListener(OnClickButton);
        }
    }

    public void OnClickButton()
    {
        eventSystem = EventSystem.current;  //�C�x���g�V�X�e���𗘗p���Ăǂ̃{�^���������Ă��邩���擾  
        selectedObj = eventSystem.currentSelectedGameObject;
        // �{�^����Image�R���|�[�l���g����sprite�f�[�^�̖��O���擾
        index = selectedObj.GetComponent<Image>().sprite.name;

        detailHold = Instantiate(detail, new Vector3(150, 200, 0), Quaternion.identity);
        detailHold.transform.SetParent(parentTran);
        detailHold.transform.localScale = new Vector3(0.75f, 0.75f, 1);
        detailHold.transform.position = new Vector3(95, 200, 0);


        //�q�I�u�W�F�N�g�̎擾
        GameObject objday = detailHold.transform.GetChild(0).gameObject;
        objpict = detailHold.transform.GetChild(1).gameObject;
        GameObject objeye = detailHold.transform.GetChild(2).gameObject;
        GameObject objhair = detailHold.transform.GetChild(3).gameObject;
        GameObject objitem = detailHold.transform.GetChild(4).gameObject;
        

        int btnindex = int.Parse(index);
        ConveyInfo(btnindex, out string eye, out string hair, out string item, out string day);

        objday.GetComponent<Text>().text = day;
        objeye.GetComponent<Text>().text = "�ځF" + eye;
        objhair.GetComponent<Text>().text = "���^�F" + hair;
        objitem.GetComponent<Text>().text = "�A�N�Z�F" + item;
        //objpict.GetComponent<Image>().sprite = PlayerPrefs.GetString("ImagePath");

        //StartCoroutine(GetImageFromPath(PlayerPrefs.GetString("ImagePath")));

        /*�����摜���ݒ肳��Ă�����A�ȗ���ʂɂ����̉摜��\������
        Image pctimg = objpict.GetComponent<Image>();
        if(pctimg.sprite != null)
        {
            btnImage = obj.gameObject.GetComponent<Image>();
            btnImage.sprite = wwsp;  //���C�u��������摜���擾���ݒ�
        }*/
        //objpict.GetComponent<Image>().sprite = pictImage[s];  //�摜��ݒ肷��
    }

    //�ڍ׉�ʂɃL�����N�^�[����`����
    public void ConveyInfo(int i, out string eye, out string hair, out string item , out string day)
    {
        string line = PlayerPrefs.GetString("WorkRefer" +i);
        string[] lineinfo = line.Split(',');
        eye = lineinfo[0];
        hair = lineinfo[1];
        item = lineinfo[2];
        day = lineinfo[3];
    }

    //�v���n�u�̖߂�{�^���������ꂽ�Ƃ�
    public void PrefabOnClick()
    {
        Destroy(detailHold);
    }

    /*�p�X����摜���擾
    IEnumerator GetImageFromPath(string path)
    {
        WWW www = new WWW(path);
        yield return www;

        Image pctimg = objpict.GetComponent<Image>();
        //Texture2D��Sprite�ɕϊ�
        var tex = www.textureNonReadable;
        wwsp = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.zero);
        pctimg.sprite = wwsp;

        //�ȈՉ�ʂɂ����̉摜��\��
        Image btnimg = obj[btnindex].GetComponent<Image>();
        btnimg.sprite = wwsp;
    }*/
}
