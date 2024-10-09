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
        foreach (Transform level in LOD_group.transform) { // этот цикл проверяет, виден ли каждый LOD или нет
            var rend = level.GetComponent<Renderer>();
            if (rend.isVisible) // isVisible - определяет, виден ли конкретный LOD на экране игрока
            {
                all_lods_invisible = false;
            }
        }

        if (all_lods_invisible) // если ни один LOD не виден
        {
            LOD_group.ForceLOD(3); // заменяет на LOD с отсутствием надписи
            if (static_on)
            {
                was_invisible_after_static_on = true;
            }
        }
        else if (!static_on)
        {
            LOD_group.ForceLOD(-1); //позволяет снова отображать LOD как положено
            static_on = true; // выставление этого ключа в true позволяет оставлять объект в статичном режиме после того, как игрок снова посмотрит на объект
            //чтобы объект не оставался статичным, достаточно в строке выше поставить false
        }

        if (static_on && was_invisible_after_static_on)
        {
            LOD_group.ForceLOD(3); // заменяет на LOD с отсутствием надписи, позволяет оставлять объект в статичном режиме после того, как игрок снова посмотрит на объект
        }
    }
}
