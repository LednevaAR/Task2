using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeObjectBehindPlayer : MonoBehaviour
{
    private bool all_lods_invisible = true;
    private LODGroup LOD_group;
    private bool static_on = false;
    private bool was_invisible_after_static_on = false;
    // Start is called before the first frame update
    void Start()
    {
        LOD_group = GetComponent<LODGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        all_lods_invisible = true;
        foreach (Transform level in LOD_group.transform) { // ���� ���� ���������, ����� �� ������ LOD ��� ���
            var rend = level.GetComponent<Renderer>();
            if (rend.isVisible) // isVisible - ����������, ����� �� ���������� LOD �� ������ ������
            {
                all_lods_invisible = false;
            }
        }

        if (all_lods_invisible) // ���� �� ���� LOD �� �����
        {
            LOD_group.ForceLOD(3); // �������� �� LOD � ����������� �������
            if (static_on)
            {
                was_invisible_after_static_on = true;
            }
        }
        else if (!static_on)
        {
            LOD_group.ForceLOD(-1); //��������� ����� ���������� LOD ��� ��������
            static_on = true; // ����������� ����� ����� � true ��������� ��������� ������ � ��������� ������ ����� ����, ��� ����� ����� ��������� �� ������
            //����� ������ �� ��������� ���������, ���������� � ������ ���� ��������� false
        }

        if (static_on && was_invisible_after_static_on)
        {
            LOD_group.ForceLOD(3); // �������� �� LOD � ����������� �������, ��������� ��������� ������ � ��������� ������ ����� ����, ��� ����� ����� ��������� �� ������
        }
    }
}
