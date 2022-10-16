using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO; //�t�@�C���ۑ��p

public class SaveButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    //�w�ۑ��{�^���x���^�b�v��������s
    public void PushSaveImage()
    {
        Debug.Log("�ۑ��ۑ����܂���");
        
        //�摜�t�@�C�����Ɏg���ϐ�
        int i = int.Parse(WorkRefer.saveName);
        string path = "Assets/Resources/MyWork";

        //�ǂݍ��񂾉摜��png�ɕϊ�
        byte[] bytes = AddImage.texture2.texture.EncodeToPNG();

        //�d�����Ȃ��摜�t�@�C������T��
        /*while (File.Exists(path + "/work" + i + ".png"))
        {
            i++;
        }*/
        //(�d�����Ȃ��t�@�C��������������)�ۑ�
        File.WriteAllBytes(path + "/work" + i + ".png", bytes);

        //�摜�ύX���s�������߁A�摜�ύX��true�ɂ���
        PlayerPrefs.SetString("imgInfo" + i, "true");  //�����ɕۑ����e���X�V
        PlayerPrefs.Save();

        //�ڍ׉�ʂ̉摜���ω�������
        GameObject dh = GameObject.Find("detailHold" + i);
        GameObject dhpict = dh.transform.GetChild(2).gameObject;
        Image dhimg = dhpict.gameObject.GetComponent<Image>();
        dhimg.color = new Color(255, 255, 255, 255);

        //�ȈՉ�ʂ̉摜���ω�������
        //GameObject butimg = GameObject.Find(i);
        //Image bimg = butimg.gameObject.GetComponent<Image>();
    }
}
