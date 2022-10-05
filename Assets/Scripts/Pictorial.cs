using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Pictorial : MonoBehaviour
{
    public RectTransform contentRectTransform;
    public RectTransform contentRectTransform2;
    public Button button;
    Sprite[] pictImage = new Sprite[162];
    Button[]obj = new Button[162];
    Image btnImage;
    //Button btn;  //�v���n�u�̃{�^��
    public GameObject detail;  //�ڍ׉�ʂ̃v���n�u
    GameObject detailHold;
    public Transform parentTran;
    EventSystem eventSystem;
    GameObject selectedObj;  //���I�����Ă���{�^���̃C���f�b�N�X�����o��


    private void Start()
    {
        for (int i = 0; i < 162; i++)
        {
            pictImage[i] = Resources.Load<Sprite>("Images/" + i);
        }
        Debug.Log("pictImage =" + pictImage.Length);
        Debug.Log("ButtonFortune =" + ButtonFortune.pictInfo.Length);


        for (int i = 0; i < 162; i++)
        {
            obj[i] = Instantiate(button, contentRectTransform);
            int s = i + 1;
            obj[i].GetComponentInChildren<Text>().text = "No." + s.ToString();
            obj[i].GetComponent<Button>().interactable = false;  //�������̃L�����̓{�^���������Ȃ�����
            btnImage = obj[i].gameObject.GetComponent<Image>();
            ChangeImage(i);    //�ʐ^��ς���
            Button btn = obj[i].GetComponent<Button>();
            btn.onClick.AddListener(OnClickButton);
            Debug.Log("Pictrial��ChangeImage�̌�́A�z��" + i + "��" + PlayerPrefs.GetString("pictInfo" + i));
        }

    }

    public void ChangeImage(int i)
    {
        //PlayerPrefs����true/flase�����o��
        string s = PlayerPrefs.GetString("pictInfo" + i);
        Debug.Log("Pictrial��ChangeImage���͔z��" + i + "��" + s);

        //�������Ă����ꍇ�A�摜��ύX����
        if (s == "true")      //���ɏ������Ă����ꍇ�̏���
        {
            Debug.Log(i + "is OK!," + ButtonFortune.pictInfo[i] + pictImage[i].name);
            btnImage.sprite = pictImage[i];
            obj[i].GetComponent<Button>().interactable = true;  //�������̃L�����̓{�^����������悤�ɂ���
        }

        PlayerPrefs.SetString("pictInfo" + i, s);  //�����ɕۑ����e���X�V
        PlayerPrefs.Save();
    }

    //�v���n�u�̃{�^���������ꂽ�Ƃ��̏���
    public void OnClickButton()
    {
        eventSystem = EventSystem.current;  //�C�x���g�V�X�e���𗘗p���Ăǂ̃{�^���������Ă��邩���擾  
        selectedObj = eventSystem.currentSelectedGameObject;
        // �{�^����Image�R���|�[�l���g����sprite�f�[�^�̖��O���擾
        string index = selectedObj.GetComponent<Image>().sprite.name;

        detailHold = Instantiate(detail, new Vector3(150, 200, 0), Quaternion.identity);
        detailHold.transform.SetParent(parentTran);
        detailHold.transform.localScale = new Vector3(1.2f, 1.2f, 1);
        detailHold.transform.position = new Vector3(82, 170, 0);

        //�{�^���������Ă���Œ��͑��̃{�^���͉����Ȃ�
        for(int i = 0; i<162;i++)
        {
            obj[i].GetComponent<Button>().interactable = false;
        }


        //�q�I�u�W�F�N�g�̎擾
        GameObject objname = detailHold.transform.GetChild(2).gameObject;
        GameObject objstar = detailHold.transform.GetChild(1).gameObject;
        GameObject objcomment = detailHold.transform.GetChild(3).gameObject;
        GameObject objimage = detailHold.transform.GetChild(0).gameObject;

        int s = int.Parse(index);// int.Parse(this.gameObject.GetComponent<Image>().sprite.name);

        Debug.Log("s=" + s);

        ConveyInfo(s, out string name, out string star, out string comment);

        Debug.Log(s + name + star + comment);

        objname.GetComponent<Text>().text = name;
        objstar.GetComponent<Text>().text = star;
        objcomment.GetComponent<Text>().text = comment;
        objimage.GetComponent<Image>().sprite = pictImage[s];
    }

    //�ڍ׉�ʂɃL�����N�^�[����`����
    public void ConveyInfo(int i, out string name, out string star, out string comment)
    {
        string line = ButtonFortune.character[i];
        string[] lineinfo = line.Split(',');
        name = lineinfo[1];
        int s = int.Parse(lineinfo[0]);  //���̐��𐮐���
        star = starStar(s);
        comment = lineinfo[2];
    }

    //����\�����邽�߂̃��\�b�h
    public string starStar(int num)
    {
        string star = null;
        switch (num)
        {
            case 1:
                star = "����������";
                break;
            case 2:
                star = "����������";
                break;
            case 3:
                star = "����������";
                break;
            case 4:
                star = "����������";
                break;
            case 5:
                star = "����������";
                break;
        }
        return star;
    }

    //�v���n�u�̖߂�{�^���������ꂽ�Ƃ�
    public void PrefabOnClick()
    {
        Destroy(detailHold);
        //�ڍ׉�ʂ���������͑��̃{�^����������
        for (int i = 0; i < 162; i++)
        {
            if (PlayerPrefs.GetString("pictInfo" + i) == "true")
            {
                obj[i].GetComponent<Button>().interactable = true;
            }
        }
    }

}
